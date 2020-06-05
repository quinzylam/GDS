﻿using CommonServiceLocator;
using GDS.Core.Logging;
using GDS.Core.Models;
using GDS.Core.Services;
using GDS.Data.Mobile;
using GDS.Mobile.Core.Services;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;
using Xamarin.Forms.Internals;

namespace GDS.Mobile.Factories
{
    public static class AppFactory
    {
        private static readonly IUnityContainer _iocContainer = new UnityContainer();

        static AppFactory()
        {
            DependencyResolver.ResolveUsing(type => _iocContainer.IsRegistered(type) ? _iocContainer.Resolve(type) : null);

            //Data
            _iocContainer.RegisterSingleton<IMobileContext, Context>();

            //Logger
            _iocContainer.RegisterType<ILogger, Logger>(new HierarchicalLifetimeManager());

            //API
            _iocContainer.RegisterType<IRestService, RestService>(new HierarchicalLifetimeManager());

            //Shared
            _iocContainer.RegisterSingleton<ISharedService, SharedService>();

            //Services
            _iocContainer.RegisterType<IVerseService<Verse>, VerseService>(new HierarchicalLifetimeManager());
            _iocContainer.RegisterType<IBibleBookService<BibleBook>, BibleBookService>(new HierarchicalLifetimeManager());
            _iocContainer.RegisterType<IBookService<Book>, BookService>(new HierarchicalLifetimeManager());
        }

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _iocContainer.RegisterType<TInterface, T>();
        }

        public static T GetInstance<T>()
        {
            return _iocContainer.Resolve<T>();
        }

        public static void RegisterService()
        {
            ServiceLocator.SetLocatorProvider(() =>
                new UnityServiceLocator(_iocContainer));
        }

        public static void Dispose()
        {
            if (_iocContainer != null)
                _iocContainer.Dispose();
        }
    }
}