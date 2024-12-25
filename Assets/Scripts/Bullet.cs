
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public void Update()
    {
        transform.position += transform.forward * 10 ;
    }

}
