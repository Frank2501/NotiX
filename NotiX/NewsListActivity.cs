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

namespace NotiX
{
    [Activity(Label = "NotiX", MainLauncher = true)]
    public class NewsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewsList);

            var newsListView = FindViewById<ListView>(Resource.Id.newsListView);

            var newsServices = new NewsService();
            var news = newsServices.GetNews();

            newsListView.Adapter = new NewsListAdapter(this, news);

            newsListView.ItemClick += NewsListView_ItemClick;

        }

        private void NewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            var id = (int)e.Id;
            intent.PutExtra(MainActivity.KEY_ID, id);
            StartActivity(intent);
        }
    }
}