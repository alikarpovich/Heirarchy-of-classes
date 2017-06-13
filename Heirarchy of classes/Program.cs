using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heirarchy_of_classes
{
    abstract class Worker
    {
        public string name { get; set; }
        public string fam { get; set; }
        public string birth { get; set; }
        public Worker(string s1, string s2, string s3)
        {
            name = s1;
            fam = s2;
            birth = s3;
        }
        virtual public void WriteWorker()
        {
            Console.WriteLine("\nWorker\n" + name + "\n" + fam + "\n" + birth);
        }
        virtual public int Sall() { return -1; }
    }
    class HourWorker : Worker
    {
        int hour;
        int perhour;
        public HourWorker(int o, int p, string w1, string w2, string w3) : base(w1, w2, w3)
        {
            hour = o;
            perhour = p;
        }
        public HourWorker(int o, int p, Worker w) : base(w.name, w.fam, w.birth)
        {
            hour = o;
            perhour = p;
        }
        public override void WriteWorker()
        {
            base.WriteWorker();
            Console.WriteLine("Per hour: " + perhour.ToString() + "\nNumber of hours: " + hour.ToString() + "\n");
        }
        public override int Sall()
        {
            return hour * perhour;
        }
    }
    class MonthWorker : Worker
    {
        int month;
        public MonthWorker(int m, Worker w) : base(w.name, w.fam, w.birth)
        {
            month = m;
        }
        public MonthWorker(int m, string w1, string w2, string w3) : base(w1, w2, w3)
        {
            month = m;
        }
        public override void WriteWorker()
        {
            base.WriteWorker();
            Console.WriteLine("Per month: " + month.ToString() + "\n");
        }
        public override int Sall()
        {
            return month;
        }
    }
    class DealWorker : Worker
    {
        int deal;
        public DealWorker(int d, string w1, string w2, string w3) : base(w1, w2, w3)
        {
            deal = d;
        }
        public DealWorker(int d, Worker w) : base(w.name, w.fam, w.birth)
        {
            deal = d;
        }
        public override void WriteWorker()
        {
            base.WriteWorker();
            Console.WriteLine("Sallary by deal: " + deal.ToString() + "\n");
        }
        public override int Sall()
        {
            return deal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            void SortName(ref Worker[] mas, int n)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < i; j++)
                    {
                        if (string.Compare(mas[i].name, mas[j].name) < 0)
                        {
                            Worker tmp = mas[j];
                            mas[j] = mas[i];
                            mas[i] = tmp;
                        }
                    }
            }
            void Print(Worker[] mas, int n)
            {
                Console.WriteLine("List");
                for (int i = 0; i < n; i++)
                    mas[i].WriteWorker();
            }
            void SumSall(Worker[] mas, int n)
            {
                int sall = 0;
                for (int i = 0; i < n; i++)
                {
                    sall += mas[i].Sall();
                }
                Console.WriteLine("\nSummary sallary of the brigade: " + sall.ToString() + "\n");
            }
            void DiffSall(Worker wo1, Worker wo2)
            {
                Console.WriteLine("Difference of the sallary of {0} {1} and {2} {3} is {4}\n", wo1.name, wo1.fam, wo2.name, wo2.fam, wo1.Sall() - wo2.Sall());
            }
            void Discharge(ref Worker[] mas, ref int n, int i)
            {
                i--;
                if (i >= n)
                {
                    Console.WriteLine("Out of range");
                    return;
                }
                Console.WriteLine("Worker {0} {1} has been discharged. The sallary for 2 months - {2}\n", mas[i].name, mas[i].fam, 2 * mas[i].Sall());
                for (int j = i; j < n; j++)
                {
                    mas[j] = mas[j + 1];
                }
                mas[n - 1] = null;
                n--;
            }
            void SallForPeriod(Worker wo, int k)
            {
                Console.WriteLine("Sallary for {0} months for {1} {2}: {3}\n", k, wo.name, wo.fam, wo.Sall() * k);
            }
            void CompareWorker(Worker wo1, Worker wo2)
            {
                if (wo1.Sall() > wo2.Sall())
                    Console.WriteLine("The sallary of the worker {0} {1} ({2}) is more than the sallary of the worker {3} {4} ({5})\n", wo1.name, wo1.fam, wo1.Sall(), wo2.name, wo2.fam, wo2.Sall());
                else if (wo1.Sall() < wo2.Sall())
                    Console.WriteLine("The sallary of the worker {0} {1} ({2}) is more than the sallary of the worker {3} {4} ({5})\n", wo2.name, wo2.fam, wo2.Sall(), wo1.name, wo1.fam, wo1.Sall());
                else Console.WriteLine("The sallary of the worker {0} {1} ({2}) is equal to the sallary of the worker {3} {4} ({5})\n", wo1.name, wo1.fam, wo1.Sall(), wo2.name, wo2.fam, wo2.Sall());
            }
            
            HourWorker ou1 = new HourWorker(120, 15, "Alina", "Karpovich", "06.10.98");
            MonthWorker mw1 = new MonthWorker(1200, "Ivan", "Mozolyuk", "20.09.98");
            DealWorker dw1 = new DealWorker(1000, "Diana", "Kulich", "04.09.99");
            Worker[] wmas = new Worker[20];
            wmas[0] = ou1;
            wmas[1] = mw1;
            wmas[2] = dw1;
            for (int i = 0; i < 3; i++)
                wmas[i].WriteWorker();
            wmas[3] = new HourWorker(150, 13, "Anton", "Z", "11.03.97");
            wmas[4] = new HourWorker(190, 12, "Anna", "Yakubovich", "26.06.98");
            wmas[5] = new DealWorker(1300, "Maksim", "Ivashkov", "01.01.98");
            wmas[6] = new MonthWorker(1300, "Vlad", "Osipenko", "18.11.98");
            int num = 7;
            SortName(ref wmas, num);
            Print(wmas, num);
            SumSall(wmas, num);
            DiffSall(wmas[1], wmas[0]);
            Discharge(ref wmas, ref num, 3);
            SallForPeriod(wmas[4], 5);
            CompareWorker(wmas[2], wmas[5]);
            CompareWorker(wmas[4], wmas[5]);
        }
    }
}
