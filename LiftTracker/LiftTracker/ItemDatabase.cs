using System;
using System.Collections.Generic;
using System.Text;
using LiftTracker.Models; 
using System.Threading.Tasks; 
using SQLite;  

namespace LiftTracker
{
    public class ItemDatabase
    {
        
        readonly SQLiteAsyncConnection database;

        // Database location
        public ItemDatabase(string dbPath)
        {
            // Connect database
            database = new SQLiteAsyncConnection(dbPath);

            // Create a tables to hold workout and workout history items
            database.CreateTableAsync<Item>().Wait();
            
            database.CreateTableAsync<ItemHistory>().Wait();
        }

        // Return all workout Items
        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        //Query specific workout Item
        public Task<Item> GetItemAsync(string workoutName)
        {
            return database.Table<Item>().Where(item => item.WorkoutName == workoutName).FirstOrDefaultAsync();
        }

        //Insert workout Item to database
        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0) // When inserting Item into database, keep the ID = 0
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //Delete workout Item from database
        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }

        // Return all workout history Items
        public Task<List<ItemHistory>> GetItemsHistoryAsync()
        {
            return database.Table<ItemHistory>().ToListAsync();
        }

        //Query specific workout history Item
        public Task<ItemHistory> GetItemHistoryAsync(string workoutName)
        {
            return database.Table<ItemHistory>().Where(item => item.WorkoutName == workoutName).FirstOrDefaultAsync();
        }

        //Insert workout history Item to database
        public Task<int> SaveItemHistoryAsync(ItemHistory item)
        {
            if (item.ID != 0) // When inserting Item into database, keep the ID = 0
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //Delete workout Item from database
        public Task<int> DeleteItemHistoryAsync(ItemHistory item)
        {
            return database.DeleteAsync(item);
        }




    }
}
