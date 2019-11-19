﻿using DataBinding.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBinding
{
    public partial class App : Application
    {
        
        private static ProductsDatabase database;


    public static ProductsDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ProductsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.db3"));
            }
            return database;
        }
    }

   
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
