using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public sealed class MoveController : IInitializable, IDisposable
    {
        private Player player;
        private KeyboardInput input;

        public MoveController(Player player, KeyboardInput input)
        {
            this.player = player;
            this.input = input;
        }

        void IInitializable.Initialize()
        {
            input.OnMove += OnMove;
        }

        void IDisposable.Dispose()
        {
            input.OnMove -= OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            this.player.Move(offset);
        }
    }
}