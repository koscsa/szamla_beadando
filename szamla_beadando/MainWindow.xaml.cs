using System;
using System.Collections.Generic;
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

namespace szamla_beadando
{

    public partial class MainWindow : Window
    {
        List<Szamla> szamlaLista = new List<Szamla>();
       
        /// <summary>
        /// A main window.xaml-ben az indításokor betöltött adatok a szövegmezőben a listában első és második helyen lévő Tulaj és Egyenleg propertyk
        /// </summary>
        /// 

        public MainWindow()
        {
            InitializeComponent();
            szamlaLista.Add(new Szamla { Tulajdonos = "Alfa", Egyenleg = 5000 });
            szamlaLista.Add(new Szamla { Tulajdonos = "Beta", Egyenleg = 3000 });

            Tulaj1.Text = szamlaLista[0].Tulajdonos;
            Egyenleg1.Text = Convert.ToString(szamlaLista[0].Egyenleg);
            Tulaj2.Text = szamlaLista[1].Tulajdonos;
            Egyenleg2.Text = Convert.ToString(szamlaLista[1].Egyenleg);
        }

        public void Utalas1(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(Input1.Text, out szam) && (Input1.Text != "" && Convert.ToInt32(Input1.Text) >= 0) && Convert.ToInt32(Input1.Text) <= szamlaLista[0].Egyenleg)
            {
                szamlaLista[1].Egyenleg += Convert.ToInt32(Input1.Text);
                szamlaLista[0].Egyenleg -= Convert.ToInt32(Input1.Text);

                Egyenleg1.Text = szamlaLista[0].Egyenleg.ToString();
                Egyenleg2.Text = szamlaLista[1].Egyenleg.ToString();

                Input1.Text = "";
            }
            else if (Int32.TryParse(Input1.Text, out szam) && (Input1.Text != ""))
            {
                if (Convert.ToInt32(Input1.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz 0-nál kisebb értéket utalni");
                }
                else if (Convert.ToInt32(Input1.Text) > szamlaLista[0].Egyenleg)
                {
                    MessageBox.Show("A megadott érték nagyobb mint az egyenleged");
                }
            }
            else if (Input1.Text != "")
            {
                MessageBox.Show("Számot kérek");
            }

        }
        /// <summary>
        /// Az
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Utalas2(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(Input2.Text, out szam) && (Input2.Text != "") && (Convert.ToInt32(Input2.Text) >= 0) && Convert.ToInt32(Input2.Text) <= szamlaLista[1].Egyenleg)
            {
                szamlaLista[1].Egyenleg -= Convert.ToInt32(Input2.Text);
                szamlaLista[0].Egyenleg += Convert.ToInt32(Input2.Text);

                Egyenleg1.Text = szamlaLista[0].Egyenleg.ToString();
                Egyenleg2.Text = szamlaLista[1].Egyenleg.ToString();

                Input2.Text = "";
            }
            else if (Int32.TryParse(Input2.Text, out szam) && (Input2.Text != ""))
            {
                if (Convert.ToInt32(Input2.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz 0-nál kisebb értéket utalni");
                }
                else if (Convert.ToInt32(Input2.Text) > szamlaLista[1].Egyenleg)
                {
                    MessageBox.Show("A megadott érték nagyobb mint az egyenleged");
                }
            }
            else if (Input2.Text != "")
            {
                MessageBox.Show("Számot kérek");
            }

        }
        public void Feltolt1(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(Input1.Text, out szam) && (Input1.Text != "" && Convert.ToInt32(Input1.Text) >= 0) && Convert.ToInt32(Input1.Text) <= szamlaLista[0].Egyenleg)
            {
                szamlaLista[0].Egyenleg += Convert.ToInt32(Input1.Text);

                Egyenleg1.Text = szamlaLista[0].Egyenleg.ToString();

                Input1.Text = "";

            }
            else if (Int32.TryParse(Input1.Text, out szam) && (Input1.Text != ""))
            {
                if (Convert.ToInt32(Input1.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz 0-nál kisebb értéket feltölteni");
                }
                else if (Convert.ToInt32(Input1.Text) > szamlaLista[0].Egyenleg)
                {
                    MessageBox.Show("A megadott érték nagyobb mint az egyenleged");
                }
            }
            else if (Input1.Text != "")
            {
                MessageBox.Show("Számot kérek");
            }

        }
        public void Feltolt2(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(Input2.Text, out szam) && (Input2.Text != "" && Convert.ToInt32(Input2.Text) >= 0) && Convert.ToInt32(Input2.Text) <= szamlaLista[1].Egyenleg)
            {
                szamlaLista[1].Egyenleg += Convert.ToInt32(Input2.Text);

                Egyenleg2.Text = szamlaLista[1].Egyenleg.ToString();

                Input2.Text = "";

            }
            else if (Int32.TryParse(Input2.Text, out szam) && (Input2.Text != ""))
            {
                if (Convert.ToInt32(Input2.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz 0-nál kisebb értéket feltölteni");
                }
                else if (Convert.ToInt32(Input2.Text) > szamlaLista[1].Egyenleg)
                {
                    MessageBox.Show("A megadott érték nagyobb mint az egyenleged");
                }
            }
            else if (Input2.Text != "")
            {
                MessageBox.Show("Számot kérek");
            }

        }

        public void Kivet2(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(Input2.Text, out szam) && (Input2.Text != "" && Convert.ToInt32(Input2.Text) >= 0) && Convert.ToInt32(Input2.Text) <= szamlaLista[1].Egyenleg)
            {
                szamlaLista[1].Egyenleg -= Convert.ToInt32(Input2.Text);

                Egyenleg2.Text = szamlaLista[1].Egyenleg.ToString();

                Input2.Text = "";

            }
            else if (Int32.TryParse(Input2.Text, out szam) && (Input2.Text != ""))
            {
                if (Convert.ToInt32(Input2.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz 0-nál kisebb értéket kivenni");
                }
                else if (Convert.ToInt32(Input2.Text) > szamlaLista[1].Egyenleg)
                {
                    MessageBox.Show("A megadott érték nagyobb mint az egyenleged");
                }
            }
            else if (Input2.Text != "")
            {
                MessageBox.Show("Számot kérek");
            }

        }

        public void Kivet1(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(Input1.Text, out szam) && (Input1.Text != "" && Convert.ToInt32(Input1.Text) >= 0) && Convert.ToInt32(Input1.Text) <= szamlaLista[0].Egyenleg)
            {
                szamlaLista[0].Egyenleg -= Convert.ToInt32(Input1.Text);

                Egyenleg1.Text = szamlaLista[0].Egyenleg.ToString();

                Input1.Text = "";

            }
            else if (Int32.TryParse(Input1.Text, out szam) && (Input1.Text != ""))
            {
                if (Convert.ToInt32(Input1.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz 0-nál kisebb értéket kivenni");
                }
                else if (Convert.ToInt32(Input1.Text) > szamlaLista[0].Egyenleg)
                {
                    MessageBox.Show("A megadott érték nagyobb mint az egyenleged");
                }
            }
            else if (Input1.Text != "")
            {
                MessageBox.Show("Számot kérek");
            }

        }
        public void TulajValtas1(object sender, RoutedEventArgs e)
        {
            szamlaLista[0].Tulajdonos = Input1.Text;
            Tulaj1.Text = szamlaLista[0].Tulajdonos;
            Input1.Text = "";
        }
        public void TulajValtas2(object sender, RoutedEventArgs e)
        {
            szamlaLista[1].Tulajdonos = Input2.Text;
            Tulaj2.Text = szamlaLista[1].Tulajdonos;
            Input2.Text = "";
        }
    }
}
