using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Clanovi
    {
        public int id_clana { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string broj_telefona { get; set; }
        public string datum_uclanjenja { get; set; }
    }
}
