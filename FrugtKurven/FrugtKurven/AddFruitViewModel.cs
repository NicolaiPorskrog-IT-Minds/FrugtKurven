using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FrugtKurven
{
    public class AddFruitViewModel : ViewModel
    {
        #region
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
        public const string AddFruitCommandProperty = "AddFruitCommand";
        public ICommand AddFruitCommand
        {
            get { return new Command(async () => await DoAddFruitCommand()); }
        }

        private async Task DoAddFruitCommand()
        {
            var fruit = new Fruit {Name = this.FruitName, Color = this.FruitColor, Weight = this.FruitWeight};
            MessagingCenter.Send(this, "FruitAdded", fruit);
            Navigation.PopModalAsync();
        }

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
