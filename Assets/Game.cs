using UnityEngine;

public class Game : MonoBehaviour
{
    private IPredicate _isGameEnded;
    private GameUpdates _gameUpdates;

    private bool _isActive;
    
    public void Init(IPredicate isGameEnded, GameUpdates gameUpdates)
    {
        _gameUpdates = gameUpdates;
        _isGameEnded = isGameEnded;

        _isActive = true;
    }

    private void Update()
    {
        if (_isActive == false)
            return;
        
        _gameUpdates.Update();
        
        if (_isGameEnded.Execute())
            EndGame();
    }

    private void EndGame()
    {
        _gameUpdates.StopUpdate();
    }
}