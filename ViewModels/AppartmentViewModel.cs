using ComplexPractice.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComplexPractice.ViewModels
{
    class AppartmentViewModel : PropertyChangedBase
    {
        public AppartmentViewModel()
        {
            Complex model = new Complex();

            if (StaticData.Change)
            {
                SelectedComplex = StaticData.SelectedComplex;

                
                //model.Name = SelectedComplex.Name;
                //model.Address = SelectedComplex.Address;
                //model.Building = SelectedComplex.Building;
                //model.Appartment = SelectedComplex.Appartment;
                //model.Space = SelectedComplex.Space;
                //model.NumberOfRooms = SelectedComplex.NumberOfRooms;
                //model.Entrance = SelectedComplex.Entrance;
                //model.Floor = SelectedComplex.Floor;
                //model.AppartmentCondition = SelectedComplex.AppartmentCondition;

                //SelectedName = SelectedComplex.Name;
                //SelectedAddress = SelectedComplex.Address;
                //SelectedBuilding = SelectedComplex.Building;
                //SelectedAppartment = SelectedComplex.Appartment;
                //SelectedArea = SelectedComplex.Space;
                //SelectedNumberOfRooms = SelectedComplex.NumberOfRooms;
                //SelectedEntrance = SelectedComplex.Entrance;
                //SelectedFloor = SelectedComplex.Floor;
                //SelectedStatus = SelectedComplex.AppartmentCondition;

                MessageBox.Show(SelectedComplex.Name);
            }

            Maping = new ObservableCollection<Complex>(StaticData.AllComplexCollection);

            Names = /*new List<string>*/Maping.Where(p => p.Name != null && !string.IsNullOrEmpty(p.Name)).Select(p => p.Name).Distinct().ToList();
            Addresses = /*new ObservableCollection<string>*/Maping.Where(p => p.Address != null && !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().ToList();
            Buildings = /*new List<string>*/Maping.Where(p => p.Building != null && !string.IsNullOrEmpty(p.Building)).Select(p => p.Building).Distinct().ToList();
            AppartmentStatuses = /*new ObservableCollection<string>*/Maping.Where(p => p.AppartmentCondition != null && !string.IsNullOrEmpty(p.AppartmentCondition)).Select(p => p.AppartmentCondition).Distinct().ToList();

            SaveCommand = new DelegateCommand(Save);

        }
        private ObservableCollection<Complex> maping;
        public ObservableCollection<Complex> Maping
        {
            get { return maping; }
            set
            {
                maping = value;
                OnPropertyChanged();
            }
        }

        private Complex selectedComplex;
        public Complex SelectedComplex
        {
            get { return selectedComplex; }
            set
            {
                selectedComplex = value;
                OnPropertyChanged();
            }
        }

        public IDelegateCommand SaveCommand { protected set; get; }
        void Save(object param)
        {
            object[] parameters = param as object[];
            //Complex complex = param as Complex;
            //SelectedComplex.Name = complex.Name;
            MessageBox.Show("1oe: " + parameters[0] + " 2oe: " + parameters[1]);
            SelectedComplex.Name = parameters[0].ToString();
            SelectedComplex.Entrance = Convert.ToInt32(parameters[1]);
            SelectedComplex.Floor = Convert.ToInt32(parameters[2]);
        }

        //#region Свойства selected
        //private string selectedName;
        //public string SelectedName
        //{
        //    get { return selectedName; }
        //    set
        //    {
        //        selectedName = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string selectedAddress;
        //public string SelectedAddress
        //{
        //    get { return selectedAddress; }
        //    set
        //    {
        //        selectedAddress = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private string selectedBuilding;
        //public string SelectedBuilding
        //{
        //    get { return selectedBuilding; }
        //    set
        //    {
        //        selectedBuilding = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private int selectedAppartment;
        //public int SelectedAppartment
        //{
        //    get { return selectedAppartment; }
        //    set
        //    {
        //        selectedAppartment = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private double selectedArea;
        //public double SelectedArea
        //{
        //    get { return selectedArea; }
        //    set
        //    {
        //        selectedArea = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private int selectedNumberOfRooms;
        //public int SelectedNumberOfRooms
        //{
        //    get { return selectedNumberOfRooms; }
        //    set
        //    {
        //        selectedNumberOfRooms = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private int selectedEntrance;
        //public int SelectedEntrance
        //{
        //    get { return selectedEntrance; }
        //    set
        //    {
        //        selectedEntrance = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private int selectedFloor;
        //public int SelectedFloor
        //{
        //    get { return selectedFloor; }
        //    set
        //    {
        //        selectedFloor = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private string selectedStatus;
        //public string SelectedStatus
        //{
        //    get { return selectedStatus; }
        //    set
        //    {
        //        selectedStatus = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private string selectedCoef;
        //public string SelectedCoef
        //{
        //    get { return selectedCoef; }
        //    set
        //    {
        //        selectedCoef = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private string selectedExpences;
        //public string SelectedExpences
        //{
        //    get { return selectedExpences; }
        //    set
        //    {
        //        selectedExpences = value;
        //        OnPropertyChanged();
        //    }
        //}
        //#endregion

        #region Свойства для боксов(списки)
        private List<string> names;
        public List<string> Names
        {
            get { return names; }
            set
            {
                names = value;
                OnPropertyChanged();
            }
        }
        private List<string> addresses;
        public List<string> Addresses
        {
            get { return addresses; }
            set
            {
                addresses = value;
                OnPropertyChanged();
            }
        }
        private List<string> buildings;
        public List<string> Buildings
        {
            get { return buildings; }
            set
            {
                buildings = value;
                OnPropertyChanged();
            }
        }
        private List<string> appartmentStatuses;
        public List<string> AppartmentStatuses
        {
            get { return appartmentStatuses; }
            set
            {
                appartmentStatuses = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //private Complex name;
        //public Complex Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex address;
        //public Complex Address
        //{
        //    get { return address; }
        //    set
        //    {
        //        address = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex building;
        //public Complex Building
        //{
        //    get { return building; }
        //    set
        //    {
        //        building = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex appartment;
        //public Complex Appartment
        //{
        //    get { return appartment; }
        //    set
        //    {
        //        appartment = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex area;
        //public Complex Area
        //{
        //    get { return area; }
        //    set
        //    {
        //        area = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex numberOfRooms;
        //public Complex NumberOfRooms
        //{
        //    get { return numberOfRooms; }
        //    set
        //    {
        //        numberOfRooms = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex entrance;
        //public Complex Entrance
        //{
        //    get { return entrance; }
        //    set
        //    {
        //        entrance = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex complexName;
        //public Complex ComplexName
        //{
        //    get { return complexName; }
        //    set
        //    {
        //        complexName = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex complexName;
        //public Complex ComplexName
        //{
        //    get { return complexName; }
        //    set
        //    {
        //        complexName = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex complexName;
        //public Complex ComplexName
        //{
        //    get { return complexName; }
        //    set
        //    {
        //        complexName = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Complex complexName;
        //public Complex ComplexName
        //{
        //    get { return complexName; }
        //    set
        //    {
        //        complexName = value;
        //        OnPropertyChanged();
        //    }
        //}



        //private IDelegateCommand myVar;

        //public IDelegateCommand MyProperty
        //{
        //    get
        //    {
        //        return myVar ?? (myVar = new DelegateCommand(
        //           x =>
        //           {
        //               StaticData.viewEnabled = true;
        //           }));
        //    }
        //}

    }
}
