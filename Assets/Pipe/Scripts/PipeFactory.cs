using UnityEngine;
using Object = UnityEngine.Object;

public class PipeFactory : IMonoFactory<Pipe>
{
    private readonly Pipe _prefab;

    public PipeFactory(Pipe prefab)
    {
        _prefab = prefab;
    }
    
    public Pipe Create(Vector3 position)
    {
        var pipe = Object.Instantiate(_prefab, position, Quaternion.identity);
        return pipe;
    }
}