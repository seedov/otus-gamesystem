using System.Collections.Generic;
using Lessons.Architecture.GameSystem;
using UnityEngine;
using Zenject;

public class Turel : MonoBehaviour, ITickable
{
    [Inject]
    Player player;



    public void Tick()
    {
        transform.LookAt(player.GetPosition());
    }
}
