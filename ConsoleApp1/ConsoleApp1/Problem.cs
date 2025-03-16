using ConsoleApp1;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("UnitTest")]

namespace ConsoleApp1
{
    public class Problem
    {
        struct Item
        {
            public int value;
            public int wage;
            public int ID;

            public int getValue()
            {
                return value;
            }
            public float Ratio
            {
                get { return (float)value / wage; }
            }
        }


        private List<Item> _itemsList = new List<Item>();

        public Problem(int n, int seed)
        {
            Random random = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                _itemsList!.Add(new Item { ID = i, value = random.Next(1, 10), wage = random.Next(1, 10) });
            }
        }

        public override string ToString()
        {
            string returnString = "";
            foreach (var value in _itemsList)
            {
                returnString += $"no.: {value.ID} v: {value.value} w: {value.wage}\n";
            }

            return returnString;
        }

        public Result Solve(int capacity)
        {
            Result result = new Result();

            var sortedItems = _itemsList.OrderByDescending(i => i.Ratio).ToList();

            foreach (var i in sortedItems)
            {
                if (i.wage <= capacity)
                {
                    result.itemsInSuc.Add(i.ID);
                    result.valueSum += i.value;
                    result.wageSum += i.wage;
                    capacity -= i.wage;
                    //Console.WriteLine($"{i.ID} {i.value} {i.wage} {i.Ratio}");
                }
                else
                {
                    continue;
                }
            }


            return result;
        }
    }
}