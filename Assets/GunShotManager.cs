using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GunShotManager : MonoBehaviour
{
    [SerializeField] GunMoveManager GMManager;
    [SerializeField] Transform MuzzlePosition;
    [SerializeField] GameObject BulletPrefab;

    [SerializeField] float _bulletSpeed = 3;

    void Start()
    {
        
    }

    public void ShotBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, MuzzlePosition.position, Quaternion.identity);
        bullet.transform.rotation = Quaternion.Euler(0, 0, GMManager._mouseAngle);
        Vector2 localDirection = bullet.transform.right;
        Vector2 force = localDirection * _bulletSpeed;

        bullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
