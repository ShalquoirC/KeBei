using System;
using Xamarin.Forms;
using KeBei.Models;


namespace KeBei.Views
{
    
    public partial class SubjectMangeView : ContentPage
    {
        
        public SubjectMangeView()
        {
            
            InitializeComponent();
        }
        async void OnSubjectAddedClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            
            await Navigation.PushAsync(new SubjectMangeDetail
            {
                BindingContext = subject
            }); ;
            await Navigation.PopModalAsync();
        }
    }
}