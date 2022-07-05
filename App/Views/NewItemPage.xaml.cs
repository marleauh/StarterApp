using App.Models;
using App.ViewModels;

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

        await Navigation.PopAsync();
    }
}