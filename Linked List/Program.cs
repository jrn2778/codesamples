using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE13_LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList myList = new CustomLinkedList();

            myList.Add("Hello!");
            myList.Add("This");
            myList.Add("is");
            myList.Add("my");
            myList.Add("list.");

            for(int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.GetData(i));
            }
        }
    }
}
