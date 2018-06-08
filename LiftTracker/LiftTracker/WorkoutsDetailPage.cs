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
    class WorkoutsDetailPage : ContentPage 
    {
        Label itemID;
        Label workoutName;
        Label exerciseName;
        Label setsCount;
        Label repsCount;
        Entry weight;
        Button logWorkout;
        Label warning;
        
        
        public WorkoutsDetailPage(Item item)
        {
            this.Title = item.ToString();

            itemID = new Label
            {
                Text = "Table ID: " + item.ID,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            workoutName = new Label
            {
                Text = item.WorkoutName,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            exerciseName = new Label
            {
                Text = "Exercises: " + item.ExerciseName,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            setsCount = new Label
            {
                Text = "Sets: " + item.Sets,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            repsCount = new Label
            {
                Text = "Reps: " + item.Reps,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            weight = new Entry
            {

                Text = item.Weights,
                HorizontalOptions = LayoutOptions.StartAndExpand,   
                                                                    
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,                           
                WidthRequest = 200
            };

            logWorkout = new Button
            {
                Text = "Log this workout",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            // Warning for user not filling in data
            warning = new Label
            {
                Text = "",
                TextColor = Color.Red,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            logWorkout.Clicked += AddWorkoutHistory;

            StackLayout pageStack = new StackLayout
            {
                Children =
                {
                    itemID,
                    exerciseName,
                    setsCount,
                    repsCount,
                    weight,
                    logWorkout,
                    warning
                },
                HeightRequest = 1500
            };

            this.Content = pageStack;
            this.Padding = 25;

        }

        // Create ItemHistory object from current workout Item, save to History table
        private async void AddWorkoutHistory(object sender, EventArgs e)
        {
            warning.Text = "";

            if(weight.Text == "")
            {
                warning.Text = "Please enter weight values";
                return;
            }

            ItemHistory addItem = new ItemHistory
            {
                WorkoutName = workoutName.Text,
                ExerciseName = exerciseName.Text,
                Sets = setsCount.Text,
                Reps = repsCount.Text,
                Weights = weight.Text,
                CompletedTime = DateTime.Now.ToShortDateString()
            };

            await App.Database.SaveItemHistoryAsync(addItem);

        }


    }
}
