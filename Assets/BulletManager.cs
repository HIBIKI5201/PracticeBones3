using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private void Start()
    {
        Invoke("Destroy", 10);
    }

    private void Destroy()
    {
        Debug.Log("BulletTimeLimitDestroy");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);
        }
    }
}
