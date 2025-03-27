
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Lessons.Architecture.VContainer
{
    public class Turel : MonoBehaviour, IPauseTickable
    {
        [Inject]
        Player player;


        public void Tick()
        {
            transform.LookAt(player.GetPosition());
        }
    }
}