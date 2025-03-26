
using UnityEngine;
using VContainer;


namespace Lessons.Architecture.VContainer
{
    public class Turel : MonoBehaviour, IPauseTickable
    {
        [Inject]
        MoveComponent player;


        void IPauseTickable.Tick()
        {
            transform.LookAt(player.GetPosition());
        }
    }
}