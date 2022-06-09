using App.Models;
using App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class ItemViewModel
    {

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemsCommand { get; }

        public ItemViewModel()
        {
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            AddItemsCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();
                var items = await App.Database.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async void OnAppearing()
        {
            await ExecuteLoadItemsCommand();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}
