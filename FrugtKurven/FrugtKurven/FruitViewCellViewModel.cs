using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Mvvm;

namespace FrugtKurven
{
    public class FruitViewCellViewModel : ViewModel
    {
        public Fruit Fruit { get; set; }

        public FruitViewCellViewModel(Fruit fruit)
        {
            Fruit = fruit;
            FruitName = fruit.Name;
        }

        public const string FruitNameProperty = "FruitName";
        private string _fruitName;
        public string FruitName
        {
            get { return _fruitName; }
            set { SetProperty(ref _fruitName, value); }
        }
    }
}
