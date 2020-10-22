using System;
using Xamarin.Forms;
using KeBei.Models;

namespace KeBei.Views
{

    public partial class SubjectMange : ContentPage
    {
        public SubjectMange()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database_Subject.GetSubjectsAsync();
        }



        async void OnSubjectAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SubjectMangeDetail
            {
                BindingContext = new Subject()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new SubjectMangeView
                {
                    BindingContext = e.SelectedItem as Subject
                });
            }
        }

        //async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string catName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
        // This works because route names are unique in this application.
        //await Shell.Current.GoToAsync($"catdetails?name={catName}");
        // The full route is shown below.
        // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        //}
    }
}