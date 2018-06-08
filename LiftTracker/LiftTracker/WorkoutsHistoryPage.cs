using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;  

using Xamarin.Forms;
using LiftTracker.Models;

namespace LiftTracker
{
    class WorkoutsHistoryPage : ContentPage
    {
        ListView listView;

        public WorkoutsHistoryPage()
        {
            Title = "Workout History";
            this.Padding = 20;

            listView = new ListView();

            this.Content = listView;

            listView.ItemTapped += OnTap;
        }

        protected override async void OnAppearing()
        {
            // Query database for list of all workout history Items
            listView.ItemsSource = await App.Database.GetItemsHistoryAsync();
        }

        // Go to workout history detail page
        private async void OnTap(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ItemHistory;

            await Navigation.PushAsync(new WorkoutsHistoryDetailPage(item));
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}
