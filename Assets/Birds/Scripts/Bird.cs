using Inputs;

using UnityEngine;

namespace Birds
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bird : MonoBehaviour, IGameUpdate
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _speed;
        
        private Rigidbody _rigidbody;
        private Movement _movement;

        private bool _isDead;
        
        public void Init()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            _movement = new Movement(_speed, _jumpForce, _rigidbody, new MouseInput(0));
        }
        
        public void GameUpdate()
        {
            _movement.Jump();
            _movement.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Pipe>(out _))
                _isDead = true;
        }
        
        public bool IsDead()
        {
            return _isDead;
        }
    }
}