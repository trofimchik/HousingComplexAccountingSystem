using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexPractice.Helpers
{
    public static class StaticData
    {
        public static Complex SelectedComplex { get; set; }
        public static ObservableCollection<Complex> SavedComplexes { get; set; }

        public static List<Complex> AllComplexCollection { get; set; } = ImportExcel.GetList();

        public static bool Change { get; set; } = false;
        //public static string Name { get; set; }
        //public static string Condition { get; set; }
        //public static string Address { get; set; }
        //public static string Building { get; set; }
        //public static string Appartment { get; set; }
        //public static int NumberOfRooms { get; set; }
        //public static int Entrance { get; set; }
        //public static int Space { get; set; }
        //public static double Price { get; set; }
        //public static int Floor { get; set; }
        //public static string AppartmentCondition { get; set; }
    }
}
