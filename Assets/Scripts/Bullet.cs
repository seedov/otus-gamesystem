
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Bullet : MonoBehaviour
{


    public void Update()
    {
        transform.position += transform.forward * 1;
    }   

}
