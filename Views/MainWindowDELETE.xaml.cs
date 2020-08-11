using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace ComplexPractice.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<Complex> maping = new List<Complex>();
        //OpenFileDialog ofd = new OpenFileDialog
        //{
        //    DefaultExt = "*.xls;*.xlsx",
        //    Filter = "файл Excel|*.xlsx",
        //    Title = "Выберите файл базы данных"
        //};
        public MainWindow()
        {
            InitializeComponent();
            //ImportExcel();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void ImportExcel()
        //{
        //    OpenFileDialog ofd = new OpenFileDialog
        //    {
        //        DefaultExt = "*.xls;*.xlsx",
        //        Filter = "файл Excel|*.xlsx",
        //        Title = "Выберите файл базы данных"
        //    };
        //    MessageBox.Show(ofd.FileName.ToString());
        //    if (ofd.ShowDialog() == DialogResult.HasValue) // если файл БД не выбран -> Выход
        //        MessageBox.Show("ну выбери чонить, ща исключение выскочит");
        //    else
        //    {
        //        Excel.Application objWorkExcel = new Excel.Application();
        //        //ObjWorkExcel.Visible = true;
        //        Excel.Workbook objWorkBook = objWorkExcel.Workbooks.Open(/*"DataCopy"*/ofd.FileName);
        //        Excel.Worksheet objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[1];

        //        int row = 1;
        //        while (objWorkSheet.Cells[row + 1, 1].Value != null)
        //        {
        //            maping.Add(new Complex
        //            {
        //                Name = objWorkSheet.Cells[row + 1, 1].Text.ToString(),
        //                Condition = objWorkSheet.Cells[row + 1, 2].Text.ToString(),
        //                Adress = objWorkSheet.Cells[row + 1, 3].Text.ToString(),
        //                Building = objWorkSheet.Cells[row + 1, 4].Text.ToString(),
        //                Appartment = objWorkSheet.Cells[row + 1, 5].Text.ToString(),
        //                NumberOfRooms = Convert.ToInt32(objWorkSheet.Cells[row + 1, 6].Text),
        //                Entrance = Convert.ToInt32(objWorkSheet.Cells[row + 1, 7].Text),
        //                Space = Convert.ToInt32(objWorkSheet.Cells[row + 1, 8].Text),
        //                Price = Convert.ToDouble(objWorkSheet.Cells[row + 1, 9].Text),
        //                Floor = Convert.ToInt32(objWorkSheet.Cells[row + 1, 10].Text),
        //                AppartmentCondition = objWorkSheet.Cells[row + 1, 11].Text
        //            });
        //            row++;
        //        }

        //        maping.Sort((x, y) =>
        //        {
        //            int r = x.Name.CompareTo(y.Name);
        //            if (r == 0)
        //            {
        //                r = x.Adress.CompareTo(y.Adress);
        //                if (r == 0)
        //                {
        //                    r = x.Building.CompareTo(y.Building);
        //                }
        //            }
        //            return r;
        //        });

        //        objWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
        //        objWorkExcel.Quit(); // выйти из Excel
        //        GC.Collect(); // убрать за собой
        //        All.ItemsSource = maping;
        //    }
        //}
    }
}
