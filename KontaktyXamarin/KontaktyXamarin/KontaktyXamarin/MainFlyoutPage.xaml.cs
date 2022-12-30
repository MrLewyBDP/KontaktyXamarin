using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KontaktyXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutPage : FlyoutPage
    {
        public Model model = new Model();

        public MainFlyoutPage()
        {
            InitializeComponent();

            listaOsob.ItemsSource = model.pobierzListe("", Convert.ToInt32(NumerStrony.Text));
            update();
        }


        private async void SzczegolgyTapped(object sender, EventArgs e)
        {
            var osoba = listaOsob.SelectedItem as Osoba;
            await Navigation.PushAsync(new SzczegolyOsobyForm(osoba));
        }

        private async void DodajOsobe(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DodajOsobeForm(this));
            update();

        }

        private async void UsunOsobe(object sender, EventArgs e)
        {
            var osoba = listaOsob.SelectedItem as Osoba;
            if (osoba != null)
            {
                model.usunOsobe(osoba.osoba_id);
                listaOsob.ItemsSource = null;
                NumerStrony.Text = "1";
                listaOsob.ItemsSource = model.pobierzListe(searchBar.Text, Convert.ToInt32(NumerStrony.Text));
                await DisplayAlert("Operacja zakończona powodzeniem", $" Usunąłeś {osoba.imie} {osoba.nazwisko}", "OK");
                update();
            }
            else
            {
                await DisplayAlert("Error", "Proszę wybrać osobę do usunięcia", "OK");
            }
        }

        private async void ModyfikujOsobe(object sender, EventArgs e)
        {
            var osoba = listaOsob.SelectedItem as Osoba;
            if (osoba != null)
            {
                await Navigation.PushAsync(new FormModyfikuj(this, osoba));
                update();
            }
            else
            {
                await DisplayAlert("Error", "Proszę wybrać osobę do modyfikacji", "OK");
            }
        }
        public void update()
        {
            double ile = model.CountRows().Count;
            if (ile > 0)
            {
                double ilestron = Convert.ToDouble(Math.Ceiling(ile / 4));
                ile = (Convert.ToDouble(NumerStrony.Text) / ilestron);
               
            }


            progressbar.ProgressTo(ile, 500, Easing.Linear);
            listaOsob.ItemsSource = null;
            listaOsob.ItemsSource = model.pobierzListe(searchBar.Text, Convert.ToInt32(NumerStrony.Text));
        }

        private void Prawo(object sender, EventArgs e)
        {
            NumerStrony.Text = (System.Convert.ToInt32(NumerStrony.Text) + 1).ToString();
            List<Osoba> ListaSource = model.pobierzListe(searchBar.Text, Convert.ToInt32(NumerStrony.Text));
            update();
            if (ListaSource.Count == 0)
            {
                NumerStrony.Text = (System.Convert.ToInt32(NumerStrony.Text) - 1).ToString();
                update();
            }
            update();


        }


        private void Lewo(object sender, EventArgs e)
        {
            if (System.Convert.ToInt32(NumerStrony.Text) >= 2)
            {
                NumerStrony.Text = (System.Convert.ToInt32(NumerStrony.Text) - 1).ToString();
            }
            update();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            NumerStrony.Text = "1";
            listaOsob.ItemsSource = null;
            listaOsob.ItemsSource = model.pobierzListe(searchBar.Text, Convert.ToInt32(NumerStrony.Text));
        }

        private async void NowaBaza(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Stworzenie nowej bazy", "Czy chcesz stworzyc nowa baze?", "Tak", "Nie");
            if (answer)
            {
                model.Newbaza();
                model.pobierzListe(searchBar.Text, Convert.ToInt32(NumerStrony.Text));
                await DisplayAlert("Operacja zakończona sukcesem", "Nowa baza zostala stworzona", "OK");
                update();
            }
            else
            {
                await DisplayAlert("Operacja przerwana", "Stworzenie nowej bazy zostało przerwane", "OK");

            }


        }
    }
}