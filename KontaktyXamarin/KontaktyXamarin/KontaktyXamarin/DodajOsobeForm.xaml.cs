using System;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KontaktyXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodajOsobeForm : ContentPage
    {
        MainFlyoutPage Main1;
        Osoba osoba = new Osoba();
        Model model = new Model();
        public string plec;

        public DodajOsobeForm(MainFlyoutPage Main1)
        {
            InitializeComponent();
            WojewodztwaPicker.SelectedIndex = 0;
            this.Main1 = Main1;

        }

        private void DodajOsobe(object sender, EventArgs e)
        {
            if (ImieInput.Text != "" && NazwiskoInput.Text != "" && KodPocztowyInput.Text != "" && NumerTelefonuInput.Text != null )
            {
                if ((Regex.IsMatch(ImieInput.Text, "^([A-Z][a-z]{1,})$")) && (Regex.IsMatch(NazwiskoInput.Text, "^([A-Z][a-z]{1,})$")) && (Regex.IsMatch(KodPocztowyInput.Text, "^[0-9]{2}-[0-9]{3}$")) && (Regex.IsMatch(NumerTelefonuInput.Text, "^[0-9]{9}$")))
                {

                    if (ManRadio.IsChecked == true)
                    { plec = "Mężczyzna"; }
                    else { plec = "Kobieta"; }
                    osoba.imie = ImieInput.Text;
                    osoba.nazwisko = NazwiskoInput.Text;
                    osoba.kodpocztowy = KodPocztowyInput.Text;
                    osoba.telefon = Convert.ToInt32(NumerTelefonuInput.Text);
                    osoba.wojewodztwo = WojewodztwaPicker.SelectedItem.ToString();
                    osoba.plec = plec;
                    model.dodajOsobe(osoba);
                    Main1.update();
                    Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "Proszę wpisać poprawne dane", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Proszę wypełnić cały formularz", "OK");
            }
        }

        private void ImieInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(ImieInput.Text, "^([A-Z][a-z]{1,})$") && ImieInput.Text != "")
            {
                osoba.imie = ImieInput.Text;
                ImieInput.BackgroundColor = Color.Gray;
            }
            else
            {
                ImieInput.BackgroundColor = Color.Red;
            }
        }

        private void NazwiskoInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(NazwiskoInput.Text, "^([A-Z][a-z]{1,})$") && NazwiskoInput.Text != "")
            {
                osoba.imie = NazwiskoInput.Text;
                NazwiskoInput.BackgroundColor = Color.Gray;
            }
            else
            {
                NazwiskoInput.BackgroundColor = Color.Red;
            }
        }

        private void KodPocztowyInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(KodPocztowyInput.Text, "^[0-9]{2}-[0-9]{3}$") && KodPocztowyInput.Text != "")
            {
                osoba.imie = KodPocztowyInput.Text;
                KodPocztowyInput.BackgroundColor = Color.Gray;
            }
            else
            {
                KodPocztowyInput.BackgroundColor = Color.Red;
            }
        }

        private void NumerTelefonuInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(NumerTelefonuInput.Text, "^[0-9]{9}$") && NumerTelefonuInput.Text != "")
            {
                osoba.imie = NumerTelefonuInput.Text;
                NumerTelefonuInput.BackgroundColor = Color.Gray;
            }
            else
            {
                NumerTelefonuInput.BackgroundColor = Color.Red;
            }
        }

        private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkbox.IsChecked)
            {
                button.IsEnabled = true;
            }
            else
            {
                button.IsEnabled = false;
            }
        }
    }
}