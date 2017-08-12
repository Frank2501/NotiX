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
using NotiX.Core.Data;
using NotiX.Core.Models;

namespace NotiX.Core.Services
{
   public class NewsService
    {
        private NewsRepository _newsRepository;

        public NewsService()
        {
            _newsRepository = new NewsRepository();
        }

        public List<News> GetNews()
        {
            return _newsRepository.GetNews();
        }


        public News GetNewsById(int Id)
        {
            return _newsRepository.GetNewsById(Id);
        }


    }
}