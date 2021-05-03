using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamla_beadando
{
    /// <summary>
    /// A Számla osztályban szerepel egy azonosító (id), a tulajdonos neve, és az egyenleg összege
    /// </summary>
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
