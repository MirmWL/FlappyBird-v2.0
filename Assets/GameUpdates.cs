using System.Collections.Generic;

public class GameUpdates 
    {
        private readonly IGameUpdate[] _updates;
        private bool _isStopped;
        
        public GameUpdates(IGameUpdate[] updates)
        {
            _updates = updates;
        }

        public void Update()
        {
            if (_isStopped) 
                return;
            
            for (var i = 0; i < _updates.Length; i++)
                _updates[i].GameUpdate();
        }

        public void StopUpdate()
        {
            _isStopped = true;
        }
        
        public void ResumeUpdate()
        {
            _isStopped = false;
        }
    }

