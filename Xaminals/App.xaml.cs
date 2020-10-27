
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KeBei.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KeBei
{
    public partial class App : Application
    {
        static Database database;

        static DataBClass bclass_database;
        static DataCurriculum curriculum_database;
        static DataIdea idea_database;
        public static Database Database_Subject
        {
            get
            {
                if(database==null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Subject1.db3"));
                }
                return database;
            }
        }
        public static DataBClass Database_BClass
        {
            get
            {
                if (bclass_database == null)
                {
                    bclass_database = new DataBClass(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BClass.db3"));
                }
                return bclass_database;
            }
        }
        public static DataCurriculum Database_Curriculum
        {
            get
            {
                if (curriculum_database == null)
                {
                    curriculum_database = new DataCurriculum(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Curriculum.db3"));
                }
                return curriculum_database;
            }
        }
        public static DataIdea Database_Idea
        {
            get
            {
                if (idea_database == null)
                {
                    idea_database = new DataIdea(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Idea.db3"));
                }
                return idea_database;
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
