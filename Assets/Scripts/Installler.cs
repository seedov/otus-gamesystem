using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class InjectAttribute : Attribute
{

}
public static class DependencyInjector
{
    public static void Inject(MonoBehaviour mb)
    {
        var monobehaviourType = mb.GetType();
        var properties = monobehaviourType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
        foreach(var property in properties)
        {
            if (property.IsDefined(typeof(InjectAttribute), true))
            {
                var propertyType = property.FieldType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    var p = propertyType.GetGenericArguments()[0];
                    var allListeners = ServiceLocator.GetListeners(p);
                    property.SetValue(mb, allListeners);
                }
            }
        }
    }
}

public static class ServiceLocator 
{
    private static Dictionary<Type, IEnumerable<object>> services = new();

    public static void AddListeners<T>(IEnumerable<object> service)
    {
        services[typeof(T)] = service;
    }
    public static IEnumerable<T> GetListeners<T>() where T : class
    {
        return services[typeof(T)] as IEnumerable<T>;
    }

    public static IEnumerable<object> GetListeners(Type t)
    {
        return services[t];
    }
}

public class Installler : MonoBehaviour
{
    public static Installler instance;

    private IUpdatable[] updatables = null;
    private IGameStateListener[] gameStateListeners = null;
    private IUserInputListener[] userInputListeners = null;


    public IEnumerable<IUpdatable> GetAllUpdatables()
    {
        if (instance.updatables == null)
            instance.updatables = instance.GetComponentsInChildren<IUpdatable>();
        return instance.updatables;
    }

    public IEnumerable<IGameStateListener> GetAllGameStateListeners()
    {
        if (gameStateListeners == null)
            gameStateListeners = GetComponentsInChildren<IGameStateListener>();
        return gameStateListeners;
    }

    public IEnumerable<IUserInputListener> GetAllUserInputListeners()
    {
        if (userInputListeners == null)
            userInputListeners = GetComponentsInChildren<IUserInputListener>();
        return userInputListeners;
    }

    private void Awake()
    {
        instance = this;
        ServiceLocator.AddListeners<IUpdatable>(instance.GetAllUpdatables());
        ServiceLocator.AddListeners<IGameStateListener>(instance.GetAllGameStateListeners());
        ServiceLocator.AddListeners<IUserInputListener>(instance.GetAllUserInputListeners());

        var allMonobehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach(var mb in allMonobehaviours)
        {
            DependencyInjector.Inject(mb);
        }
    }


}
