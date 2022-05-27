using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand GitHubCommand { get; }
        public MainPageViewModel()
        {
            // Opens GitHub in your device's default browser
            GitHubCommand = new Command(async () => await Browser.OpenAsync("https://github.com/marleauh/"));
        }
    }
}
