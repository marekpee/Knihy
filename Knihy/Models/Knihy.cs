using Microsoft.AspNetCore.Components.Routing;

namespace Knihy.Models
{
    public class Knihy
    {
        public List<Informace> KnizkyList = new List<Informace>();
        public Informace Informace = new Informace();
        public string Vypis { get; set; } = "";
        public bool IsEditace { get; set; } = false;
        public bool NalezenaKniha { get; set; } = false;
        public void Pridat()
        {
            // Najdeme knihu se stejným názvem
            Informace existujiciKniha = KnizkyList.FirstOrDefault(k => k.Nazev == Informace.Nazev);

            if (existujiciKniha != null)
            {
                // Pokud kniha existuje, zvýšíme počet kusů o 1
                existujiciKniha.PocetKusu += 1;
            }
            else
            {
                // Pokud kniha neexistuje, přidáme novou knihu do seznamu
                KnizkyList.Add(new Informace(Informace.Nazev, 1, Informace.Autor, Informace.Rok, Informace.Zanr, Informace.ISBN, Informace.Uskladneni));
            }
        }
        public void ZobrazVse()
        {
            Vypis = $"Seznam knih v knihovně: <br> {string.Join("<br>", KnizkyList)}";
        }
        public void Edituj(Informace inf)
        {
            Informace = inf;
            IsEditace = true;
        }
        public void UkonciEditaci() 
        {
            IsEditace = false;
            Informace = new Informace();
        }
        public void SmazatPolozku(Informace pol) 
        {
            if (pol.PocetKusu == 1)
            {
                KnizkyList.Remove(pol);
            }
            else
            {
                pol.PocetKusu--;
            }

        }
        public void VyhledejKnihu()
        {
            foreach (var item in KnizkyList)
            {
                if (item.Nazev == Informace.Vyhledat)
                {
                    Vypis = $"Hledaná kniha: Název: {item.Nazev} - Počet kusů: {item.PocetKusu} - Autor: {item.Autor} - Rok vydání: {item.Rok} - Žánr: {item.Zanr} - ISBN: {item.ISBN} - Uskladnění: {item.Uskladneni}";
                    NalezenaKniha = true;
                }
            }
            if (NalezenaKniha == false)
            {
                Vypis = $"nemame";
            } else if (NalezenaKniha == true)
            {
                NalezenaKniha = false;
            }
           
        }
    }
}
