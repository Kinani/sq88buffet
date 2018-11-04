using SQ88Buffet.Models;
using SQ88Buffet.Services;
using SQ88Buffet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class PurchaseViewModel : BasePurchaseViewModel
    {
        public ICommand IncreaseUnitsCommand { get; private set; }
        public ICommand DecreaseUnitsCommand { get; private set; }
        public ICommand ContinueToSelectPersCommand { get; private set; }
        public ICommand DiscardAllCommand { get; private set; }
        public ICommand ChangeCategToDrinksCommand { get; private set; }
        public ICommand ChangeCategToFoodCommand { get; private set; }
        public ICommand ChangeCategToSnacksCommand { get; private set; }

        public string Category { get; set; }


        public PurchaseViewModel(INavigation navigation, ProductsCateg category = null)
        {
            _navigation = navigation;

            Purchase = new Purchase();
            //Purchase.UnitsOfProduct = 4;
            _purchaseRepository = new PurchaseRepository();
            _productRepository = new ProductRepository();

            PurchasesList = new ObservableCollection<Purchase>();
            DrinksPurchasesList = new ObservableCollection<Purchase>();
            SnacksPurchasesList = new ObservableCollection<Purchase>();
            FoodPurchasesList = new ObservableCollection<Purchase>();
            InteriorPurchasesList = new ObservableCollection<Purchase>();

            ProductList = new List<Product>();
            FoodList = new ObservableCollection<Product>();
            SnacksList = new ObservableCollection<Product>();
            DrinksList = new ObservableCollection<Product>();

            if (category != null)
            {
                Category = category.ProdType;
            }

            IncreaseUnitsCommand = new Command(async (e) => await IncreaseUnits(e));
            DecreaseUnitsCommand = new Command(async (e) => await DecreaseUnits(e));
            ContinueToSelectPersCommand = new Command(async () => await ContinueToSelectPers());
            DiscardAllCommand = new Command(async () => await DiscardAll());
            ChangeCategToDrinksCommand = new Command(async (e) => await ChangeCategToDrinks(e));
            ChangeCategToFoodCommand = new Command(async (e) => await ChangeCategToFood(e));
            ChangeCategToSnacksCommand = new Command(async (e) => await ChangeCategToSnacks(e));

            DrinksPurchasesList.CollectionChanged += DrinksPurchasesList_CollectionChanged;
            FoodPurchasesList.CollectionChanged += FoodPurchasesList_CollectionChanged;
            SnacksPurchasesList.CollectionChanged += SnacksPurchasesList_CollectionChanged;
            PurchasesList.CollectionChanged += PurchasesList_CollectionChanged;
        }

        private void PurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var pur = sender as Purchase;
        }

        private void SnacksPurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        private void FoodPurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        private void DrinksPurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {


        }

        private void changePurchasesContextAndSave(string oldCateg)
        {
            //switch (oldCateg)
            //{
            //    case "Drinks":
            //        DrinksPurchasesList.Clear();
            //        break;
            //    case "Food":
            //        FoodPurchasesList.Clear();
            //        break;
            //    case "Snacks":
            //        SnacksPurchasesList.Clear();
            //        break;
            //    default:
            //        break;
            //}
            foreach (Purchase item in PurchasesList)
            {

                //if (item.UnitsOfProduct > 0) 
                //{

                //InteriorPurchasesList.Add(item);
                switch (item.ProductCategory)
                {
                    case "Drinks":
                        {
                            if (item.UnitsOfProduct > 0)
                            {
                                foreach (var drinkItem in DrinksPurchasesList)
                                {
                                    if (drinkItem.ProductId == item.ProductId)
                                    {
                                        int indx = DrinksPurchasesList.IndexOf(drinkItem);
                                        DrinksPurchasesList.RemoveAt(indx);
                                        DrinksPurchasesList.Add(item);
                                        break;
                                    }
                                }
                            }

                            //DrinksPurchasesList.Add(item); 
                            break;
                        }
                    case "Food":
                        {
                            if (item.UnitsOfProduct > 0)
                            {
                                foreach (var foodItem in FoodPurchasesList)
                                {
                                    if (foodItem.ProductId == item.ProductId)
                                    {
                                        int indx = FoodPurchasesList.IndexOf(foodItem);
                                        FoodPurchasesList.RemoveAt(indx);
                                        FoodPurchasesList.Add(item);
                                        break;
                                    }
                                }
                            }
                            //FoodPurchasesList.Add(item);
                            break;
                        }
                    case "Snacks":
                        {

                            if (item.UnitsOfProduct > 0)
                            {
                                foreach (var snacksItem in SnacksPurchasesList)
                                {
                                    if (snacksItem.ProductId == item.ProductId)
                                    {
                                        int indx = SnacksPurchasesList.IndexOf(snacksItem);
                                        SnacksPurchasesList.RemoveAt(indx);
                                        SnacksPurchasesList.Add(item);
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
                //}
            }
            //PurchasesList.Clear();
            switch (Category)
            {
                case "Drinks":
                    //PurchasesList = new ObservableCollection<Purchase>(DrinksPurchasesList);
                    PurchasesList.Clear();
                    foreach (var item in DrinksPurchasesList)
                    {
                        PurchasesList.Add(item);
                    }
                    break;
                case "Food":
                    PurchasesList.Clear();
                    foreach (var item in FoodPurchasesList)
                    {
                        PurchasesList.Add(item);
                    }
                    break;
                case "Snacks":
                    PurchasesList.Clear();
                    foreach (var item in SnacksPurchasesList)
                    {
                        PurchasesList.Add(item);
                    }
                    break;
                default:
                    break;
            }
            //PurchasesList.Clear();
            //foreach (Product item in ProductList)
            //{
            //    PurchasesList.Add(new Purchase()
            //    {
            //        ProductId = item.Id,
            //        ProductName = item.Name,
            //        ProductPrice = item.Price,
            //        ProductQuantity = item.Quantity,
            //        IsCompleted = false
            //    });
            //}
        }

        private async Task ChangeCategToSnacks(object e)
        {
            string tempCateg = Category;
            Category = "Snacks";
            changePurchasesContextAndSave(tempCateg);


            StackLayout stack = (e as StackLayout);
            Button food = stack.FindByName<Button>("BtnFood");
            Button drinks = stack.FindByName<Button>("BtnDrinks");
            Button snacks = stack.FindByName<Button>("BtnSnacks");

            food.IsEnabled = true;
            drinks.IsEnabled = true;
            snacks.IsEnabled = false;
        }

        private async Task ChangeCategToFood(object e)
        {
            string tempCateg = Category;
            Category = "Food";
            changePurchasesContextAndSave(tempCateg);

            StackLayout stack = (e as StackLayout);
            Button food = stack.FindByName<Button>("BtnFood");
            Button drinks = stack.FindByName<Button>("BtnDrinks");
            Button snacks = stack.FindByName<Button>("BtnSnacks");

            food.IsEnabled = false;
            drinks.IsEnabled = true;
            snacks.IsEnabled = true;
        }

        private async Task ChangeCategToDrinks(object e)
        {
            string tempCateg = Category;
            Category = "Drinks";
            changePurchasesContextAndSave(tempCateg);


            StackLayout stack = (e as StackLayout);
            Button food = stack.FindByName<Button>("BtnFood");
            Button drinks = stack.FindByName<Button>("BtnDrinks");
            Button snacks = stack.FindByName<Button>("BtnSnacks");

            food.IsEnabled = true;
            drinks.IsEnabled = false;
            snacks.IsEnabled = true;
        }

        public async Task PopulatePurchases()
        {

            ProductList = new List<Product>();
            //PurchasesList = new ObservableCollection<Purchase>();
            PurchasesList.Clear();

            //DrinksList = new ObservableCollection<Product>(await _productRepository.GetAllProductData("Drinks"));
            //FoodList = new ObservableCollection<Product>(await _productRepository.GetAllProductData("Food"));
            //SnacksList = new ObservableCollection<Product>(await _productRepository.GetAllProductData("Snacks"));

            ProductList = new List<Product>(await _productRepository.GetAllProductData());

            //switch (Category)
            //{
            //    case "Drinks":
            //        ProductList = DrinksList;
            //        break;
            //    case "Food":
            //        ProductList = FoodList;
            //        break;
            //    case "Snacks":
            //        ProductList = SnacksList;
            //        break;
            //    default:
            //        break;
            //}

            foreach (Product item in ProductList)
            {
                switch (item.Category)
                {
                    case "Drinks":
                        {
                            Purchase temp = new Purchase()
                            {
                                ProductId = item.Id,
                                ProductName = item.Name,
                                ProductPrice = item.Price,
                                ProductQuantity = item.Quantity,
                                ProductCategory = item.Category,
                                IsCompleted = false
                            };

                            DrinksPurchasesList.Add(temp);
                            PurchasesList.Add(temp);
                            break;
                        }
                    case "Food":
                        {
                            Purchase temp2 = new Purchase()
                            {
                                ProductId = item.Id,
                                ProductName = item.Name,
                                ProductPrice = item.Price,
                                ProductQuantity = item.Quantity,
                                ProductCategory = item.Category,
                                IsCompleted = false
                            };

                            FoodPurchasesList.Add(temp2);
                            PurchasesList.Add(temp2);
                            break;
                        }
                    case "Snacks":
                        Purchase temp3 = new Purchase()
                        {
                            ProductId = item.Id,
                            ProductName = item.Name,
                            ProductPrice = item.Price,
                            ProductQuantity = item.Quantity,
                            ProductCategory = item.Category,
                            IsCompleted = false
                        };

                        SnacksPurchasesList.Add(temp3);
                        PurchasesList.Add(temp3);
                        break;
                    default:
                        break;
                }
                //PurchasesList.Add(new Purchase()
                //{
                //    ProductId = item.Id,
                //    ProductName = item.Name,
                //    ProductPrice = item.Price,
                //    ProductQuantity = item.Quantity,
                //    IsCompleted = false
                //});
            }
            //switch (Category)
            //{
            //    case "Drinks":
            //        PurchasesList = DrinksPurchasesList;
            //        break;
            //    case "Food":
            //        PurchasesList = FoodPurchasesList;
            //        break;
            //    case "Snacks":
            //        PurchasesList = SnacksPurchasesList;
            //        break;
            //    default:
            //        break;
            //}

        }

        private async Task DiscardAll()
        {
            await _navigation.PushAsync(new MainPage());
        }

        private async Task ContinueToSelectPers()
        {
            throw new NotImplementedException();
        }

        private async Task DecreaseUnits(object e)
        {
            Purchase tempPurchase = (e as Purchase);
            int indx = PurchasesList.IndexOf(tempPurchase);
            PurchasesList[indx].UnitsOfProduct--;
        }

        private async Task IncreaseUnits(object e)
        {
            Purchase tempPurchase = (e as Purchase);
            int indx = PurchasesList.IndexOf(tempPurchase);
            PurchasesList[indx].UnitsOfProduct++;
        }
    }
}
