using Inputs;
using UnityEngine;

namespace Birds
{
    public class Movement
    {
        private readonly Rigidbody _rigidbody;
        private readonly IInput _input;
        private readonly float _jumpForce;
        private readonly float _speed;
        
        public Movement(float speed, float jumpForce, Rigidbody rigidbody, IInput input)
        {
            _speed = speed;
            _jumpForce = jumpForce;
            _rigidbody = rigidbody;
            _input = input;
        }

        public void Jump()
        {
            if (_input.HasInput() == false)
                return;
                    
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }

        public void Move()
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }
    }
}
