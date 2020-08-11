using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using System.Windows.Input;
using ComplexPractice.Views;
using ComplexPractice.Helpers;

namespace ComplexPractice.ViewModels
{
    class ComplexViewModel : PropertyChangedBase
    {


        readonly List<Complex> maping = new List<Complex>();
        public ComplexViewModel()
        {
            maping = StaticData.AllComplexCollection;

            AllComplexesList = maping;
            ComplexNames = /*new List<string>*/maping.Where(p => p.Name != null && !string.IsNullOrEmpty(p.Name)).Select(p => p.Name).Distinct().ToList();
            ComplexAddresses = /*new ObservableCollection<string>*/maping.Where(p => p.Address != null && !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().ToList();

            SimpleCommand = new DelegateCommand(ShowAppartmentListView);
        }

        private List<Complex> allComplexesList;
        public List<Complex> AllComplexesList
        {
            get { return allComplexesList; }
            set
            {
                allComplexesList = value;
                OnPropertyChanged();
            }
        }
        public List<string> ComplexNames { get; set; }
        //private List<string> complexNames;
        //public List<string> ComplexNames
        //{
        //    get { return complexNames; }
        //    set
        //    {
        //        complexNames = value;
        //        //OnPropertyChanged();
        //    }
        //}

        private string complexName;
        public string ComplexName
        {
            get { return complexName; }
            set
            {
                complexName = value;
                AllComplexesList = maping.Where(p => p.Name != null && p.Name == complexName).ToList();
                complexAddress = null;
                OnPropertyChanged(ComplexAddress);
            }
        }
        public List<string> ComplexAddresses { get; set; }
        //private List<string> complexAddresses;
        //public List<string> ComplexAddresses
        //{
        //    get { return complexAddresses; }
        //    set
        //    {
        //        complexAddresses = value;
        //        //OnPropertyChanged();
        //    }
        //}

        private string complexAddress;
        public string ComplexAddress
        {
            get { return complexAddress; }
            set
            {
                complexAddress = value;
                AllComplexesList = maping.Where(p => p.Address != null && p.Address == complexAddress).ToList();
                complexName = null;
                OnPropertyChanged(ComplexName);
            }
        }

        public IDelegateCommand SimpleCommand { protected set; get; }
        void ShowAppartmentListView(object param)
        {
            Complex selectedComplex = param as Complex;

            StaticData.SelectedComplex = selectedComplex;
            StaticData.SavedComplexes = new ObservableCollection<Complex>(AllComplexesList);

            new AppartmentListView().Show();//ГРУБОЕ НАРУШЕНИЕ MVVM, нужен IDialogService/manager/provider, пока не разобрался...

            System.Windows.Application.Current.MainWindow.Close(); //ПО ПОНЯТИЯМ ЛИ ЭТО? НЕТ.
        }

        private IDelegateCommand resetFiltersCommand;
        public IDelegateCommand ResetFiltersCommand
        {
            get
            {
                return resetFiltersCommand ?? (resetFiltersCommand = new DelegateCommand(
                   x =>
                   {
                       ComplexName = null;
                       ComplexAddress = null;
                       AllComplexesList = maping;
                       OnPropertyChanged(ComplexAddress);
                       OnPropertyChanged(ComplexName);
                   }));
            }
        }
    }
}
