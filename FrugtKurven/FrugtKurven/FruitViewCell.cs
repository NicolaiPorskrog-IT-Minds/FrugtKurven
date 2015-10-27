using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FrugtKurven
{
    public class FruitViewCell : TextCell
    {
        public FruitViewCell()
        {
            this.SetBinding(TextCell.TextProperty, FruitViewCellViewModel.FruitNameProperty);
        }
    }
}
