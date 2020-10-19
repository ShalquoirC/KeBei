using KeBei.Data;
using KeBei.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KeBei
{
    public partial class App : Application
    {
        static DataSubject subject_database;

        public static DataSubject Database
        {
            get
            {
                if(subject_database==null)
                {
                    subject_database = new DataSubject(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Subject.db3"));
                }
                return subject_database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
