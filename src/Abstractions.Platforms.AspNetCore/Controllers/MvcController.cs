using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps.Abstractions.Platforms.AspNetCore.Controllers
{
    public class MvcController<TDbContext, TEntity> : Controller
        where TDbContext : DbContext
        where TEntity : class
    {
    }

    //public class MvcController<TDbContext, TEntity> : Controller
    //    where TDbContext : DbContext
    //    where TEntity : class
    //{
    //}
}
