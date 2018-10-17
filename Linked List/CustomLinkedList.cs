using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE13_LinkedLists
{
    class CustomLinkedList
    {
        private CustomLinkedNode head;
        private int count;

        public int Count { get { return count; } }

        public CustomLinkedList()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Adds a string to the end of the list
        /// </summary>
        public void Add(string data)
        {
            if (count == 0)
                head = new CustomLinkedNode(data);
            else
            {
                CustomLinkedNode current = head;
                for (int i = 0; i < count - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = new CustomLinkedNode(data);
            }

            count++;
        }

        /// <summary>
        /// Gets the data at a specified index
        /// </summary>
        public string GetData(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            else
            {
                CustomLinkedNode current = head;
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Data; 
            }
        }
    }
}
