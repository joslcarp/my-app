using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LiftTracker.Models
{
    public class Item
    {
        // Add an attribute to the class identifying the primary key 
        // for storing item in table
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string WorkoutName { get; set; }
        public string ExerciseName { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
        public string Weights { get; set; }

        public override string ToString()
        {
            return $"{WorkoutName}";
        }

        public string IdNumber()
        {
            return $"{ID}";
        }

        public string Exercise()
        {
            return $"{ExerciseName}";
        }

        public string SetCount()
        {
            return $"{Sets}";
        }

        public string RepCount()
        {
            return $"{Reps}";
        }

        public string WeightAmount()
        {
            return $"{Weights}";
        }
        
    }
}
