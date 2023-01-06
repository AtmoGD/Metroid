using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousShooter : MonoBehaviour
{
    [SerializeField] private ShootController shootController;
    [SerializeField] private float shootInterval = 0.5f;

    private float shootTimer = 0f;

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        shootController.Shoot();
    }
}
