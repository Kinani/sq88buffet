using SQ88Buffet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQ88Buffet.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel _mainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            _mainPageViewModel = new MainPageViewModel(Navigation);
            BindingContext = _mainPageViewModel;
            //PagesListView.ItemsSource = _mainPageViewModel.ProductsCateg;
        }
    }
}
