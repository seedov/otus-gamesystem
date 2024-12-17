using UnityEngine;

public class UpdatesController : MonoBehaviour
{
    private IUpdatable[] updatables;
    private void Awake()
    {
        updatables = transform.parent.GetComponentsInChildren<IUpdatable>();
    }
    void Update()
    {
        foreach(var updatable in updatables)
        {
            updatable.CustomUpdate();
        }
    }
}
