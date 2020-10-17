using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xaminals.Data;
using Xaminals.Views;

namespace Xaminals
{
    public partial class AppShell : Shell
    {
        Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand RandomPageCommand => new Command(async () => await NavigateToRandomPageAsync());

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {

            routes.Add("catdetails", typeof(CatDetailPage));
            routes.Add("learndetails", typeof(LearnDetailPage));
            routes.Add("SubjectMange", typeof(SubjectMangeDetail));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
        //随机
        async Task NavigateToRandomPageAsync()
        {
            string destinationRoute = routes.ElementAt(rand.Next(0, routes.Count)).Key;
            string animalName = null;

            switch (destinationRoute)
            {
                case "catdetails":
                    animalName = CatData.Cats.ElementAt(rand.Next(0, CatData.Cats.Count)).Name;
                    break;

            }

            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");
            Shell.Current.FlyoutIsPresented = false;
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
