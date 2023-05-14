using System;

namespace SlutprojektNy
{


    public class NyBil : Bil
    {

        public NyBil(string skapare, string model, int år, double pris) : base(skapare, model, år, pris)
        {
            Pris *= 1.25; //25% dyrare för att den är ny
        }
    }

}
