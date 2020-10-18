using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KeBei.Views
{
    public partial class ClassPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public ClassPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
