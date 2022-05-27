using App.Models;

namespace App.Views;

public partial class NewItemPage : ContentPage
{
	public NewItemPage()
	{
		InitializeComponent();

        BindingContext = new Item();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var item = (Item)BindingContext;
        if (!string.IsNullOrWhiteSpace(item.ItemName))
        {
            // Saves the current data that was entered into the form and puts it into the db
            await App.Database.SaveItemAsync(item);
        }
        await Shell.Current.GoToAsync("ItemListPage");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MainPage");
    }
}