
using UnityEngine;
using VContainer;


namespace Lessons.Architecture.VContainer
{
    public class Turel : MonoBehaviour, IPauseTickable
    {
        [Inject]
        Player player;


        void IPauseTickable.Tick()
        {
            transform.LookAt(player.GetPosition());
        }
    }
}