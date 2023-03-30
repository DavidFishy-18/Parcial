using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    internal class Registrar
    {
        string nP = "";
        string dpi = "";
        DateTime fecha;

        public string NP { get => nP; set => nP = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
