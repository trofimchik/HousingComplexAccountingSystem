using ComplexPractice.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexPractice
{
    public class Complex : PropertyChangedBase, IDataErrorInfo
    {
        private string name;
        private string condition; //
        private string address;
        private string building;
        private int appartment;
        private int numberOfRooms;
        private int entrance;
        private double space;//
        private double price;//
        private int floor;
        private string appartmentCondition;

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Name": 
                        if (string.IsNullOrEmpty(Name)) result = "Введите чо-нить!";
                        else if(Name.Length > 50) result = "Слишком большое название, ты где такие видел?";
                        break;
                    case "Floor":
                        if (Floor == default) result = "Введите чо-нить!";
                        else if (Floor > 200) result = "Слишком много этажей, ты где такие дома видел?";
                        else if (Floor <= 0) result = "Ты че ебанутый? Шо ты там делаешь?";
                        break;
                        //case "Price": if ((Price < 10) || (Price > 1000)) result = "Price must be between 10 and 1000"; break;
                        //case "Amount": if ((Amount < 1) || (Amount > 100)) result = "Amount must be between 1 and 100"; break;
                };
                return result;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public string Building
        {
            get
            {
                return building;
            }
            set
            {
                building = value;
                OnPropertyChanged();
            }
        }
        public int Appartment
        {
            get
            {
                return appartment;
            }
            set
            {
                appartment = value;
                OnPropertyChanged();
            }
        }
        public int NumberOfRooms
        {
            get
            {
                return numberOfRooms;
            }
            set
            {
                numberOfRooms = value;
                OnPropertyChanged();
            }
        }
        public int Entrance
        {
            get
            {
                return entrance;
            }
            set
            {
                entrance = value;
                OnPropertyChanged();
            }
        }
        public double Space
        {
            get
            {
                return space;
            }
            set
            {
                space = value;
                OnPropertyChanged();
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
                OnPropertyChanged();
            }
        }
        public string AppartmentCondition
        {
            get
            {
                return appartmentCondition;
            }
            set
            {
                appartmentCondition = value;
                OnPropertyChanged();
            }
        }
    }
}
