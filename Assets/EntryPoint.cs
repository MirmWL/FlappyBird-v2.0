using System.Collections.Generic;
using Birds;

using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Bird _bird1;
    [SerializeField] private Bird _bird2;
    [SerializeField] private Game _game;
    [SerializeField] private Pipe _pipe;
    [SerializeField] private Camera _camera;
    
    [SerializeField] private Transform _startSpawnPosition;
    [SerializeField] private Rect _pipeSpread;
    
    private void Awake()
    {
        Vector3 leftCameraBound = _camera.ScreenToWorldPoint(Vector2.zero);
      
        var pipeFactory = new PipeFactory(_pipe);
        var pipePool = new Storage<Pipe>(pipeFactory);
        var pipeGenerator = new PipeGenerator(pipePool, _pipeSpread, _startSpawnPosition.position, leftCameraBound, 10);
        
        _bird1.Init();
        _bird2.Init();
        
        var gameUpdates = new GameUpdates(new IGameUpdate[]
        {
            _bird1,
            _bird2,
            pipeGenerator
        });

        _game.Init(new IPredicate[]
        {
            new BirdDead(_bird1),
            new BirdDead(_bird2)
        }, gameUpdates);
    }
}