using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE13_LinkedLists
{
    class CustomLinkedNode
    {
        private string data;
        private CustomLinkedNode next;

        public string Data { get { return data; } set { data = value; } }
        public CustomLinkedNode Next { get { return next; } set { next = value; } }

        public CustomLinkedNode(string data)
        {
            this.data = data;
            next = null;
        }
    }
}
