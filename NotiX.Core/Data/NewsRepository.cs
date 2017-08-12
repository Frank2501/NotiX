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
using NotiX.Core.Models;

namespace NotiX.Core.Data
{
    public class NewsRepository
    {
        private List<News> _news;

        public NewsRepository()
        {
            _news = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "Noticia desde el repositorio",
                    Body = "Xamarin es una compañía de software estadounidense, propiedad de Microsoft y con sede principal en San Francisco (California), fundada en mayo de 2011 por Nat Friedman y Miguel de Icaza (que iniciaron el Proyecto Mono)",
                   ImageName = "noticia1.png"
                },
                 new News()
                {
                    Id = 2,
                    Title = "ASP.NET MVC 5",
                    Body = "ASP.NET es un entorno para aplicaciones web desarrollado y comercializado por Microsoft. Es usado por programadores y diseñadores para construir sitios web dinámicos, aplicaciones web y servicios web XML. Apareció en enero de 2002 con la versión 1.0 del .NET Framework, y es la tecnología sucesora de la tecnología Active Server Pages (ASP). ASP.NET está construido sobre el Common Language Runtime, permitiendo a los programadores escribir código ASP.NET usando cualquier lenguaje admitido por el .NET Framework.",
                    ImageName = "noticia2.png"
                },
                  new News()
                {
                    Id = 3,
                    Title = "Angular Js",
                    Body ="Xamarin es una compañía de software estadounidense, propiedad de Microsoft y con sede principal en San Francisco(California), fundada en mayo de 2011 por Nat Friedman y Miguel de Icaza(que iniciaron el Proyecto Mono)",
                    ImageName = "noticia3.png"
                },
            };
        }
        public List<News> GetNews()
        {
            return _news;
        }
        public News GetNewsById(int Id)
        {
            return _news.FirstOrDefault(x => x.Id == Id);
        }

    }
}