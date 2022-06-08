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

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null)
        {
            // Navigate to the NoteEntryPage, passing the ID as a query parameter.
            Item item = (Item)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new ItemDetailPage(item.Id));
        }
    }
}