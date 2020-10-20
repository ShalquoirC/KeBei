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
        }
        async void OnSaveButtonClicked(object sender,EventArgs e)
        {
            var subject = (Subject)BindingContext;
            subject.StartDate = DateTime.UtcNow;
            //subject.Details = null;
            //subject.EndDateString= null;
            //subject.CourseWare = null;
            //subject.ImageUrl = null;
            await App.Database.SaveSubjectAsync(subject);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            await App.Database.DeleteSubjectAsync(subject);
            await Navigation.PopAsync();
        }
    }
}