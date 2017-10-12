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
using NotiX.Core.Models;
using NotiX.Adapter;

namespace NotiX.Fragments
{
    public class AllNewsListFragment : BaseNewsListFragment
    {
        private NewsService _newsService;

        public AllNewsListFragment()
        {
            _newsService = new NewsService();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            if (!_news.Any())
            {
                _news = _newsService.GetNews();
            }

            SetupFragment();
        }
    }    
}