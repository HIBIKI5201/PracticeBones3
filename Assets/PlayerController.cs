using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("プレイヤー")]
    [SerializeField] GameObject Player;

    [Header("カメラ")]
    [SerializeField] GameObject Camera;
    [SerializeField] Vector3 _cameraPosition;

    [Header("コンポーネント")]
    [SerializeField] GunShotManager GSManager;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator playerAnimator;

    [Header("ステータス")]
    [SerializeField] float _moveSpeed;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GSManager.ShotBullet();
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            playerRB.velocity = new Vector2 (_moveSpeed * horizontal, playerRB.velocity.y);

            if (horizontal == Mathf.Sign(transform.localScale.x))
            {
                playerAnimator.SetBool("Move", true);
                playerAnimator.SetBool("MoveBack", false);
            } else
            {
                playerAnimator.SetBool("MoveBack", true);
                playerAnimator.SetBool("Move", false);
            }           
        }
        else
        {
            playerAnimator.SetBool("Move", false);
            playerAnimator.SetBool("MoveBack", false);
        }

        Camera.transform.position = Player.transform.position + _cameraPosition;
    }
}
