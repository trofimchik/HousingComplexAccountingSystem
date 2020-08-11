using ComplexPractice.Helpers;
using ComplexPractice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexPractice.ViewModels
{
    class MainWindowViewModel : PropertyChangedBase
    {
        //private object _view1 = new ComplexView();
        //private object _view2 = new AppartmentView();
        //private object _currentView;

        //public MainWindowViewModel()
        //{
        //    _currentView = _view1;
        //    Mediator.Register("ChangeView", OnChangeView);
        //}

        //public object CurrentView
        //{
        //    get
        //    {
        //        return _currentView;
        //    }
        //    set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged("CurrentView");
        //    }
        //}

        //public void OnChangeView(object show)
        //{
        //    bool showView1 = (bool)show;
        //    CurrentView = showView1 ? _view1 : _view2;
        //}
    }
}
