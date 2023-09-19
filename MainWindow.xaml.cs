using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<WpfAppFuvar> lista = new List<WpfAppFuvar>();
            using (StreamReader sr = new StreamReader("fuvar.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) {
                string sor = sr.ReadLine();
                    WpfAppFuvar sor1 = new WpfAppFuvar(sor);
                    lista.Add(sor1);
                }

            }

            MessageBox.Show(Convert.ToString("3. feladat: " + lista.Count() + "fuvar került feljegyzésre."));

            foreach (var sorok in lista)
            {
                if (sorok.taxiAzonosito == 6185)
                {
                    double azonositoBevetel = sorok.viteldij + sorok.borravalo;
                    double azonositoFuvarSzam = Convert.ToDouble(sorok.fizetesMod);
                    MessageBox.Show(Convert.ToString("4. feladat: " + azonositoFuvarSzam + "fuvar alatt" + azonositoBevetel + "pénzt keresett."));

                }
            }

            MessageBox.Show(Convert.ToString("5. feladat: "+" bankkártya: " +lista.Count(x=>x.fizetesMod == "bankkártya" + "fuvar")));
            MessageBox.Show(Convert.ToString("\n "+" készpénz: " + lista.Count(x => x.fizetesMod == "készpénz" + "fuvar")));
            MessageBox.Show(Convert.ToString("\n " + " vitatott: " + lista.Count(x => x.fizetesMod == "vitatott" + "fuvar")));
            MessageBox.Show(Convert.ToString("\n " + " ingyenes: " + lista.Count(x => x.fizetesMod == "ingyenes" + "fuvar")));
            MessageBox.Show(Convert.ToString("\n " + " ismeretlen:  " + lista.Count(x => x.fizetesMod == "ismeretlen" + "fuvar")));


            double megtettMerfold = 0;
            foreach (var sorok in lista)
            {
                megtettMerfold = sorok.megtettTav;
            }

            double megtettKilometer = megtettMerfold * 1.6;
            MessageBox.Show(Convert.ToString("6. feladat: " + "A taxisok összesen" + Math.Round(megtettKilometer, 2) + "km-t tettek meg."));
            /* 8: */
            foreach (var sorok in lista)
            {
                if (sorok.utazasIdotartam != 0 && sorok.viteldij != 0 | sorok.megtettTav == 0)
                {
                    File.WriteAllText("hibak.txt", "" );
                }
            }      
        
        }
    }
}
