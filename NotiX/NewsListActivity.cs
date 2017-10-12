using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotiX.Core.Services;
using NotiX.Adapter;
using NotiX.Core.Models;
using SQLite;
using NotiX.Fragments;

namespace NotiX
{
    [Activity(Label = "NotiX", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class NewsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.NewsList);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

           var tapHeaderAllNews = Resources.GetString(Resource.String.NewsListActivity_Tabs_Allnews_Header);
           var tapHeaderSavedNews = Resources.GetString(Resource.String.NewsListActivity_Tabs_SavedNews_Header);

            AddTab(tapHeaderAllNews, new AllNewsListFragment());
            AddTab(tapHeaderSavedNews, new SavedNewsListFragment());

        }

        private void AddTab(string tabTitle, Fragment fragment)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var previousFragment = FragmentManager.FindFragmentById(Resource.Id.newsListFragmentContainer);
                if (previousFragment != null)
                {
                    e.FragmentTransaction.Remove(previousFragment);
                }
                e.FragmentTransaction.Add(Resource.Id.newsListFragmentContainer, fragment);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(fragment);
            };

            ActionBar.AddTab(tab);


        }
    }
}