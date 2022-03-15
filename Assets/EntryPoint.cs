using Birds;

using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Bird _bird;
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
        
        _bird.Init();
        
        var gameUpdates = new GameUpdates();
        gameUpdates.AddToUpdateList(_bird);
        gameUpdates.AddToUpdateList(pipeGenerator);

        _game.Init(new BirdDead(_bird), gameUpdates);
    }
}