using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OroklesGyak2
{
    interface IArlap
    {
        double mennyibeKerul();
    }

    abstract class Peksutemeny : IArlap
    {
        protected int mennyiseg;
        public int alapAr;

        protected Peksutemeny(int mennyiseg, int alapAr)
        {
            this.mennyiseg = mennyiseg;
            this.alapAr = alapAr;
        }
        public abstract void Megkostol();

        public double mennyibeKerul()
        {
            return this.alapAr * mennyiseg;
        }

        public override string ToString()
        {
            return $"{mennyiseg} db - {mennyibeKerul()} Ft";
        }
    }

    class Pogacsa : Peksutemeny
    {
        public Pogacsa(int mennyiseg, double alapAr) : base(mennyiseg, alapAr)
        {

        }
        public override void Megkostol()
        {
            mennyiseg /= 2;
        }
        public override string ToString()
        {
            return $"Pogácsa " + base.ToString(); //{mennyiseg} db - {mennyibeKerul()} Ft";
        }
    }

    class Kave : IArlap
    {
        private bool habosE;
        const int CSESZEKAVE = 100;

        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

        public double mennyibekerul()
        {
            if (habosE)
            {
                return CSESZEKAVE = 1.5;
            }
            else
            {
                return CSESZEKAVE;
            }
        }
        public override string ToString()
        {
            return $"{(habosE ? "Habos" : "Nem habos")} kave - {mennyibekerul()} Ft";
        }
    }

    internal class Futtato
    {
        static List<IArlap> arlap = new List<IArlap>();
        static void Vasarlok(string utvonal)
        {
            StreamReader sr = new StreamReader(utvonal);
            while(!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                if (true)
                {
                    arlap.Add(new Pogacsa(int.Parse(temp[1]), double.Parse(temp[2])));
                }
                else
                {
                    arlap.Add(new Kave(temp[1] == "habos" ? true : false));
                }
            }

            sr.Close();
        }
        static void Main(string[] args)
        {

        }
    }
}
