using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Web.Common;
using System.Data.Entity;
using BLL.Services;
using BLL.Interface.Services;
using DAL.Interface.Interfaces;
using DAL.Realization;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<ForumModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<ForumModel>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IRoleUserService>().To<RoleUserService>();
            kernel.Bind<IRoleUserRepository>().To<RoleUserRepository>();
            kernel.Bind<ISectionService>().To<SectionService>();
            kernel.Bind<ISectionRepository>().To<SectionRepository>();
            kernel.Bind<IThemeService>().To<ThemeService>();
            kernel.Bind<IThemeRepository>().To<ThemeRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<IMessageService>().To<MessageService>();
        }
    }
}
