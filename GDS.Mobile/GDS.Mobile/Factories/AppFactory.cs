using Autofac;
using Autofac.Core;
using GDS.Core.Data;
using GDS.Data.Mobile.DataStore;
using GDS.Mobile.Services;
using GDS.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace GDS.Mobile.Factories
{
    public static class AppFactory
    {
        private static IContainer _container;
        private static readonly ContainerBuilder builder = new ContainerBuilder();

        static AppFactory()
        {
            DependencyResolver.ResolveUsing(type => _container.IsRegistered(type) ? _container.Resolve(type) : null);

            //Data
            if (App.UseMockDataStore)
                RegisterSingleton<IDataStore, MockDataStore>();
            else
                RegisterSingleton<IDataStore, LocalDataStore>();

            //ViewModels
            RegisterType<LoginViewModel>();
            RegisterType<BibleViewModel>();
        }

        public static void Dispose()
        {
            if (_container != null)
                _container.Dispose();
        }

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>().As<TInterface>();
        }

        public static void RegisterType<T>() where T : class
        {
            builder.RegisterType<T>();
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>().As<TInterface>().SingleInstance();
        }

        public static T GetInstance<T>() where T : class
        {
            return _container.Resolve(typeof(T)) as T;
        }

        public static void Build()
        {
            _container = builder.Build();
        }

        public static void RegisterTypeWithParameters<T>(Type param1Type, object param1Value, Type param2Type, string param2Name) where T : class
        {
            builder.RegisterType<T>()
                   .WithParameters(new List<Parameter>()
            {
            new TypedParameter(param1Type, param1Value),
            new ResolvedParameter(
                (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
                (pi, ctx) => ctx.Resolve(param2Type))
            });
        }

        public static void RegisterTypeWithParameters<TInterface, T>(Type param1Type, object param1Value, Type param2Type, string param2Name) where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>()
                   .WithParameters(new List<Parameter>()
            {
            new TypedParameter(param1Type, param1Value),
            new ResolvedParameter(
                (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
                (pi, ctx) => ctx.Resolve(param2Type))
            }).As<TInterface>();
        }
    }
}