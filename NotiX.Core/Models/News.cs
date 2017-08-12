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

namespace NotiX.Core.Models
{
   public class News
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public String ImageName { get; set; }
    }
}