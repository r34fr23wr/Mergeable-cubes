using System;
using System.Collections.Generic;

public class ServiceLocator
{
    public static ServiceLocator Instance { get; private set;}
    private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public ServiceLocator() => Instance = this;

    public void Register<T>(T service) where T : IService
    {
        var type = typeof(T);

        if (_services.ContainsKey(type)) throw new Exception($"Service of type {type} is already registered.");

        _services[type] = service;
    }

    public void Unregister<T>(T service) where T : IService
    {
        var type = typeof(T);

        if (_services.ContainsKey(type)) _services.Remove(type);
    }

    public T Get<T>() where T : IService
    {
        var type = typeof(T);

        if (!_services.ContainsKey(type)) throw new Exception($"Service of type {type} is not registered.");

        return (T)_services[type];
    }
}