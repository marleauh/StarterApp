using App.ViewModels;

namespace App.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}
    async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewItemPage());
    }
}

