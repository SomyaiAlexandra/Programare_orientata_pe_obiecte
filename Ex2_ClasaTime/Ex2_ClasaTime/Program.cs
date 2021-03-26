using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_ClasaTime
{
    class Time
    {
        int ore;
        int minute;
        int secunde;
        int sutimi;
        public Time(int ore, int minute, int secunde, int sutimi)
        {
            this.ore = ore;
            this.minute = minute;
            this.secunde = secunde;
            this.sutimi = sutimi;
        }
        public Time(int ore, int minute, int secunde)
        {
            this.ore = ore;
            this.minute = minute;
            this.secunde = secunde;
        }
        public Time(int ore, int minute)
        {
            this.ore = ore;
            this.minute = minute;
        }
        public Time() { }
        public Time(string n)
        {
            string[] x = new string[4];
            x = n.Split(':');
            this.ore = Convert.ToInt32(x[0]);
            this.minute = Convert.ToInt32(x[1]);
            this.secunde = Convert.ToInt32(x[2]);
            this.sutimi = Convert.ToInt32(x[3]);
        }
        public static void conversie(Time c)
        {
            //Am folosit milisecunde pentru ca in exprimarea orei nu exista sutimi.
            while (c.sutimi > 1000)
            {
                c.secunde++;
                c.sutimi -= 1000;
            }
            while (c.secunde > 60)
            {
                c.minute++;
                c.secunde -= 60;
            }
            while (c.minute > 60)
            {
                c.ore++;
                c.minute -= 60;
            }
            //Am folosit in notatia timpului 24 de ore.
            if (c.ore > 25)
                c.ore -= 24;

        }
        public static Time operator -(Time a, Time b)
        {
            Time res = new Time();
            res.ore = Math.Abs(a.ore - b.ore);
            res.minute = Math.Abs(a.minute - b.minute);
            res.secunde = Math.Abs(a.secunde - b.secunde);
            res.sutimi = Math.Abs(a.sutimi - b.sutimi);
            conversie(res);
            return res;

        }
        public static Time operator +(Time a, Time b)
        {
            Time res = new Time();
            res.ore = Math.Abs(a.ore + b.ore);
            res.minute = Math.Abs(a.minute + b.minute);
            res.secunde = Math.Abs(a.secunde + b.secunde);
            res.sutimi = Math.Abs(a.sutimi + b.sutimi);
            conversie(res);
            return res;

        }
        public static bool operator ==(Time a, Time b)
        {
            if ((a.ore == b.ore) && (a.minute == b.minute) && (a.secunde == b.secunde) && (a.sutimi == b.sutimi))
                return true;
            return false;
        }
        public static bool operator !=(Time a, Time b)
        {
            if (a == b)
                return false;
            return true;
        }
        public static bool operator <(Time a, Time b)
        {
            if (a.ore < b.ore)
                return true;
            if ((a.ore == b.ore) && (a.minute < b.minute))
                return true;
            if ((a.ore == b.ore) && (a.minute == b.minute) && (a.secunde < b.secunde))
                return true;
            if ((a.ore == b.ore) && (a.minute == b.minute) && (a.secunde == b.secunde) && (a.sutimi < b.sutimi))
                return true;
            return false;
        }
        public static bool operator <=(Time a, Time b)
        {
            if (a < b || a == b)
                return true;
            return false;
        }
        public static bool operator >(Time a, Time b)
        {
            if (a <= b)
                return false;
            return true;
        }
        public static bool operator >=(Time a, Time b)
        {
            if (a < b)
                return false;
            return true;
        }

        public static void afis(Time d)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", d.ore, d.minute, d.secunde, d.sutimi);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(14, 22, 27, 1200);
            Time t2 = new Time(15, 30, 25, 900);
            Console.Write("Ora1=");
            Time.afis(t1);
            Console.Write("Ora2=");
            Time.afis(t2);
            Console.Write("Diferenta dintre timpi este:");
            Time.afis(t1 - t2);
            Console.Write("Suma dintre timpi este:");
            Time.afis(t1 + t2);
            if (t1 == t2)
                Console.Write("Orele coincid");
            else if (t1 < t2)
                Console.Write("Ora1 este anterioara orei2");
            else
                Console.Write("Ora2 este anterioara orei1");
            Console.ReadKey();
        }
    }
}
