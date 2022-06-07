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

        // Changes the label based on what the ItemName is
        label.IsVisible = true;
        label.Text = item.ItemName + " was added to the database!";
    }
}