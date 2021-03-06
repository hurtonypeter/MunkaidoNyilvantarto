﻿using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Identity;
using MunkaidoNyilvantarto.Common.ErrorHandling;
using MunkaidoNyilvantarto.Data.Entity;
using MunkaidoNyilvantarto.Data.Repository;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MunkaidoNyilvantarto
{
    public partial class Startup
    {
        public void ConfigureDI(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // db context
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            // ASP.NET Identity
            builder.RegisterType<ApplicationUserStore>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ApplicationRoleStore>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest(); 
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            //saját üzleti logikák
            builder.RegisterAssemblyTypes(Assembly.Load("MunkaidoNyilvantarto.BLL")).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            // AutoMapper config
            builder.RegisterType<EntityMappingProfile>().As<Profile>();
            builder.Register(ctx => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
                .AsImplementedInterfaces().SingleInstance()
                .OnActivating(x =>
                {
                    foreach (var profile in x.Context.Resolve<IEnumerable<Profile>>())
                    {
                        x.Instance.AddProfile(profile);
                    }
                });
            builder.RegisterType<MappingEngine>().As<IMappingEngine>().SingleInstance();

            // global filters
            builder.Register(c => new JsonHandleErrorAttribute()).AsExceptionFilterFor<Controller>().InstancePerRequest();
            builder.RegisterFilterProvider();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}