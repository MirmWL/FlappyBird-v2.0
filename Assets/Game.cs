using UnityEngine;

public class Game : MonoBehaviour
{
    private IPredicate[] _gameEnds;
    private GameUpdates _gameUpdates;

    private bool _isActive;
    
    public void Init(IPredicate[] gameEnds, GameUpdates gameUpdates)
    {
        _gameUpdates = gameUpdates;
        _gameEnds = gameEnds;

        _isActive = true;
    }

    private void Update()
    {
        if (_isActive == false)
            return;
        
        _gameUpdates.Update();
        
        foreach (var end in _gameEnds)
        {
            if(end.Execute())
                EndGame();
        }
    }

    private void EndGame()
    {
        _gameUpdates.StopUpdate();
        Debug.Log("конец");
    }
}