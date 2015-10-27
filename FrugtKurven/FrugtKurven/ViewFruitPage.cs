using Xamarin.Forms;

namespace FrugtKurven
{
    public class ViewFruitPage : ContentPage
    {
        public ViewFruitPage()
        {
            Padding = new Thickness(0, 20, 0, 0);
            Content = FruitGrid();
        }

        private Grid FruitGrid()
        {
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };
            var nameLabel = new Label { Text = "Name" };
            var weightLabel = new Label { Text = "Weight" };
            var colorLabel = new Label { Text = "Color" };

            var name = new Label();
            name.SetBinding(Label.TextProperty, ViewFruitViewModel.FruitNameProperty, BindingMode.TwoWay);
            var weight = new Label();
            weight.SetBinding(Label.TextProperty, ViewFruitViewModel.FruitWeightProperty, BindingMode.TwoWay);
            var color = new Label();
            color.SetBinding(Label.TextProperty, ViewFruitViewModel.FruitColorProperty, BindingMode.TwoWay);

            var backButton = new Button { Text = "Back" };
            backButton.SetBinding(Button.CommandProperty, ViewFruitViewModel.CancelCommandProperty);

            grid.Children.Add(nameLabel, 0, 0);
            grid.Children.Add(weightLabel, 0, 1);
            grid.Children.Add(colorLabel, 0, 2);
            grid.Children.Add(backButton, 0, 3);

            grid.Children.Add(name, 1, 0);
            grid.Children.Add(weight, 1, 1);
            grid.Children.Add(color, 1, 2);

            return grid;
        }
    }
}
