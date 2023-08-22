﻿using System;
using System.Collections.Generic;

namespace Infrastructure.ServiceLocatorModule
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        
        public static ServiceLocator Instance { get; } = new ServiceLocator();

        public T GetService<T>() where T : IService
        {
            Type type = typeof(T);

            IService value;

            if (!_services.TryGetValue(type, out value))
                throw new ArgumentException();

            return (T)value; 
        }

        public void Register<T>(T service) where T : IService
        {
            Type type = service.GetType();

            _services.Add(type, service);
        }

        public void UnRegister<T>(T service) where T : IService
        {
            Type type = service.GetType();

            if (!_services.Remove(type))
                throw new ArgumentException();
        }
    }
}
