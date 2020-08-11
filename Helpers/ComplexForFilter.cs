using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexPractice.Helpers
{
    class ComplexForFilter
    {
        private static List<string> name = new List<string>();
        public static List<string> Name
        {
            get
            {
                return name;
            }
            set
            { 
                name = value; 
            }
        }
        private static List<string> address = new List<string>();
        public static List<string> Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        private static List<string> floor = new List<string>();
        public static List<string> Floor
        {
            get
            {
                return floor ;
            }
            set
            {
                floor = value;
            }
        }
        private static List<string> entrance = new List<string>();
        public static List<string> Entrance
        {
            get
            {
                return entrance;
            }
            set
            {
                entrance = value;
            }
        }
        private static List<string> appartmentStatus = new List<string>();
        public static List<string> AppartmentStatus
        {
            get
            {
                return appartmentStatus;
            }
            set
            {
                appartmentStatus = value;
            }
        }
    }
}
