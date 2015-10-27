using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;

namespace FrugtKurven
{
    public class AddFruitPage : ContentPage
    {
        public AddFruitPage()
        {
            Padding = new Thickness(0,20,0,0);
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
            
            var nameLabel = new Label {Text = "Name"};
            var weightLabel = new Label {Text = "Weight"};
            var colorLabel = new Label {Text = "Color"};

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, AddFruitViewModel.FruitNameProperty);
            var weightEntry = new Entry();
            weightEntry.SetBinding(Entry.TextProperty, AddFruitViewModel.FruitWeightProperty);
            var colorEntry = new Entry();
            colorEntry.SetBinding(Entry.TextProperty, AddFruitViewModel.FruitColorProperty);

            var cancelButton = new Button {Text = "Cancel"};
            cancelButton.SetBinding(Button.CommandProperty, AddFruitViewModel.CancelCommandProperty);

            var addButton = new Button {Text = "Add"};
            addButton.SetBinding(Button.CommandProperty, AddFruitViewModel.AddFruitCommandProperty);

            grid.Children.Add(nameLabel, 0, 0);
            grid.Children.Add(weightLabel, 0, 1);
            grid.Children.Add(colorLabel, 0, 2);
            grid.Children.Add(cancelButton, 0, 3);

            grid.Children.Add(nameEntry, 1, 0);
            grid.Children.Add(weightEntry, 1, 1);
            grid.Children.Add(colorEntry, 1, 2);
            grid.Children.Add(addButton, 1, 3);

            return grid;
        }
    }
}
