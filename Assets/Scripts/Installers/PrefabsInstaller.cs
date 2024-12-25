using UnityEngine;
using Zenject;

public class PrefabsInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject prefab;
    public override void InstallBindings()
    {
    }
}