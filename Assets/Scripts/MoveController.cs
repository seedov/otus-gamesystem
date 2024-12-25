using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.GameSystem
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

        public void Initialize()
        {
            input.OnMove += OnMove;
        }

        public void Dispose()
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