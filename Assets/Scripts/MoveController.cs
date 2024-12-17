using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class MoveController : MonoBehaviour , IUserInputListener, IStartGameListener, IPauseGameListener, IResumeGameListener, IFinishGameListener
    {
        [SerializeField]
        private Player player;

        private bool canMove;

        private void OnMove(Vector2 direction)
        {
            if (!canMove)
                return;

            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            this.player.Move(offset);
        }

        public void UserInputReceived(Vector2 input)
        {
            OnMove(input);
        }

        public void StartGame()
        {
            canMove = true;
        }

        public void PauseGame()
        {
            canMove = false;
        }

        public void ResumeGame()
        {
            canMove = true;
        }

        public void FinishGame()
        {
            canMove = false;
        }
    }
}