﻿using System.Web;
using System.Web.Mvc;

namespace Desafio_cliente_vs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
