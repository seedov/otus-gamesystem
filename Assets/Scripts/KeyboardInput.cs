using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.GameSystem
{
    public sealed class KeyboardInput : ITickable
    {
        public Action<Vector2> OnMove;

        private IKeyboardInputConfig keyboardInputConfig;

        public KeyboardInput(IKeyboardInputConfig keyboardInputConfig)
        {
            this.keyboardInputConfig = keyboardInputConfig;
        }

        public void Tick()
        {
            this.HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(keyboardInputConfig.Up))
            {
                this.Move(Vector2.up);
            }
            else if (Input.GetKey(keyboardInputConfig.Down))
            {
                this.Move(Vector2.down);
            }
            else if (Input.GetKey(keyboardInputConfig.Left))
            {
                this.Move(Vector2.left);
            }
            else if (Input.GetKey(keyboardInputConfig.Right))
            {
                this.Move(Vector2.right);
            }
        }

        private void Move(Vector2 direction)
        {
            this.OnMove?.Invoke(direction);
        }
    }
}