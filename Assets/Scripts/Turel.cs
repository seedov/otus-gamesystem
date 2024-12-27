
using UnityEngine;
using VContainer;


namespace Lessons.Architecture.VContainer
{
    public class Turel : MonoBehaviour
    {
        [Inject]
        Player player;



        public void Update()
        {
            transform.LookAt(player.GetPosition());
        }
    }
}