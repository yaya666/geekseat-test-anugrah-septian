using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public class Villager
        {
            public int AgeOfDeath { get; set; }
            public int YearOfDeath { get; set; }
            public bool IsDataVald()
            {
                return YearOfDeath > AgeOfDeath;
            }

            internal decimal CountNumberPeopleOfKilled()
            {
                return SumPrimeNumber(this.YearOfDeath - this.AgeOfDeath);
            }

            private int SumPrimeNumber(int num)
            {
                List<int> numbers = new List<int> { 1,1 };
                int result = 0;
                if (num == 1)
                {
                    return 1;
                }
                else if (num == 2)
                {
                    return 2;
                }
                else
                {
                    for (int i = 2; i < num; i++)
                    {
                        numbers.Add(numbers[i-1]+numbers[i-2]);
                    }

                    foreach (var item in numbers)
                    {
                        result += item;
                    }

                    return result;
                }
            }
        }

        public class Villagers
        {
            public void AddVillager(Villager villager)
            {
                this.VillagerList.Add(villager);
            }
            public List<Villager> VillagerList = new List<Villager>();
            public decimal AverageDeath()
            {
                decimal result = 0;
                foreach (var villager in this.VillagerList)
                {
                    if (!villager.IsDataVald())
                    {
                        return -1;
                    }

                    result += villager.CountNumberPeopleOfKilled();
                }

                return result / this.VillagerList.Count;
            }

        }
        static void Main(string[] args)
        {
            var villager1 = new Villager();
            villager1.AgeOfDeath = 10;
            villager1.YearOfDeath = 12;

            var villager2 = new Villager();
            villager2.AgeOfDeath = 13;
            villager2.YearOfDeath = 17;

            var villagers = new Villagers();
            villagers.AddVillager(villager1);
            villagers.AddVillager(villager2);

            decimal averageDeath = villagers.AverageDeath();
            Console.WriteLine(averageDeath);
            Console.ReadLine();
        }
    }
}
