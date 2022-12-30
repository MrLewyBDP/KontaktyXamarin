using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KontaktyXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SzczegolyOsobyForm : ContentPage
    {
        Osoba osoba;
        public SzczegolyOsobyForm(Osoba osoba)
        {
            InitializeComponent();
            this.osoba = osoba;
            ImieInput.Text = osoba.imie;
            NazwiskoInput.Text = osoba.nazwisko;
            KodPocztowyInput.Text = osoba.kodpocztowy;
            NumerTelefonuInput.Text = osoba.telefon.ToString();
            WojewodztwaPicker.SelectedItem = osoba.wojewodztwo;
            if (osoba.plec.Contains("Menżczyzna"))
            { ManRadio.IsChecked = true; }
            else { WomanRadio.IsChecked = true; }
        }
    }
}