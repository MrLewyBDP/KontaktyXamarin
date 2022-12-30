using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;

namespace KontaktyXamarin
{
    public class Model
    {
        private SQLiteConnection connection;
    
        public Model()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "osoby.db");
            connection = new SQLiteConnection(databasePath);
            connection.CreateTable<Osoba>();
        }
        ~Model()
        {
            connection.Close();
        }
        public void dodajOsobe(Osoba nowaOsoba)
        {
            connection.Execute($@"INSERT INTO osoby (imie, nazwisko, kodpocztowy, telefon, wojewodztwo, plec) VALUES ('{nowaOsoba.imie}', '{nowaOsoba.nazwisko}', '{nowaOsoba.kodpocztowy}', '{nowaOsoba.telefon}', '{nowaOsoba.wojewodztwo}', '{nowaOsoba.plec}')");
        }

        public void usunOsobe(int osobaId)
        {
            connection.Execute($@"DELETE FROM osoby WHERE _id='{osobaId}'");
        }
        public void Newbaza()
        {
            connection.Execute("DROP TABLE osoby");
            connection.CreateTable<Osoba>();
        }
        public void edytujOsobe(Osoba osoba)
        {
            connection.Execute($@"UPDATE osoby SET imie='{osoba.imie}', nazwisko='{osoba.nazwisko}', kodpocztowy='{osoba.kodpocztowy}', telefon={osoba.telefon}, wojewodztwo='{osoba.wojewodztwo}', plec='{osoba.plec}' WHERE _id='{osoba.osoba_id}'");
        }

        public List<Osoba> pobierzListe(string osobaDoWyszukana, int strona)
        {
            
     
            int offset = 4 * (strona-1);
            var listaOsob = connection.Query<Osoba>($"SELECT * FROM osoby WHERE (imie LIKE '%{osobaDoWyszukana}%' OR nazwisko LIKE '%{osobaDoWyszukana}%') ORDER BY imie LIMIT 4 OFFSET {offset}");
            return listaOsob;
        }
        public List<Osoba> CountRows()
        {
            var listaOsob = connection.Query<Osoba>($"SELECT * FROM osoby");
            return listaOsob;
        }
    }
}
