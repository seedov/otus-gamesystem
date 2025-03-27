using System;
using UnityEngine;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public sealed class KeyboardInput : ITickable
    {
        public Action<Vector2> OnMove;
        private IKeyboardInputConfig config;

        public KeyboardInput(IKeyboardInputConfig config)
        {
            this.config = config;
        }

        public void Tick()
        {
            this.HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(config.Up))
            {
                this.Move(Vector2.up);
            }
            else if (Input.GetKey(config.Down))
            {
                this.Move(Vector2.down);
            }
            else if (Input.GetKey(config.Left))
            {
                this.Move(Vector2.left);
            }
            else if (Input.GetKey(config.Right))
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