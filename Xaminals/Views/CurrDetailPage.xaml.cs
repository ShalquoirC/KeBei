using System;
using Xamarin.Forms;

using KeBei.Models;


namespace KeBei.Views
{
    public partial class CurrDetailPage : ContentPage
    {
        public CurrDetailPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var cur = (Curriculum)BindingContext;
            await App.Database_Curriculum.SaveCurriculumAsync(cur);
            await Navigation.PopAsync();
        }
    }
}
    