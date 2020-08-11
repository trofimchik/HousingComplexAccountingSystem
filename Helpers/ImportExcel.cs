using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace ComplexPractice.Helpers
{
    static class ImportExcel
    {
        public static List<Complex> GetList()
        {
            List<Complex> maping = new List<Complex>();


            string pathTemplate = Path.GetTempFileName();
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream input = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.DataCopyFixed.xlsx"))
            using (Stream output = File.Create(pathTemplate))
            {
                input.CopyTo(output);
            }


            Excel.Application objWorkExcel = new Excel.Application();
            //objWorkExcel.DisplayAlerts = false;
            //ObjWorkExcel.Visible = true;
            Excel.Workbook objWorkBook = objWorkExcel.Workbooks.Open(pathTemplate);
            Excel.Worksheet objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[1];

            int row = 1;
            while (objWorkSheet.Cells[row + 1, 1].Value != null)
            {
                maping.Add(new Complex
                {
                    Name = objWorkSheet.Cells[row + 1, 1].Text.ToString(),
                    Condition = objWorkSheet.Cells[row + 1, 2].Text.ToString(),
                    Address = objWorkSheet.Cells[row + 1, 3].Text.ToString(),
                    Building = objWorkSheet.Cells[row + 1, 4].Text.ToString(),
                    Appartment = Convert.ToInt32(objWorkSheet.Cells[row + 1, 5].Text),
                    NumberOfRooms = Convert.ToInt32(objWorkSheet.Cells[row + 1, 6].Text),
                    Entrance = Convert.ToInt32(objWorkSheet.Cells[row + 1, 7].Text),
                    Space = Convert.ToDouble(objWorkSheet.Cells[row + 1, 8].Text),
                    Price = Convert.ToDouble(objWorkSheet.Cells[row + 1, 9].Text),
                    Floor = Convert.ToInt32(objWorkSheet.Cells[row + 1, 10].Text),
                    AppartmentCondition = objWorkSheet.Cells[row + 1, 11].Text.ToString()
                });
                row++;
            }

            maping.Sort((x, y) =>
            {
                int r = x.Name.CompareTo(y.Name);
                if (r == 0)
                {
                    r = x.Address.CompareTo(y.Address);
                    if (r == 0)
                    {
                        r = x.Building.CompareTo(y.Building);
                    }
                }
                return r;
            });

            objWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            objWorkExcel.Quit(); // выйти из Excel
            File.Delete(pathTemplate);
            GC.Collect(); // убрать за собой
            return maping;
        }
    }
}
