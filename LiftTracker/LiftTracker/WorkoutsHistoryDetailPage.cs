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
    class WorkoutsHistoryDetailPage : ContentPage
    {
        Label completedDate;
        Label itemID;
        Label workoutName;
        Label exerciseName;
        Label setsCount;
        Label repsCount;
        Label weightCount;

        public WorkoutsHistoryDetailPage(ItemHistory item)
        {
            this.Title = item.WorkoutName;

            completedDate = new Label
            {
                Text = "Completed on " + item.CompletedTime,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            itemID = new Label
            {
                Text = "Table ID: " + item.IdNumber(),
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

            weightCount = new Label
            {
                Text = "Weights: " + item.Weights,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };                     

            StackLayout pageStack = new StackLayout
            {
                Children =
                {
                    completedDate,
                    itemID,
                    exerciseName,
                    setsCount,
                    repsCount,
                    weightCount,
                },
                HeightRequest = 1500
            };

            this.Content = pageStack;
            this.Padding = 25;

        }
    }
}
