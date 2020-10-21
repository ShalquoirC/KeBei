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
            var subject = (Subject)BindingContext;
            //var subject = (Subject)BindingContext;
            //if (subject.Name==null)

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

        //private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        //{
        //    var subject = (Subject)BindingContext;
        //    subject.EndDate=
        //}
    }
}