using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FrugtKurven
{
    public class ViewFruitViewModel : ViewModel
    {       
        #region Properties
        public const string FruitNameProperty = "FruitName";
        private string _fruitName;
        public string FruitName
        {
            get { return _fruitName; }
            set { SetProperty(ref _fruitName, value); }
        }

        public const string FruitWeightProperty = "FruitWeight";
        private double _fruitWeight;
        public double FruitWeight
        {
            get { return _fruitWeight; }
            set { SetProperty(ref _fruitWeight, value); }
        }

        public const string FruitColorProperty = "FruitColor";
        private string _fruitColor;
        public string FruitColor
        {
            get { return _fruitColor; }
            set { SetProperty(ref _fruitColor, value); }
        }
        #endregion
        #region Commands
        public const string CancelCommandProperty = "CancelCommand";
        public ICommand CancelCommand
        {
            get { return new Command(async () => await DoCancelCommand()); }
        }

        private async Task DoCancelCommand()
        {
            await Navigation.PopModalAsync();
        }
#endregion
    }
}
