using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KontaktyXamarin
{
    [Table("osoby")]
    public class Osoba
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int osoba_id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string kodpocztowy { get; set; }
        public int telefon { get; set; }
        public string wojewodztwo { get; set; }
        public string plec { get; set; }

        public Osoba(string imie, string nazwisko, string kodpocztowy, int telefon, string wojewodztwo, string plec)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.kodpocztowy = kodpocztowy;
            this.telefon = telefon;
            this.wojewodztwo = wojewodztwo;
            this.plec = plec;
        }
        public Osoba()
        {

        }
    }
}
