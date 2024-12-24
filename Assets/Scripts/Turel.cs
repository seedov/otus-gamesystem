using System.Collections.Generic;
using Lessons.Architecture.GameSystem;
using UnityEngine;
using Zenject;

public class Turel : MonoBehaviour
{
    [SerializeField]
    Player player;



    public void Update()
    {
        transform.LookAt(player.GetPosition());
    }

    public void Initialize()
    {
      
    }
}
