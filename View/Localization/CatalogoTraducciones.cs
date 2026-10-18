using System;
using System.Collections.Generic;
using System.Globalization;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.View.Localization
{
    /// <summary>Centraliza traducciones de presentación sin modificar los datos de SQL Server.</summary>
    public static class CatalogoTraducciones
    {
        private static readonly Dictionary<string, string> Categorias = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Ingredients"] = "Ingredientes",
            ["Finished Products"] = "Productos terminados",
            ["Finished Product"] = "Producto terminado",
            ["Beverages"] = "Bebidas",
            ["Seafood"] = "Mariscos",
            ["Other"] = "Otros"
        };

        private static readonly Dictionary<string, string> UnidadesPorCodigo = new(StringComparer.OrdinalIgnoreCase)
        {
            ["G"] = "Gramo", ["GRAM"] = "Gramo", ["GRAMS"] = "Gramo",
            ["KG"] = "Kilogramo", ["KILOGRAM"] = "Kilogramo", ["KILOGRAMS"] = "Kilogramo",
            ["ML"] = "Mililitro", ["MILLILITER"] = "Mililitro", ["MILLILITERS"] = "Mililitro",
            ["L"] = "Litro", ["LITER"] = "Litro", ["LITERS"] = "Litro",
            ["UNIT"] = "Unidad", ["UNITS"] = "Unidad", ["PIECE"] = "Unidad", ["PIECES"] = "Unidad",
            ["PORTION"] = "Porción", ["PORTIONS"] = "Porción", ["GLASS"] = "Vaso",
            ["BOTTLE"] = "Botella", ["CAN"] = "Lata", ["CASE"] = "Caja"
        };

        private static readonly Dictionary<string, string> UnidadesPorNombre = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Gram"] = "Gramo", ["Grams"] = "Gramo", ["Kilogram"] = "Kilogramo", ["Kilograms"] = "Kilogramo",
            ["Milliliter"] = "Mililitro", ["Milliliters"] = "Mililitro", ["Liter"] = "Litro", ["Liters"] = "Litro",
            ["Unit"] = "Unidad", ["Units"] = "Unidad", ["Piece"] = "Unidad", ["Pieces"] = "Unidad",
            ["Portion"] = "Porción", ["Portions"] = "Porción", ["Glass"] = "Vaso", ["Bottle"] = "Botella",
            ["Can"] = "Lata", ["Case"] = "Caja"
        };

        // Completar con ProductCode reales tras verificarlos en la base de datos.
        private static readonly Dictionary<string, string> IngredientesPorCodigo = new(StringComparer.OrdinalIgnoreCase);

        private static readonly Dictionary<string, string> IngredientesPorNombre = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Avocado"] = "Aguacate", ["Cilantro"] = "Cilantro", ["Fish"] = "Pescado",
            ["Green Pepper"] = "Pimiento verde", ["Lemon"] = "Limón", ["Lime"] = "Limón",
            ["Onion"] = "Cebolla", ["Shrimp"] = "Camarón", ["Tomato"] = "Tomate", ["Tomatoes"] = "Tomates"
        };

        /// <summary>Traduce el nombre de una categoría; si no existe traducción, conserva el original.</summary>
        public static string TraducirCategoria(string? nombre) => Buscar(Categorias, nombre);

        /// <summary>Traduce primero por código estable y después por el nombre actual de la unidad.</summary>
        public static string TraducirUnidad(string? codigo, string? nombre)
        {
            if (!string.IsNullOrWhiteSpace(codigo) && UnidadesPorCodigo.TryGetValue(codigo.Trim(), out string? traduccion))
                return traduccion;
            return Buscar(UnidadesPorNombre, nombre);
        }

        /// <summary>Traduce primero por ProductCode y después por nombre del ingrediente.</summary>
        public static string TraducirIngrediente(string? codigo, string? nombre)
        {
            if (!string.IsNullOrWhiteSpace(codigo) && IngredientesPorCodigo.TryGetValue(codigo.Trim(), out string? traduccion))
                return traduccion;
            return Buscar(IngredientesPorNombre, nombre);
        }

        /// <summary>Obtiene el texto de presentación en español para los objetos de los ComboBox.</summary>
        public static string TextoCombo(object? elemento) => elemento switch
        {
            CategoriaProductoDto categoria => TraducirCategoria(categoria.CategoryName),
            UnidadMedidaDto unidad => TraducirUnidad(unidad.UnitCode, unidad.UnitName),
            ProductoRecetaSelectorDto producto => $"{producto.ProductCode} - {TraducirIngrediente(producto.ProductCode, producto.ProductName)}",
            IngredienteSelectorDto ingrediente => $"{TraducirIngrediente(ingrediente.ProductCode, ingrediente.ProductName)} ({TraducirUnidad(ingrediente.UnitCode, ingrediente.UnitCode)})",
            _ => Convert.ToString(elemento, CultureInfo.CurrentCulture) ?? string.Empty
        };

        private static string Buscar(Dictionary<string, string> traducciones, string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
            string clave = texto.Trim();
            return traducciones.TryGetValue(clave, out string? traduccion) ? traduccion : clave;
        }
    }
}
