using ComplexPractice.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Office.Interop.Excel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Globalization;
using System.Xml.Serialization;
using ComplexPractice.Views;

namespace ComplexPractice.ViewModels
{
    class AppartmentListViewModel : PropertyChangedBase
    {
        readonly ObservableCollection<Complex> maping;
        public ICollectionView ComplexCollectionView { get; private set; }

        public AppartmentListViewModel()
        {


            SelectedComplex = StaticData.SelectedComplex;
            //AllComplexesCollection = new ObservableCollection<Complex>(StaticData.SavedComplex);

            maping = new ObservableCollection<Complex>(StaticData.AllComplexCollection);

            #region Заполнение коллекций, предназначенных для отображения в treeview(с сортировкой и удалением дубликатов).

            ComplexNames = maping
                .Where(p => p.Name != null && !string.IsNullOrEmpty(p.Name))
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            ComplexAddresses =
                maping
                .Where(p => p.Address != null && !string.IsNullOrEmpty(p.Address))
                .OrderBy(p => p.Address)
                .Select(p => p.Address)
                .Distinct()
                .ToList();

            Floors =
                maping
                //.Where(p => p.Floor != null && !string.IsNullOrEmpty(p.Floor))
                .OrderBy(p => /*FormatNumbers.PadNumbers(*/p.Floor/*)*/)
                .Select(p => p.Floor)
                .Distinct()
                .ToList();

            //.Where(p => p.Entrance != null && !string.IsNullOrEmpty(p.Entrance))
            //.OrderBy(p =>/* FormatNumbers.PadNumbers(*/p.Entrance/*)*/)

            Entrances = 
                maping
                .OrderBy(complex => complex.Entrance)
                .Select(complex => complex.Entrance)
                .Distinct()
                .ToList();

            AppartmentStatuses = 
                maping
                .Where(p => p.AppartmentCondition != null && !string.IsNullOrEmpty(p.AppartmentCondition))
                .OrderBy(p => p.AppartmentCondition)
                .Select(p => p.AppartmentCondition)
                .Distinct()
                .ToList();
            #endregion
            ComplexCollectionView = new CollectionViewSource { Source = maping }.View;
            ComplexCollectionView.Filter = CollectionAtOpeningWindow;
            ExecuteApplyFilterCommand = new DelegateCommand(ExecuteApplyFilter);
            ShowAppartmentViewChangeCommand = new DelegateCommand(ShowAppartmentViewChange);
            //ShowAppartmentViewCreateCommand = new DelegateCommand(ShowAppartmentViewCreate);
        }
        private bool CollectionAtOpeningWindow(object item)
        {
            Complex selected = item as Complex;
            if (selected.Name == SelectedComplex.Name && selected.Address == SelectedComplex.Address && selected.Building == SelectedComplex.Building)
            {
                return true;
            }
            return false;
        }

        #region Логика фильтра (treeview). Костыли, много повторений кода
        private List<Predicate<Complex>> criteria = new List<Predicate<Complex>>();
        public IDelegateCommand ExecuteApplyFilterCommand { get; set; }
        void ExecuteApplyFilter(object item)//КОСТЫЛИ, но пока ничего умнее я не придумал...
        {
            criteria.Clear();
            object[] parameters = item as object[];

            AllCheckBoxesLogic(parameters);
            OnCriteriaAdd();
            ComplexCollectionView.Filter = DynamicFilter;
        }
        void AllCheckBoxesLogic(object[] parameters)
        {
            if ((bool)parameters[0])
            {
                switch (parameters[2])
                {
                    case "Name":
                        ComplexForFilter.Name.Add((string)parameters[1]);
                        break;
                    case "Address":
                        ComplexForFilter.Address.Add((string)parameters[1]);
                        break;
                    case "Floor":
                        ComplexForFilter.Floor.Add((string)parameters[1]);
                        break;
                    case "Entrance":
                        ComplexForFilter.Entrance.Add((string)parameters[1]);
                        break;
                    case "AppartmentStatus":
                        ComplexForFilter.AppartmentStatus.Add((string)parameters[1]);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (parameters[2])
                {
                    case "Name":
                        ComplexForFilter.Name.Remove((string)parameters[1]);
                        break;
                    case "Address":
                        ComplexForFilter.Address.Remove((string)parameters[1]);
                        break;
                    case "Floor":
                        ComplexForFilter.Floor.Remove((string)parameters[1]);
                        break;
                    case "Entrance":
                        ComplexForFilter.Entrance.Remove((string)parameters[1]);
                        break;
                    case "AppartmentStatus":
                        ComplexForFilter.AppartmentStatus.Remove((string)parameters[1]);
                        break;
                    default:
                        break;
                }
            }
        }
        void OnCriteriaAdd()
        {
            foreach (string n in ComplexForFilter.Name)
            {
                criteria.Add(new Predicate<Complex>(x => x.Name.Contains(n)));
            }
            foreach (string a in ComplexForFilter.Address)
            {
                criteria.Add(new Predicate<Complex>(x => x.Address.Contains(a)));
            }
            foreach (string f in ComplexForFilter.Floor)
            {
                criteria.Add(new Predicate<Complex>(x => x.Floor.ToString().Contains(f)));
            }
            foreach (string e in ComplexForFilter.Entrance)
            {
                criteria.Add(new Predicate<Complex>(x => x.Entrance.ToString().Contains(e)));
            }
            foreach (string s in ComplexForFilter.AppartmentStatus)
            {
                criteria.Add(new Predicate<Complex>(x => x.AppartmentCondition.Contains(s)));
            }
        }
        private bool DynamicFilter(object item)
        {
            Complex c = item as Complex;
            bool isIn = true;
            if (criteria.Count() == 0)
                return isIn;
            isIn = criteria.ToArray().Any(x => x(c));
            return isIn;
        }
        #endregion

        public Complex SelectedComplex { get; set; }

        #region Свойства для отображения в treeview.
        private List<string> complexNames;
        public List<string> ComplexNames
        {
            get { return complexNames; }
            set
            {
                complexNames = value;
                //OnPropertyChanged();
            }
        }

        private List<string> complexAddresses;
        public List<string> ComplexAddresses
        {
            get { return complexAddresses; }
            set
            {
                complexAddresses = value;
                //OnPropertyChanged();
            }
        }

        private List<int> floors;
        public List<int> Floors
        {
            get { return floors; }
            set
            {
                floors = value;
                //OnPropertyChanged();
            }
        }

        private List<int> entrances;
        public List<int> Entrances
        {
            get { return entrances; }
            set
            {
                entrances = value;
                //OnPropertyChanged();
            }
        }

        private List<string> appartmentStatuses;
        public List<string> AppartmentStatuses
        {
            get { return appartmentStatuses; }
            set
            {
                appartmentStatuses = value;
                //OnPropertyChanged();
            }
        }
        #endregion

        #region Свойства IsChecked. Опять нагородил повторяющегося кода, надо будет исправлять
        private bool isNameChecked;
        public bool IsNameChecked
        {
            get { return isNameChecked; }
            set
            {
                isNameChecked = value;
            }
        }


        private bool isAddressChecked;
        public bool IsAddressChecked
        {
            get { return isAddressChecked; }
            set
            {
                isAddressChecked = value;
            }
        }


        private bool isFloorChecked;
        public bool IsFloorChecked
        {
            get { return isFloorChecked; }
            set
            {
                isFloorChecked = value;
            }
        }


        private bool isEntranceChecked;
        public bool IsEntranceChecked
        {
            get { return isEntranceChecked; }
            set
            {
                isEntranceChecked = value;
            }
        }


        private bool isStatusChecked;
        public bool IsStatusChecked
        {
            get { return isStatusChecked; }
            set
            {
                isStatusChecked = value;
            }
        }
        #endregion

        #region Нечёткий поиск
        private string fuzzySearch;
        public string FuzzySearch
        {
            get { return fuzzySearch; }
            set
            {
                fuzzySearch = value;
                //search = FuzzySearch;
                ComplexCollectionView.Filter = FuzzySearchFilter;
                OnPropertyChanged("Search");
            }
        }
        private bool FuzzySearchFilter(object item)
        {
            Complex c = item as Complex;
            if (!string.IsNullOrEmpty(c.Name) && !string.IsNullOrEmpty(c.Address) && (Levenshtein.LevenshteinDistance(c.Address, FuzzySearch) < 4 || Levenshtein.LevenshteinDistance(c.Name, FuzzySearch) < 4))
            {
                return true;
            }
            return false;
        }
        #endregion

        private IDelegateCommand resetFiltersCommand;
        public IDelegateCommand ResetFiltersCommand
        {
            get
            {
                return resetFiltersCommand ?? (resetFiltersCommand = new DelegateCommand(
                   x =>
                   {
                       IsNameChecked = false;
                       IsAddressChecked = false;
                       IsFloorChecked = false;
                       IsEntranceChecked = false;
                       IsStatusChecked = false;

                       FuzzySearch = null;

                       OnPropertyChanged("IsNameChecked");
                       OnPropertyChanged("IsAddressChecked");
                       OnPropertyChanged("IsFloorChecked");
                       OnPropertyChanged("IsEntranceChecked");
                       OnPropertyChanged("IsStatusChecked");

                       OnPropertyChanged("FuzzySearch");

                       ComplexCollectionView.Filter = null;
                   }));
            }
        }

        public IDelegateCommand ShowAppartmentViewChangeCommand { protected set; get; }
        void ShowAppartmentViewChange(object param)
        {
            Complex selectedComplex = param as Complex;
            StaticData.Change = true;
            StaticData.SelectedComplex = selectedComplex;
            MessageBox.Show("нажал");
            new AppartmentView().ShowDialog();//ГРУБОЕ НАРУШЕНИЕ MVVM, нужен IDialogService/manager/provider, пока не разобрался...
        }

        public IDelegateCommand showAppartmentViewCreateCommand;
        public IDelegateCommand ShowAppartmentViewCreateCommand
        {
            get
            {
                return showAppartmentViewCreateCommand ?? (showAppartmentViewCreateCommand = new DelegateCommand(
                   x =>
                   {
                       StaticData.Change = false;
                       new AppartmentView().ShowDialog();//ГРУБОЕ НАРУШЕНИЕ MVVM, нужен IDialogService/manager/provider, пока не разобрался...
                   }));
            }
        }
    }
}
