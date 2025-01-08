using UnityEngine;

namespace Lessons.Architecture.VContainer
{
    public sealed class Player : MonoBehaviour, IStartGameListener
    {
        [SerializeField]
        private float speed = 2.5f;

        public void Move(Vector3 offset)
        {
            this.transform.position += offset * this.speed;
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }

        void IStartGameListener.StartGame()
        {
            transform.position = Vector3.zero;
        }
    }
}