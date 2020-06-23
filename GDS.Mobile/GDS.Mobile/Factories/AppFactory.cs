using AutoMapper;
using CommonServiceLocator;
using GDS.Core.Data.Mobile;
using GDS.Core.Logging;
using GDS.Core.Models;
using GDS.Core.Services;
using GDS.Data.Mobile;
using GDS.Data.Mobile.DataStores;
using GDS.Mobile.Core.Services;
using GDS.Mobile.Mappings;
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

            //Mappers
            _iocContainer.RegisterInstance(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper());

            //Data
            _iocContainer.RegisterSingleton<IMobileContext, Context>();
            _iocContainer.RegisterType<IDataStore<Bible>, BibleDataStore>();
            _iocContainer.RegisterType<IDataStore<BibleBook>, BibleBookDataStore>();

            //Logger
            _iocContainer.RegisterType<ILogger, Logger>(new HierarchicalLifetimeManager());

            //API
            _iocContainer.RegisterType<IRestService, RestService>(new HierarchicalLifetimeManager());

            //Shared
            _iocContainer.RegisterSingleton<ISharedService, SharedService>();

            //Services
            _iocContainer.RegisterType<IVerseService<Verse>, VerseService>(new HierarchicalLifetimeManager());
            _iocContainer.RegisterType<IBibleService<Bible>, BibleService>(new HierarchicalLifetimeManager());
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