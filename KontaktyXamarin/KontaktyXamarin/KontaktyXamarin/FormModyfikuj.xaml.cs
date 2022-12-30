using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KontaktyXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormModyfikuj : ContentPage
    {
        public MainFlyoutPage MainFlyoutPage;
        Osoba osoba = new Osoba();
        public Model model= new Model();
        MainFlyoutPage Main1;
        public string Plec;
        public FormModyfikuj(MainFlyoutPage MainFlyoutPage, Osoba osoba)
        {
            InitializeComponent();
            this.Main1 = MainFlyoutPage;
            this.osoba = osoba;
            ImieInput.Text = osoba.imie;
            NazwiskoInput.Text = osoba.nazwisko;
            KodPocztowyInput.Text = osoba.kodpocztowy;
            NumerTelefonuInput.Text = osoba.telefon.ToString();
            WojewodztwaPicker.SelectedItem = osoba.wojewodztwo;
            if (osoba.plec.Contains("Mężczyzna"))
            { ManRadio.IsChecked = true; }
            else { WomanRadio.IsChecked = true; }
        }
        private void EdytujOsobe(object sender, System.EventArgs e)
        {

            if (ImieInput.Text != "" && NazwiskoInput.Text != "" && KodPocztowyInput.Text != "" && NumerTelefonuInput.Text.ToString() != "")
            {
                if ((Regex.IsMatch(ImieInput.Text, "^([A-Z][a-z]{1,})$")) && (Regex.IsMatch(NazwiskoInput.Text, "^([A-Z][a-z]{1,})$")) && (Regex.IsMatch(KodPocztowyInput.Text, "^[0-9]{2}-[0-9]{3}$")) && (Regex.IsMatch(NumerTelefonuInput.Text, "^[0-9]{9}$")))
                {
                
                    if (ManRadio.IsChecked == true)
                    { Plec = "Mężczyzna"; }
                    else { Plec = "Kobieta"; }

                    osoba.imie = ImieInput.Text;
                    osoba.nazwisko = NazwiskoInput.Text;
                    osoba.kodpocztowy = KodPocztowyInput.Text;
                    osoba.telefon = Convert.ToInt32(NumerTelefonuInput.Text);
                    osoba.wojewodztwo = WojewodztwaPicker.SelectedItem.ToString();
                    osoba.plec = Plec;
                    if (osoba != null)
                    {
                        model.edytujOsobe(osoba);
                        Main1.update();
                        Application.Current.MainPage.Navigation.PopAsync();
                    }                
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