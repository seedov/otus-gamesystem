using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        [SerializeField]
        private KeyboardInput input;

        private void Start()
        {
            input.OnMove += OnMove;
        }

        private void OnDestroy()
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