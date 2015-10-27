using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FrugtKurven
{
    public class FruitsPage : ContentPage
    {
        public FruitsPage()
        {
            var toolbarItem = new ToolbarItem
            {
                Text = "Add fruit",
            };
            toolbarItem.SetBinding(ToolbarItem.CommandProperty, FruitsViewModel.AddFruitCommandProperty);
            ToolbarItems.Add(toolbarItem);
            
            Content = FruitsListView();
        }

        private ListView FruitsListView()
        {
            var listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof (FruitViewCell))
            };

            listView.ItemTapped += (sender, args) =>
            {
                var vm = args.Item as FruitViewCellViewModel;
                listView.SelectedItem = null;
                if (vm == null) return;
                ((FruitsViewModel) BindingContext).ViewFruitCommand.Execute(vm);
            };
            listView.SetBinding(ListView.ItemsSourceProperty, FruitsViewModel.FruitsListProperty);

            return listView;
        }
    }
}
