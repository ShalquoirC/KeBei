using KeBei.Models;
using System;
using Xamarin.Forms;

namespace KeBei.Views
{
    public partial class CurrPage : ContentPage
    {
     
        public CurrPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database_Curriculum.GetCurriculumsAsync();
        }
        async void OnCurrAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CurrDetailPage
            {
                BindingContext = new Curriculum()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CurrDetailPage
                {
                    BindingContext = e.SelectedItem as Curriculum 
                });
            }
        }
    }
}
