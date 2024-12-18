using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class KeyboardInput : MonoBehaviour, IUpdatable
    {
        [Inject]
        private IEnumerable<IUserInputListener> userInputListeners;

        public void CustomUpdate()
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
            foreach (var listener in userInputListeners) 
            {
                listener.UserInputReceived(direction);
            }
        }
    }
}