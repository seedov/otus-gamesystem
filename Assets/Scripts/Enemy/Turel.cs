
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Lessons.Architecture.VContainer
{
    public class Turel : MonoBehaviour
    {
        [SerializeField]
        Player player;


        private void Update()
        {
            transform.LookAt(player.GetPosition());
        }
    }
}