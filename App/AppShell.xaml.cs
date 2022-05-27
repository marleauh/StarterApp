using App.Views;

namespace App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes below

        Routing.RegisterRoute(nameof(ItemListPage), typeof(ItemListPage));
        Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}
