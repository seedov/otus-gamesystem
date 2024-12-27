using System;
using System.Collections;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class BulletsSpawner : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;

    [Inject]
    private BulletConfig bulletConfig;

    private bool isDisabled;

    private float bulletLifetime = .5f;
    private float shotDelay = 1;

    void OnEnable()
    {
        isDisabled = false;
        StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        isDisabled = true;
    }

    IEnumerator StartShooting()
    {
        while (!isDisabled)
        {
            StartCoroutine(BulletLifecycleCoroutine());
            yield return new WaitForSeconds(shotDelay);
        }
    }

    private IEnumerator BulletLifecycleCoroutine()
    {
        var b = Instantiate(bulletPrefab);
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(b.gameObject);
    }


}
