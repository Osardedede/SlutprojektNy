using System;

namespace SlutprojektNy
{


    public class LyxBil : NyBil
    {
        public int AntalExemplar { get; set; }

        public LyxBil(string skapare, string model, int år, double pris, int antalExemplar) : base(skapare, model, år, pris)
        {
            AntalExemplar = antalExemplar;
            
        }

        public override string ToString()
        {
            return base.ToString() + $"Det finns bara {AntalExemplar} bilar av den här modellen i världen";
        }
    }

}