using System.Linq;
using UnityEngine;

public class PipeGenerator : IGameUpdate
{
    private readonly Storage<Pipe> _storage;
    private readonly Vector3 _bound;
    private readonly Rect _spread;

    public PipeGenerator(Storage<Pipe> storage, Rect spread, Vector3 startSpawnPosition, Vector3 bound, int pipesCount)
    {
        _storage = storage;
        _spread = spread;
        _bound = bound;

        _storage.Create(startSpawnPosition);
        
        for (int i = 0; i < pipesCount; i++)
            _storage.Create(GetPlacePosition(GetRightestPipe()));
    }

    public void GameUpdate()
    {
        foreach (var pipe in _storage.Objects)
        {
            if (pipe.transform.position.x < _bound.x)
                pipe.transform.position = GetPlacePosition(pipe);
        }
    }

    private Vector3 GetPlacePosition(Pipe pipe)
    {
        var position = pipe.transform.position;
        var randomPosition = new RandomPosition(_spread.min, _spread.max);
       
        return new Vector2(randomPosition.Get().x + position.x, randomPosition.Get().y);
    }

    private Pipe GetRightestPipe()
    {
        float rightestXPosition = _storage.Objects.Max(s => s.transform.position.x);
        return _storage.Objects.FirstOrDefault(s => s.transform.position.x == rightestXPosition);
    }
}
