using System.Collections.Generic;

using UnityEngine;

public class Storage<T> : IMonoFactory<T> where T : MonoBehaviour
{
    private readonly IMonoFactory<T> _factory;
    private readonly List<T> _objects;

    public Storage(IMonoFactory<T> factory)
    {
        _factory = factory;
        _objects = new List<T>();
    }

    public IEnumerable<T> Objects => _objects;

    public T Create(Vector3 position)
    {
        var instanceOfObject = _factory.Create(position);
        
        _objects.Add(instanceOfObject);
        
        return instanceOfObject;
    }
}