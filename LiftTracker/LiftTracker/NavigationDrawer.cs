using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LiftTracker
{
    public class NavigationDrawer : MasterDetailPage
    {
        private ListView listView;

        // Format navigation bar contents
        public NavigationDrawer()
        {
            this.Title = "Navigation Drawer";
            string[] myPageNames = { "Workouts", "Workouts History", "Create Workout" };

            listView = new ListView
            {
                ItemsSource = myPageNames
            };

            this.Master = new ContentPage
            {
                Title = "Options",
                Content = listView,
            };

            listView.ItemTapped += TapAction;

            this.Detail = new NavigationPage(new WorkoutsPage());

        }

        // Handle navigation when tap activated
        private void TapAction(object sender, ItemTappedEventArgs e)
        {
            ContentPage gotoPage;
            switch (e.Item.ToString())
            {
                case "Workouts":
                    gotoPage = new WorkoutsPage();
                    break;
                case "Workouts History":
                    gotoPage = new WorkoutsHistoryPage();
                    break;
                case "Create Workout":
                    gotoPage = new CreateWorkoutPage();
                    break;
                default:
                    gotoPage = new WorkoutsPage();
                    break;
            }
            this.Detail = new NavigationPage(gotoPage);
            ((ListView)sender).SelectedItem = null;
            this.IsPresented = false;
        }
    }
}
