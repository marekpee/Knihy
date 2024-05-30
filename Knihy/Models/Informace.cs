namespace Knihy.Models
{
    public class Informace
    {
        private string uskladneni = "";

        public Informace()
        {
        }

        public Informace(string nazev, int pocetKusu, string autor, int rok, string zanr, string iSBN, int uskladneni)
        {
            Nazev = nazev;
            PocetKusu = pocetKusu;
            Autor = autor;
            Rok = rok;
            Zanr = zanr;
            ISBN = iSBN;
            Uskladneni = uskladneni;
        }

        public string Nazev { get; set; } = "";
        public int PocetKusu { get; set; }
        public string Autor { get; set; } = "";
        public int Rok { get; set; }
        public string Zanr { get; set; } = "";
        public string ISBN { get; set; }
        public int Uskladneni
        {
            get => Uskladneni;
            set
            {
                if (Uskladneni != value)
                {
                    if (value >= 0 || value <=10)
                    {
                        Uskladneni = value;
                    } else 
                    {
                        Uskladneni = 0;
                    }
                }
            }
        }
        
        //public string Uskladneni { get; set; } = "";
        public string Vyhledat { get; set; } = "";
        public override string ToString()
        {
            return $"Název: {Nazev} - Počet kusů: {PocetKusu} - Autor: {Autor} - Rok vydání: {Rok} - Žánr: {Zanr} - ISBN: {ISBN} - Uskladnění: {Uskladneni}";
        }
    }
}
