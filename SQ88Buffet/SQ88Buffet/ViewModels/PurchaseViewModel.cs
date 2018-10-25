using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
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


        public PurchaseViewModel()
        {

            Purchase = new Purchase();
            Purchase.UnitsOfProduct = 4;
            _purchaseRepository = new PurchaseRepository();
            PurchasesList = new List<Purchase>();

            IncreaseUnitsCommand = new Command(async (e) => await IncreaseUnits(e));
            DecreaseUnitsCommand = new Command(async (e) => await DecreaseUnits(e));
            ContinueToSelectPersCommand = new Command(async () => await ContinueToSelectPers());
            DiscardAllCommand = new Command(async () => await DiscardAll());

        }

        private async Task DiscardAll()
        {
            throw new NotImplementedException();
        }

        private async Task ContinueToSelectPers()
        {
            throw new NotImplementedException();
        }

        private async Task DecreaseUnits(object e)
        {
            bool foundPurc = false;
            Purchase tempPur = new Purchase();
            Product selectedProd = (e as Product);
            try
            {
                tempPur = PurchasesList.Find(p => p.ProductId == selectedProd.Id);
                if (tempPur != null)
                    foundPurc = true;
            }
            catch (Exception)
            {
                foundPurc = false;
            }

            if (foundPurc)
            {
                tempPur.UnitsOfProduct--;
                selectedProd.UnitsOfProduct--;
                tempPur.PurchaseValue = selectedProd.UnitsOfProduct * selectedProd.Price;
            }
            else
            {
                tempPur = new Purchase()
                {

                    ProductId = selectedProd.Id,
                    UnitsOfProduct = --selectedProd.UnitsOfProduct,
                    PurchaseValue = selectedProd.UnitsOfProduct * selectedProd.Price
                };
                PurchasesList.Add(tempPur);
            }
        }

        private async Task IncreaseUnits(object e)
        {
            bool foundPurc = false;
            Purchase tempPur = new Purchase();
            Product selectedProd = (e as Product);
            try
            {
                tempPur = PurchasesList.Find(p => p.ProductId == selectedProd.Id);
                if (tempPur != null)
                    foundPurc = true;
            }
            catch (Exception)
            {
                foundPurc = false;
            }

            if (foundPurc)
            {
                tempPur.UnitsOfProduct++;
                selectedProd.UnitsOfProduct++;
                tempPur.PurchaseValue = selectedProd.UnitsOfProduct * selectedProd.Price;
            }
            else
            {
                tempPur = new Purchase()
                {

                    ProductId = selectedProd.Id,
                    UnitsOfProduct = ++selectedProd.UnitsOfProduct,
                    PurchaseValue = selectedProd.UnitsOfProduct * selectedProd.Price
                };
                PurchasesList.Add(tempPur);
            }

        }
    }
}
