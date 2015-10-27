using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FrugtKurven
{
    public class FruitsViewModel : ViewModel
    {
        public FruitsViewModel()
        {
            MessagingCenter.Subscribe<AddFruitViewModel, Fruit>(this, "FruitAdded", (model, fruit) =>
            {
                var fruitVM = new FruitViewCellViewModel(fruit);
                FruitsList.Add(fruitVM);
            });
        }

        public const string FruitsListProperty = "FruitsList";
        private ObservableCollection<FruitViewCellViewModel> _fruitsList;
        public ObservableCollection<FruitViewCellViewModel> FruitsList
        {
            get { return _fruitsList ?? (_fruitsList = new ObservableCollection<FruitViewCellViewModel>()); }
            set { SetProperty(ref _fruitsList, value); }
        }

        public const string AddFruitCommandProperty = "AddFruitCommand";
        public ICommand AddFruitCommand
        {
            get { return new Command(async () => await DoAddFruitCommand()); }
        }

        private async Task DoAddFruitCommand()
        {
            await Navigation.PushModalAsync<AddFruitViewModel>();
        }

        public ICommand ViewFruitCommand
        {
            get { return new Command<FruitViewCellViewModel>(async (fruitVM) => await DoViewFruitCommand(fruitVM)); }
        }

        private async Task DoViewFruitCommand(FruitViewCellViewModel fruitVM)
        {
            await Navigation.PushModalAsync<ViewFruitViewModel>((model, page) =>
            {
                model.FruitColor = fruitVM.Fruit.Color;
                model.FruitName = fruitVM.Fruit.Name;
                model.FruitWeight = fruitVM.Fruit.Weight;
            });
        }
    }
}
