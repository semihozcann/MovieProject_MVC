using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Conctere.EntityFramework.Context;
using DataAccess.Conctere.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<MovieProjectContext>().As<DbContext>().SingleInstance();


            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();


        }
    }
}
