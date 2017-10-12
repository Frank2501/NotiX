﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;


namespace NotiX.Core.Models
{
   public class News
    {
        [PrimaryKey]
        public int Id { get; set; }
        public String Title { get; set; }
        [Ignore]
        public String Body { get; set; }    
        public String ImageName { get; set; }
    }
}