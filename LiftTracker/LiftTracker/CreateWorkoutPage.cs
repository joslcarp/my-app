using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using LiftTracker.Models;

namespace LiftTracker
{
    class CreateWorkoutPage : ContentPage
    {
        Entry workoutName;
        Entry exerciseName;
        Entry sets;
        Entry reps;
        Entry weight;

        public CreateWorkoutPage()
        {
            this.Title = "Create a Workout";

            workoutName = new Entry
            {
                Placeholder = "Enter workout name",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };

            exerciseName = new Entry
            {
                Placeholder = "Enter exercise name",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };

            sets = new Entry
            {
                Placeholder = "Enter sets",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };

            reps = new Entry
            {
                Placeholder = "Enter reps",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };

            weight = new Entry
            {
                Placeholder = "Enter starting weight",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };


            Button submit = new Button
            {
                Text = "Create Workout",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            submit.Clicked += SubmitWorkout;

            Button view = new Button
            {
                Text = "View Workouts",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            view.Clicked += ViewWorkout;

            Content = new StackLayout
            {
                Children = {
                    workoutName,
                    exerciseName,
                    sets,
                    reps,
                    weight,
                    submit,
                    view
                }
            };
            this.Padding = 20;
            this.Appearing += TitlePage_Appearing;
        }

        private void TitlePage_Appearing(object sender, EventArgs e)
        {
            workoutName.Text = "";
            exerciseName.Text = "";
            sets.Text = "";
            reps.Text = "";
            weight.Text = "";
        }

        //Create workout Item and push to Workouts page
        private async void SubmitWorkout(object sender, EventArgs e)
        {
            if (workoutName.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter a workout name", "OK");
            }
            else if (exerciseName.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter an exercise name", "OK");
            }
            else if (sets.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter number of sets", "OK");
            }
            else if (reps.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter number of reps", "OK");
            }
            else if (weight.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter weight", "OK");
            }
            else
            {
                Item item = new Item
                {
                    WorkoutName = workoutName.Text,
                    ExerciseName = exerciseName.Text,
                    Sets = sets.Text,
                    Reps = reps.Text,
                    Weights = weight.Text                    
                };

                await Navigation.PushAsync(new WorkoutsPage(item));
            }
        }

        // Push to workouts page without creating new workout item
        private async void ViewWorkout(object sender, EventArgs e)
        {
            Item item = new Item
            {
                ID = -1   // use this to avoid pushing new item to database
            };
            await Navigation.PushAsync(new WorkoutsPage(item));
        }

    }
}
