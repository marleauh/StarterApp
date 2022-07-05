using App.Models;

namespace App.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ItemDetailPage : ContentPage
{
    public int ItemId
    {
        set
        {
            LoadItem(value);
        }
    }
    public ItemDetailPage()
	{
		InitializeComponent();

        BindingContext = new Item();
    }
    public ItemDetailPage(int itemId)
    {
        InitializeComponent();

        ItemId = itemId;
    }

    async void LoadItem(int itemId)
    {
        try
        {
            Item item = await App.Database.GetItemAsync(itemId);
            BindingContext = item;
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to load item.");
        }
    }
    
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var item = (Item)BindingContext;
        if (!string.IsNullOrWhiteSpace(item.ItemName))
        {
            await App.Database.DeleteItemAsync(item);
        }

        await Navigation.PopAsync();
    }
}