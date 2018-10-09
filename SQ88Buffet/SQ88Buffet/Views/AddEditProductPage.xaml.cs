using SQ88Buffet.Models;
using SQ88Buffet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQ88Buffet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditProductPage : ContentPage
    {
        public AddEditProductViewModel _addProductViewModel;
        public AddEditProductPage(Product prod = null, bool delete = false)
        {
            InitializeComponent();
            _addProductViewModel = new AddEditProductViewModel(Navigation, prod, delete);
            BindingContext = _addProductViewModel;
            if (delete)
            {
                Title = "Delete Product";
                SubmitButton.Text = "Delete Product";
            }
        }

    }
}