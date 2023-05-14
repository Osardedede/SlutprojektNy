using System;

namespace SlutprojektNy
{


    public class AnvändBil : Bil
    {

        public int AntalMil { get; set; }

        public AnvändBil(string skapare, string model, int år, double pris, int antalMil) : base(skapare, model, år, pris)
        {
            AntalMil = antalMil;
            prisRäknare();
        }

        public override string ToString()
        {
            return base.ToString() + $" ({AntalMil:N0} miles)";
        }

        public void prisRäknare()
        {
            Pris -= (AntalMil/10);
        }
    }


}