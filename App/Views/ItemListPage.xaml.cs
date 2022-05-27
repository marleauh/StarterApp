using App.Models;

namespace App.Views;

public partial class ItemListPage : ContentPage
{
    public ItemListPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Grabs the data from the db and puts in into the item list
        ItemsListView.ItemsSource = await App.Database.GetItemsAsync();
    }
}