using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
#if UNITY_EDITOR
    public bool showDebug = true;
#endif

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private int amountOfProjectiles = 1;
    [SerializeField] private float projectileSpread = 0f;

    public void Shoot()
    {
        for (int i = 0; i < amountOfProjectiles; i++)
        {
            Vector2 shootDirection = GetShootDirection(i);
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, rotation);
            projectile.transform.rotation = rotation;
        }
    }

    public Vector2 GetShootDirection(int _index)
    {
        if (amountOfProjectiles == 1)
            return shootPoint.right;

        float spread = projectileSpread / (amountOfProjectiles - 1);
        float spreadOffset = spread * _index;

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootPoint.up.y, shootPoint.up.x) * Mathf.Rad2Deg + spreadOffset);

        return rotation * Vector2.right;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            for (int i = 0; i < amountOfProjectiles; i++)
            {
                Vector2 shootDirection = GetShootDirection(i);
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

                Gizmos.color = Color.red;
                Gizmos.DrawRay(shootPoint.position, rotation * Vector2.right);
            }
        }
    }
#endif
}
