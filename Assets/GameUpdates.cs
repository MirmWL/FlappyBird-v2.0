using System.Collections.Generic;

public class GameUpdates 
    {
        private readonly List<IGameUpdate> _updates;
        private bool _isStopped;
        
        public GameUpdates()
        {
            _updates = new List<IGameUpdate>();
        }

        public void AddToUpdateList(IGameUpdate gameUpdate)
        {
            _updates.Add(gameUpdate);
        }

        public void Update()
        {
            if (_isStopped) 
                return;
            
            for (var i = 0; i < _updates.Count; i++)
                _updates[i].GameUpdate();
        }

        private void RemoveFromUpdateList(IGameUpdate gameUpdate)
        {
            var index = _updates.FindIndex(s => s == gameUpdate);
            var lastIndex = _updates.Count - 1;
            _updates[index] = _updates[lastIndex];
            _updates.RemoveAt(lastIndex);
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

