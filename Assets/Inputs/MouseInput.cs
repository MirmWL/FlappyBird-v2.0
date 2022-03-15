using UnityEngine;

namespace Inputs
{
    public class MouseInput : IInput
    {
        private readonly int _mouseButton;
        
        public MouseInput(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool HasInput()
        {
            return Input.GetMouseButtonDown(_mouseButton);
        }
    }
}