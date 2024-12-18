using System.Collections.Generic;
using UnityEngine;

public class UpdatesController : MonoBehaviour
{
    [Inject]
    private IEnumerable<IUpdatable> updatables;

    void Update()
    {
        foreach(var updatable in updatables)
        {
            updatable.CustomUpdate();
        }
    }
}
