using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LiftTracker
{
	public partial class App : Application
	{

        // Create database field variable
        private static ItemDatabase database;

        // Read-Only property to access database
        public static ItemDatabase Database
        {
            get
            {
                // if the database hasn't been created, then create.
                if (database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MySQLite.db3"));
                }
                return database;
            }
        }

        public App ()
		{
			InitializeComponent();

            //MainPage = new LiftTracker.MainPage();
            MainPage = new NavigationDrawer();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
