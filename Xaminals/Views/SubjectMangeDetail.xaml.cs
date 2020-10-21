using System;
using Xamarin.Forms;
using KeBei.Models;


namespace KeBei.Views
{
    
    public partial class SubjectMangeDetail : ContentPage
    {
        
        public SubjectMangeDetail()
        {
            InitializeComponent();
            //var subject = (Subject)BindingContext;
            //if(subject.ID==0)
            //{
            //    Button buttonA = new Button();
            //    buttonA.Text = "保存";
            //    buttonA.HorizontalOptions = LayoutOptions.Center;
            //    buttonA.Clicked += OnSaveButtonClicked;

            //    Button buttonB = new Button();
            //    buttonB.Text = "删除";
            //    buttonA.HorizontalOptions = LayoutOptions.Center;
            //    buttonB.Clicked += OnDeleteButtonClicked;
            //}
        }





        async void OnSaveButtonClicked(object sender,EventArgs e)
        {
            var subject = (Subject)BindingContext;
            subject.StartDate = DateTime.UtcNow;

            await App.Database_Subject.SaveSubjectAsync(subject);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            await App.Database_Subject.DeleteSubjectAsync(subject);
            await Navigation.PopAsync();
        }
    }
}