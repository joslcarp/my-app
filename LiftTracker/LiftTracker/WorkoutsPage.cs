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
    class WorkoutsPage : ContentPage
    {
        ListView listView;

        public WorkoutsPage()
        {
            Title = "Workouts";
            this.Padding = 20;

            listView = new ListView();

            this.Content = listView;

            listView.ItemTapped += OnTap;
        }

        public WorkoutsPage(Item item)
        {
            Title = "Workouts";
            this.Padding = 20;

            // Insert workout to database
            if (item.ID != -1)
            {
                App.Database.SaveItemAsync(item);
            }

            listView = new ListView();

            this.Content = listView;

            listView.ItemTapped += OnTap;

        }

        protected override async void OnAppearing()
        {
            // Query database for list of all workout Items
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        private async void OnTap(object sender, ItemTappedEventArgs e)
        {
            string workoutName = e.Item.ToString();

            Item item = await App.Database.GetItemAsync(workoutName);

            await Navigation.PushAsync(new WorkoutsDetailPage(item));
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
        
    }
    
}
