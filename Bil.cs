using System;

namespace SlutprojektNy
{


    public class Bil
    {

         // Egenskaper för bilen. Skapare,bilens model, år den är från, Pris, och en bool om den har blivit sold
        public string Skapare { get; set; }
        public string Model { get; set; }
        public int År { get; set; }
        public double Pris { get; set; }
        public bool ärSåld { get; set; }
// En constructor som tar in skapare, modell, årtal och pris för en ny bil och sätter "ärSåld" till false som standard
        public Bil(string skapare, string model, int år, double pris)
        {
            Skapare = skapare;
            Model = model;
            År = år;
            Pris = pris;
            ärSåld = false;
        }
// Metod som sätter "ärSåld" till true för en bil som har blivit såld
        public void Såld()
        {
            ärSåld = true;

        }
// override av ToString() metoden för att returnera en sträng som beskriver bilen
        public override string ToString()
        {
            return $"{År} {Skapare} {Model} ({Pris:C})";
        }
    }
}

