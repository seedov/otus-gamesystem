using System;
using System.Runtime.CompilerServices;
using NUnit.Framework.Interfaces;
using UnityEngine;
using Zenject;

public interface IBulletHit
{
    void Hit();
}
public class Bullet : MonoBehaviour
{


    public void Update()
    {
        transform.position += transform.forward * 10 ;
    }

}
