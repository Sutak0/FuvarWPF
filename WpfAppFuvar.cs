using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class WpfAppFuvar
    {
        public int taxiAzonosito;
        public string indulasIdopont;
        public int utazasIdotartam;
        public double megtettTav;
        public double viteldij;
        public double borravalo;
        public string fizetesMod;


        public WpfAppFuvar(string sor) 
        {
            string[] darabok = sor.Split(";");
            this.taxiAzonosito = int.Parse(darabok[0]);
            this.indulasIdopont = darabok[1];
            this.utazasIdotartam = int.Parse(darabok[2]);
            this.megtettTav = int.Parse(darabok[3]);
            this.viteldij = int.Parse(darabok[4]);
            this.borravalo = int.Parse(darabok[5]);
            this.fizetesMod = darabok[6];
        }
    }
}
