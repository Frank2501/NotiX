using Android.App;
using Android.Widget;
using Android.OS;
using NotiX.Core.Services;
using Square.Picasso;
using System;
using Android.Views;
using NotiX.Core.Models;

namespace NotiX
{
    [Activity(Label = "NotiX", Icon = "@drawable/icon", ParentActivity = typeof(NewsListActivity))]
    public class MainActivity : Activity
    {
        internal static string KEY_ID = "KEY_ID";
        private News _news;
        private readonly string KEY_BODY = "KEY_BODY";
        private readonly string KEY_IMAGE_NAME = "KEY_IMAGE_NAME";
        private readonly string KEY_TITLE = "KEY_TITLE";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            PrepareActionBar();

            var id = Intent.Extras.GetInt(KEY_ID);

            if (bundle == null)
            {
                var newsService = new NewsService();
                _news = newsService.GetNewsById(id);
            }
            else
            {
                _news = new News();
                _news.Id = bundle.GetInt(KEY_ID);
                _news.Body = bundle.GetString(KEY_BODY);
                _news.ImageName = bundle.GetString(KEY_IMAGE_NAME);
                _news.Title = bundle.GetString(KEY_TITLE);

            }
            

            var newsTitle = FindViewById<TextView>(Resource.Id.newsTitle);
            var newsBody = FindViewById<TextView>(Resource.Id.newsBody);
            var newsImage = FindViewById<ImageView>(Resource.Id.newsImage);

            var display = WindowManager.DefaultDisplay;
            Android.Graphics.Point point = new Android.Graphics.Point();
            display.GetSize(point);

            var imageURL = string.Concat(ValuesService.ImageBaseURL, _news.ImageName);

            Picasso.With(ApplicationContext)
                .Load(imageURL)
                .Resize(point.X, 0)
                .Into(newsImage);


            newsTitle.Text = _news.Title;
            newsBody.Text = _news.Body;
        
        }

        private void PrepareActionBar()
        {
            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(KEY_BODY, _news.Body);
            outState.PutInt(KEY_ID, _news.Id);
            outState.PutString(KEY_IMAGE_NAME, _news.ImageName);
            outState.PutString(KEY_TITLE, _news.Title);


            base.OnSaveInstanceState(outState);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.NewsActionMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.read_later_white:
                    HandleReadLater();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

            
        }

        private void HandleReadLater()
        {
            try
            {
                var newsLocalService = new NewsLocalService();
                newsLocalService.Save(_news);
                Toast.MakeText(this, "Noticia Guardada", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "error: " + ex.Message, ToastLength.Long).Show();
            }
        }
    }
}

