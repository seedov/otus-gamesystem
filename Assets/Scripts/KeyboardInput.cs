using System;
using UnityEngine;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public sealed class KeyboardInput : MonoBehaviour, IPausableUpdatable
    {
        public Action<Vector2> OnMove;


        void IPausableUpdatable.PausableUpdate()
        {

            this.HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector2.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
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