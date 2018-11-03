using SQ88Buffet.Models;
using SQ88Buffet.Services;
using SQ88Buffet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

            ProductList = new ObservableCollection<Product>();
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
            throw new NotImplementedException();
        }

        private void SnacksPurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FoodPurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DrinksPurchasesList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
            throw new NotImplementedException();
        }

        private void changePurchasesContextAndSave()
        {
            DrinksPurchasesList.Clear();
            FoodPurchasesList.Clear();
            SnacksPurchasesList.Clear();
            foreach (Purchase item in PurchasesList)
            {

                //if (item.UnitsOfProduct > 0) 
                //{
 
                    //InteriorPurchasesList.Add(item);
                    switch (item.ProductCategory)
                    {
                        case "Drinks":
                            {
                                DrinksPurchasesList.Add(item); 
                                break;
                            }
                        case "Food":
                            {
                                FoodPurchasesList.Add(item);
                                break;
                            }
                        case "Snacks":
                            {
                                SnacksPurchasesList.Add(item);
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
                    PurchasesList = new ObservableCollection<Purchase>(DrinksPurchasesList);
                    break;
                case "Food":
                    PurchasesList = new ObservableCollection<Purchase>(FoodPurchasesList);
                    break;
                case "Snacks":
                    PurchasesList = new ObservableCollection<Purchase>(SnacksPurchasesList);
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
            Category = "Snacks";
            changePurchasesContextAndSave();


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
            Category = "Food";
            changePurchasesContextAndSave();

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
            Category = "Drinks";
            changePurchasesContextAndSave();


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

            ProductList = new ObservableCollection<Product>();
            PurchasesList = new ObservableCollection<Purchase>();

            //DrinksList = new ObservableCollection<Product>(await _productRepository.GetAllProductData("Drinks"));
            //FoodList = new ObservableCollection<Product>(await _productRepository.GetAllProductData("Food"));
            //SnacksList = new ObservableCollection<Product>(await _productRepository.GetAllProductData("Snacks"));

            ProductList = new ObservableCollection<Product>(await _productRepository.GetAllProductData());

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
            tempPurchase.UnitsOfProduct--;
            PurchasesList.RemoveAt(indx);
            PurchasesList.Add(tempPurchase);
        }

        private async Task IncreaseUnits(object e)
        {
            Purchase tempPurchase = (e as Purchase);
            int indx = PurchasesList.IndexOf(tempPurchase);
            tempPurchase.UnitsOfProduct++;
            PurchasesList.RemoveAt(indx);
            PurchasesList.Add(tempPurchase);
        }
    }
}
