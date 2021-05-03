using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamla_beadando
{
    class Szamla
    {
        public int Id { get; set; } = 0;
        public string Tulajdonos { get; set; } = "";
        public int Egyenleg { get; set; } = 0;

        public Szamla()
        {
            this.Id = Id;
            this.Tulajdonos = Tulajdonos;
            this.Egyenleg = Egyenleg;
        }
    }
}
