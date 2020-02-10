using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
        where T : IComparable
    {
       

        public Box()
        {
            this.Values = new List<T>();
        }

        public List<T> Values { get; set; }

        public int CountGreaterValues(T targetItem)
        {
            int counter = 0;
            foreach (var value in this.Values)
            {
                if (value.CompareTo(targetItem) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public void Swap(int index1,int index2)
        {
            T tempValue = this.Values[index1];
            this.Values[index1] = this.Values[index2];
            this.Values[index2] = tempValue;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Values)
            {
                sb.AppendLine(($"{item.GetType()}: {item}"));
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

    }
}
