using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.View.MessageBox;
using Ocean_Desk_dv.View.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.Catalogs
{
    /// <summary>
    /// Vista principal para consultar existencias y movimientos
    /// de inventario y solicitar operaciones manuales.
    /// </summary>
    public partial class FrmInventario : Form, IInventarioView
    {
        private InventarioPresenter? _presenter;

        // Evita disparar consultas durante la configuración de los filtros.
        private bool _actualizandoFiltros;

        /// <summary>
        /// Inicializa los controles y configura sus eventos.
        /// </summary>
        public FrmInventario()
        {
            InitializeComponent();

            ConfigurarGrillas();
            ConfigurarFiltros();
            ConectarEventos();
        }

        public SolicitudEntradaIngredienteDto? SolicitarEntradaIngrediente(
        IReadOnlyList<IngredienteSelectorDto> ingredientes,
        IReadOnlyList<UnidadMedidaDto> unidades,
        string? codigoPropuesto)
        {
            using var formulario = new FrmEntradaInventario(
                ingredientes,
                unidades,
                codigoPropuesto);

            DialogResult resultado = formulario.ShowDialog(this);

            return resultado == DialogResult.OK
                ? formulario.Resultado
                : null;
        }
        /// <summary>
        /// Ingrediente seleccionado actualmente en la tabla de existencias.
        /// Devuelve null si no existe una selección explícita.
        /// </summary>
        public ExistenciaInventarioDto? ExistenciaSeleccionada =>
            dgvExistencias.SelectedRows.Count > 0
                ? dgvExistencias.SelectedRows[0].DataBoundItem
                    as ExistenciaInventarioDto
                : null;

        /// <summary>
        /// Obtiene los filtros actuales de la tabla de existencias.
        /// </summary>
        public FiltroExistenciasInventarioDto FiltroExistenciasActual =>
            new FiltroExistenciasInventarioDto
            {
                TextoBusqueda = string.IsNullOrWhiteSpace(
                    txtBuscarInventario.Text)
                        ? null
                        : txtBuscarInventario.Text.Trim(),

                Categoria = ObtenerCategoriaFiltroSeleccionada(),

                EstadoStock = ObtenerFiltroCombo(
                    cmbEstadoStock,
                    "Todos"),

                EstadoVencimiento = ObtenerFiltroCombo(
                    cmbVencimiento,
                    "Todos")
            };

        /// <summary>
        /// Obtiene los filtros actuales del historial de movimientos.
        /// Los tipos mostrados en español se convierten a los códigos
        /// que almacena SQL Server.
        /// </summary>
        public FiltroMovimientosInventarioDto FiltroMovimientosActual =>
            new FiltroMovimientosInventarioDto
            {
                Desde = dtpDesde.Value.Date,
                Hasta = dtpHasta.Value.Date,
                TipoMovimiento = ObtenerTipoMovimientoParaConsulta(
                    cmbTipoMovimiento.SelectedItem?.ToString()),
                TextoBusqueda = null
            };

        /// <summary>
        /// Enlaza el Presenter e inicia la carga inicial de datos.
        /// </summary>
        public void VincularPresenter(InventarioPresenter presenter)
        {
            if (presenter is null)
                throw new ArgumentNullException(nameof(presenter));

            if (_presenter is not null)
                throw new InvalidOperationException(
                    "El Presenter del inventario ya fue asignado.");

            _presenter = presenter;
            _presenter.Inicializar();
        }

        /// <summary>
        /// Configura las tablas sin cambiar la disposición visual
        /// definida en FrmInventario.Designer.cs.
        /// </summary>
        private void ConfigurarGrillas()
        {
            dgvExistencias.AutoGenerateColumns = false;
            dgvExistencias.ReadOnly = true;
            dgvExistencias.AllowUserToAddRows = false;
            dgvExistencias.AllowUserToDeleteRows = false;
            dgvExistencias.MultiSelect = false;
            dgvExistencias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMovimientos.CellFormatting -= DgvMovimientos_CellFormatting;

            dgvMovimientos.CellFormatting += DgvMovimientos_CellFormatting;

            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Corrige el nombre de propiedad que tenía un error tipográfico
            // en el diseñador: MovementDataTime frente a MovementDateTime.
            colFechaMov.DataPropertyName =
                nameof(MovimientoInventarioDto.MovementDateTime);

            colFechaMov.DefaultCellStyle.Format = "g";

            // Personaliza visualmente los estados de existencias.
            dgvExistencias.CellFormatting -=
                DgvExistencias_CellFormatting;

            dgvExistencias.CellFormatting +=
                DgvExistencias_CellFormatting;
        }

        private void DgvMovimientos_CellFormatting(
        object? sender,
        DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvMovimientos.Rows[e.RowIndex].DataBoundItem
                is not MovimientoInventarioDto movimiento)
            {
                return;
            }

            string nombreColumna =
                dgvMovimientos.Columns[e.ColumnIndex].Name;

            if (nombreColumna == colProductoMov.Name)
            {
                e.Value = CatalogoTraducciones.TraducirIngrediente(
                    null,
                    movimiento.ProductName);

                e.FormattingApplied = true;
            }
            else if (nombreColumna == colUnidadMov.Name)
            {
                e.Value = CatalogoTraducciones.TraducirUnidad(
                    null,
                    movimiento.UnitName);

                e.FormattingApplied = true;
            }
        }

        /// <summary>
        /// Prepara las opciones iniciales de los filtros.
        /// Se eliminan los elementos vacíos que estaban en el diseñador
        /// del filtro por tipo de movimiento.
        /// </summary>
        private void ConfigurarFiltros()
        {
            _actualizandoFiltros = true;

            try
            {
                cmbCategoriaInventario.BeginUpdate();
                cmbCategoriaInventario.Items.Clear();
                cmbCategoriaInventario.Items.Add(new OpcionCategoriaInventario("Todas", null));
                cmbCategoriaInventario.SelectedIndex = 0;
                cmbCategoriaInventario.EndUpdate();

                cmbEstadoStock.BeginUpdate();
                cmbEstadoStock.Items.Clear();
                cmbEstadoStock.Items.AddRange(new object[]
                {
                    "Todos",
                    "Normal",
                    "Bajo",
                    "Agotado"
                });
                cmbEstadoStock.SelectedIndex = 0;
                cmbEstadoStock.EndUpdate();

                cmbVencimiento.BeginUpdate();
                cmbVencimiento.Items.Clear();
                cmbVencimiento.Items.AddRange(new object[]
                {
                    "Todos",
                    "Próximos a vencer",
                    "Vencidos"
                });
                cmbVencimiento.SelectedIndex = 0;
                cmbVencimiento.EndUpdate();

                cmbTipoMovimiento.BeginUpdate();
                cmbTipoMovimiento.Items.Clear();
                cmbTipoMovimiento.Items.AddRange(new object[]
                {
                    "Todos",
                    "Entrada",
                    "Salida",
                    "Ajuste",
                    "Pérdida/Dañado",
                    "Compra",
                    "Venta"
                });
                cmbTipoMovimiento.SelectedIndex = 0;
                cmbTipoMovimiento.EndUpdate();

                // El historial comienza mostrando los últimos 30 días.
                dtpDesde.MaxDate = DateTime.Today;
                dtpHasta.MaxDate = DateTime.Today;

                dtpDesde.Value = DateTime.Today.AddDays(-30);
                dtpHasta.Value = DateTime.Today;
            }
            finally
            {
                _actualizandoFiltros = false;
            }
        }

        /// <summary>
        /// Conecta los filtros y botones con los eventos de la vista.
        /// </summary>
        private void ConectarEventos()
        {
            txtBuscarInventario.TextChanged += (_, _) =>
            {
                NotificarCambioFiltrosExistencias();
            };

            cmbCategoriaInventario.SelectedIndexChanged += (_, _) =>
            {
                NotificarCambioFiltrosExistencias();
            };

            cmbEstadoStock.SelectedIndexChanged += (_, _) =>
            {
                NotificarCambioFiltrosExistencias();
            };

            cmbVencimiento.SelectedIndexChanged += (_, _) =>
            {
                NotificarCambioFiltrosExistencias();
            };

            btnRefrescarInventario.Click += (_, _) =>
            {
                RefrescarInventarioSolicitado?.Invoke(
                    this,
                    EventArgs.Empty);
            };

            dtpDesde.ValueChanged += AlCambiarFechaMovimiento;
            dtpHasta.ValueChanged += AlCambiarFechaMovimiento;

            cmbTipoMovimiento.SelectedIndexChanged += (_, _) =>
            {
                if (_actualizandoFiltros)
                    return;

                FiltrosMovimientosCambiados?.Invoke(
                    this,
                    EventArgs.Empty);
            };

            btnRegistrarEntrada.Click += (_, _) =>
                EntradaInventarioSolicitada?.Invoke(
                    this,
                    EventArgs.Empty);

            btnRegistrarSalida.Click += (_, _) =>
                SalidaInventarioSolicitada?.Invoke(
                    this,
                    EventArgs.Empty);

            btnRegistrarAjuste.Click += (_, _) =>
                AjusteInventarioSolicitado?.Invoke(
                    this,
                    EventArgs.Empty);

            btnRegistrarPerdida.Click += (_, _) =>
                PerdidaInventarioSolicitada?.Invoke(
                    this,
                    EventArgs.Empty);

            // Libera el repositorio cuando se cierra la vista.
            FormClosed += (_, _) =>
            {
                _presenter?.Dispose();
                _presenter = null;
            };
        }

        /// <summary>
        /// Notifica al Presenter cuando cambian los filtros de existencias.
        /// </summary>
        private void NotificarCambioFiltrosExistencias()
        {
            if (_actualizandoFiltros)
                return;

            FiltrosExistenciasCambiados?.Invoke(
                this,
                EventArgs.Empty);
        }

        /// <summary>
        /// Mantiene válido el intervalo de fechas y actualiza el historial.
        /// La fecha inicial nunca podrá superar la fecha final.
        /// </summary>
        private void AlCambiarFechaMovimiento(
            object? sender,
            EventArgs e)
        {
            if (_actualizandoFiltros)
                return;

            _actualizandoFiltros = true;

            try
            {
                if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                {
                    if (ReferenceEquals(sender, dtpDesde))
                    {
                        dtpHasta.Value = dtpDesde.Value.Date;
                    }
                    else
                    {
                        dtpDesde.Value = dtpHasta.Value.Date;
                    }
                }
            }
            finally
            {
                _actualizandoFiltros = false;
            }

            FiltrosMovimientosCambiados?.Invoke(
                this,
                EventArgs.Empty);
        }

        /// <summary>
        /// Actualiza la tabla de existencias con los datos recibidos.
        /// </summary>
        public void MostrarExistencias(
            IReadOnlyList<ExistenciaInventarioDto> existencias)
        {
            dgvExistencias.DataSource = null;
            dgvExistencias.DataSource = existencias.ToList();

            // Obliga al usuario a seleccionar una fila explícitamente
            // antes de registrar una operación de inventario.
            dgvExistencias.ClearSelection();
        }

        /// <summary>
        /// Actualiza el historial de movimientos.
        /// </summary>
        public void MostrarMovimientos(
            IReadOnlyList<MovimientoInventarioDto> movimientos)
        {
            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = movimientos.ToList();
            dgvMovimientos.ClearSelection();
        }

        /// <summary>
        /// Carga las categorías disponibles, conservando "Todas"
        /// como opción para consultar sin restricción de categoría.
        /// </summary>
        public void MostrarCategoriasInventario(
    IReadOnlyList<string> categorias)
        {
            _actualizandoFiltros = true;
            cmbCategoriaInventario.BeginUpdate();

            try
            {
                string? seleccionAnterior =
                    (cmbCategoriaInventario.SelectedItem
                        as OpcionCategoriaInventario)?.ValorBaseDatos;

                cmbCategoriaInventario.Items.Clear();

                cmbCategoriaInventario.Items.Add(
                    new OpcionCategoriaInventario("Todas", null));

                foreach (string categoria in categorias
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .OrderBy(c => c))
                {
                    cmbCategoriaInventario.Items.Add(
                        new OpcionCategoriaInventario(
                            CatalogoTraducciones.TraducirCategoria(categoria),
                            categoria));
                }

                OpcionCategoriaInventario? opcionConservada =
                    cmbCategoriaInventario.Items
                        .OfType<OpcionCategoriaInventario>()
                        .FirstOrDefault(o =>
                            string.Equals(
                                o.ValorBaseDatos,
                                seleccionAnterior,
                                StringComparison.OrdinalIgnoreCase));

                if (opcionConservada is not null)
                {
                    cmbCategoriaInventario.SelectedItem = opcionConservada;
                }
                else
                {
                    cmbCategoriaInventario.SelectedIndex = 0;
                }
            }
            finally
            {
                cmbCategoriaInventario.EndUpdate();
                _actualizandoFiltros = false;
            }
        }

        /// <summary>
        /// Abre el diálogo modal con el ingrediente seleccionado.
        /// Si no se seleccionó una fila, no se solicita ningún movimiento.
        /// </summary>
        public SolicitudMovimientoInventarioDto? SolicitarMovimiento(
            string tipoMovimiento,
            ExistenciaInventarioDto? producto)
        {
            if (producto is null)
            {
                FrmMessageBox.Show(
                    "Seleccione un ingrediente de la tabla de existencias " +
                    "antes de registrar el movimiento.",
                    "Ingrediente no seleccionado",
                    MessageType.Warning);

                return null;
            }

            using var formulario =
                new FrmMovimientoInventario(tipoMovimiento, producto);

            DialogResult resultado = formulario.ShowDialog(this);

            return resultado == DialogResult.OK
                ? formulario.Resultado
                : null;
        }

        /// <summary>
        /// Presenta mensajes mediante el diálogo estandarizado de Ocean Desk.
        /// </summary>
        public void MostrarMensaje(
            string mensaje,
            string titulo = "Inventario",
            bool esError = false)
        {
            FrmMessageBox.Show(
                mensaje,
                titulo,
                esError
                    ? MessageType.Error
                    : MessageType.Information);
        }

        /// <summary>
        /// Aplica colores de lectura rápida al estado de stock y al vencimiento.
        /// </summary>

        private void DgvExistencias_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvExistencias.Rows[e.RowIndex].DataBoundItem
                is not ExistenciaInventarioDto existencia)
            {
                return;
            }

            string nombreColumna =
                dgvExistencias.Columns[e.ColumnIndex].Name;

            // Los datos originales permanecen intactos; solo cambia
            // el valor presentado visualmente en la celda.
            switch (nombreColumna)
            {
                case nameof(colProductoInv):
                    e.Value = CatalogoTraducciones.TraducirIngrediente(
                        existencia.ProductCode,
                        existencia.ProductName);

                    e.FormattingApplied = true;
                    break;

                case nameof(colCategoriaInv):
                    e.Value = CatalogoTraducciones.TraducirCategoria(
                        existencia.CategoryName);

                    e.FormattingApplied = true;
                    break;

                case nameof(colUnidadInv):
                    e.Value = CatalogoTraducciones.TraducirUnidad(
                        null,
                        existencia.UnitName);

                    e.FormattingApplied = true;
                    break;

                case nameof(colVencimiento):
                    if (existencia.ExpirationDate.HasValue)
                    {
                        e.Value = existencia.ExpirationDate.Value
                            .ToString("dd/MM/yyyy");

                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = "Sin fecha";
                        e.FormattingApplied = true;
                    }
                    break;
            }

            // Conserva el formato visual de los estados de existencias.
            if (nombreColumna == colEstadoStock.Name)
            {
                switch (existencia.StockStatus)
                {
                    case "Agotado":
                        e.CellStyle.ForeColor = Color.Firebrick;
                        e.CellStyle.Font =
                            new Font(dgvExistencias.Font, FontStyle.Bold);
                        break;

                    case "Bajo":
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        e.CellStyle.Font =
                            new Font(dgvExistencias.Font, FontStyle.Bold);
                        break;

                    case "Normal":
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                }
            }

            if (nombreColumna == colVencimiento.Name)
            {
                switch (existencia.ExpirationStatus)
                {
                    case "Vencido":
                        e.CellStyle.ForeColor = Color.Firebrick;
                        e.CellStyle.Font =
                            new Font(dgvExistencias.Font, FontStyle.Bold);
                        break;

                    case "Próximos a vencer":
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        break;
                }
            }
        }


        /// <summary>
        /// Obtiene el texto seleccionado de un filtro.
        /// Devuelve null cuando representa la opción general.
        /// </summary>
        private static string? ObtenerFiltroCombo(
            ComboBox combo,
            string opcionGeneral)
        {
            string valor =
                combo.SelectedItem?.ToString()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(valor) ||
                string.Equals(
                    valor,
                    opcionGeneral,
                    StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return valor;
        }

        private string? ObtenerCategoriaFiltroSeleccionada()
        {
            return (cmbCategoriaInventario.SelectedItem
                as OpcionCategoriaInventario)?.ValorBaseDatos;
        }

        private sealed class OpcionCategoriaInventario
        {
            public string TextoMostrar { get; }
            public string? ValorBaseDatos { get; }

            public OpcionCategoriaInventario(
                string textoMostrar,
                string? valorBaseDatos)
            {
                TextoMostrar = textoMostrar;
                ValorBaseDatos = valorBaseDatos;
            }

            public override string ToString() => TextoMostrar;
        }

        /// <summary>
        /// Convierte la etiqueta visible del movimiento al código almacenado.
        /// </summary>
        private static string? ObtenerTipoMovimientoParaConsulta(
            string? texto)
        {
            string valor = texto?.Trim() ?? string.Empty;

            return valor switch
            {
                "Entrada" => TiposMovimientoInventario.Entrada,
                "Salida" => TiposMovimientoInventario.Salida,
                "Ajuste" => TiposMovimientoInventario.Ajuste,
                "Pérdida/Dañado" => TiposMovimientoInventario.Perdida,
                "Compra" => TiposMovimientoInventario.Compra,
                "Venta" => TiposMovimientoInventario.Venta,
                _ => null
            };
        }

        /// <summary>
        /// Eventos que conectan la vista con InventarioPresenter.
        /// </summary>
        public event EventHandler? FiltrosExistenciasCambiados;
        public event EventHandler? FiltrosMovimientosCambiados;
        public event EventHandler? RefrescarInventarioSolicitado;
        public event EventHandler? EntradaInventarioSolicitada;
        public event EventHandler? SalidaInventarioSolicitada;
        public event EventHandler? AjusteInventarioSolicitado;
        public event EventHandler? PerdidaInventarioSolicitada;
    }

}

