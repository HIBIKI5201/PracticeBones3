using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static int Score;
    [SerializeField] GameObject DestroyParticle;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Score++;
            Debug.Log($"åªç›ÇÃÉXÉRÉAÇÕ{Score}");

            Instantiate(DestroyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
