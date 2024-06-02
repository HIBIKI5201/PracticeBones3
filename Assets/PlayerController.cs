using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�v���C���[")]
    [SerializeField] GameObject Player;

    [Header("�R���|�[�l���g")]
    [SerializeField] GunShotManager GSManager;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator playerAnimator;

    [Header("�X�e�[�^�X")]
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

            if (horizontal > 0)
            {
                playerAnimator.SetBool("Move", true);
                playerAnimator.SetBool("BackMove", false);
            }
            if (horizontal < 0)
            {
                playerAnimator.SetBool("BackMove", true);
                playerAnimator.SetBool("Move", false);
            }           
        }
        else
        {
            playerAnimator.SetBool("Move", false);
            playerAnimator.SetBool("BackMove", false);
        }
    }
}
