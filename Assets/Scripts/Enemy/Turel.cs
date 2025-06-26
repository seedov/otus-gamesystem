
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Lessons.Architecture.VContainer
{
    public class Turel : MonoBehaviour,  IPausableUpdatable
    {
        [SerializeField]
        Player player;



        void IPausableUpdatable.PausableUpdate()
        {
                transform.LookAt(player.GetPosition());
        }
    }
}