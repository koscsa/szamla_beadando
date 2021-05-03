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
        /// <summary>
        /// A számlákat tartalmazó lista létrehozása
        /// </summary>
        List<Szamla> szamlaLista = new List<Szamla>();
       
        /// <summary>
        /// A main window.xaml-ben az indításkor betöltött adatok a szövegmezőben a listában első és második helyen lévő Tulaj és Egyenleg propertyk
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
        /// <summary>
        /// A jobb oldali Utalás gombra kattintva ez fut le    
        /// Az Utalas1 az első számlából levonja a beviteli mezőjébe bevitt értéket, majd hozzáadja a másodikhoz
        /// Le van kezelve, hogy a beviteli mező hibát dobjon, ha nem pozitív a szám, ha nagyobb mint az egyenleg, vagy ha betűsort kap
        /// Ezt az szám integerrel ellenőrzi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// A bal oldali Utalás gombra kattintva ez fut le 
        ///Az Utalas2 a második számlából levonja a beviteli mezőjébe bevitt értéket, majd hozzáadja az elsőhoz
        /// Le van kezelve, hogy a beviteli mező hibát dobjon, ha nem pozitív a szám, ha nagyobb mint az egyenleg, ha üres a mező, vagy ha betűsort kap
        /// Ezt a szám integerrel végzi
        /// Ezután kinullázza a beviteli mezőt
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
        /// <summary>
        /// A jobb oldali Feltöltés gombra kattintva ez fut le 
        /// A Feltolt1 metódus feltölti az első számlát a beviteli mezőjében megadott összeggel, ez is le van kezelve negatív számokra, betűkre, üres mezőre és lehetséges negatív különbségekre.
        /// Ezután kinullázza a beviteli mezőt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// A bal oldali Utalás gombra kattintva ez fut le 
        /// A Feltolt2 metódus feltölti a második számlát a beviteli mezőjében megadott összeggel, ez is le van kezelve negatív számokra, betűkre, üres mezőre és lehetséges negatív különbségekre.
        /// Ezután kinullázza a beviteli mezőt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// A bal oldali Kivét gombra kattintva ez fut le 
        /// A Kivet2 kiveszi a második számlából a beviteli mezőjében megadott öszeget, ez is le van kezelve negatív számokra, betűkre, üres mezőre és lehetséges negatív különbségekre.
        /// kinullázza a beviteli mezőt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// A jobb oldali Kivét gombra kattintva ez fut le 
        /// A Kivet1 kiveszi az első számlából a beviteli mezőjében megadott öszeget, ez is le van kezelve negatív számokra, betűkre, üres mezőre és lehetséges negatív különbségekre.
        /// kinullázza a beviteli mezőt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// A TulajValtas1 kicseréli a Tulaj1 szövegmezőben lévő nevet a beviteli mezőjébe beírt névre, ha a Tulajdonos név váltásra kattintanak
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TulajValtas1(object sender, RoutedEventArgs e)
        {
            szamlaLista[0].Tulajdonos = Input1.Text;
            Tulaj1.Text = szamlaLista[0].Tulajdonos;
            Input1.Text = "";
        }
        /// <summary>
        /// A TulajValtas2 kicseréli a Tulaj2 szövegmezőben lévő nevet a beviteli mezőjébe beírt névre, ha a Tulajdonos név váltásra kattintanak
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TulajValtas2(object sender, RoutedEventArgs e)
        {
            szamlaLista[1].Tulajdonos = Input2.Text;
            Tulaj2.Text = szamlaLista[1].Tulajdonos;
            Input2.Text = "";
        }
    }
}
