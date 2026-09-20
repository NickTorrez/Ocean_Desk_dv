using Ocean_Desk_dv.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Services
{
    public class CajaService
    {
        private readonly OceanDeskDbContext _context;

        public CajaService(OceanDeskDbContext context)
        {
            _context = context;
        }

        public bool TieneCajaAbierta(int usuarioId)
        {
            return _context.CashRegisters.Any(c =>
                c.OpeningUserId == usuarioId &&
                c.Status == "Open");
        }
    }
}
