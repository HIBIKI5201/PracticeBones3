using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMoveManager : MonoBehaviour
{
    [Header("プレイヤー")]
    [SerializeField] GameObject Player;

    [Header("コンポーネント")]
    [SerializeField] Transform GunPosition;
    [SerializeField] Transform ShoulderPosition;

    [Header("ポジション調整")]
    [SerializeField] float _AngleLimit;

    //[HideInInspector] 
    public float _mouseAngle;
    float _gunDistance;

    float _playerScale;
    Vector2 _gunScale;
    
    void Start()
    {
        _gunDistance = Vector2.Distance(GunPosition.position, ShoulderPosition.position);
        _playerScale = Player.transform.lossyScale.x;
        _gunScale = GunPosition.localScale;
    }

    float AngleMath(float mouseAngle)
    {
        if (Mathf.Abs(mouseAngle) > 180 - _AngleLimit)
        { 
            Debug.Log("反転");
             
            return mouseAngle;
        }
        else if (Mathf.Abs(mouseAngle) > _AngleLimit)
        {
            if (Mathf.Abs(mouseAngle) < 90)
            {
                return mouseAngle > 0 ? _AngleLimit : -_AngleLimit;
            } else
            {
                return mouseAngle > 0 ? 180 - _AngleLimit : _AngleLimit - 180;
            }

        }
        else
        {
            return mouseAngle;
        }
    }

    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mouseAngle = Mathf.Atan2(mousePosition.y - ShoulderPosition.position.y, mousePosition.x - ShoulderPosition.position.x) * Mathf.Rad2Deg;
        _mouseAngle = AngleMath(_mouseAngle);
        float mouseAngleRadians = _mouseAngle * Mathf.Deg2Rad;

        GunPosition.position = ShoulderPosition.position + new Vector3(Mathf.Cos(mouseAngleRadians) * _gunDistance, Mathf.Sin(mouseAngleRadians) * _gunDistance, 0f);
        GunPosition.eulerAngles = new Vector3(0f, 0f, _mouseAngle);

        if (mousePosition.x - ShoulderPosition.position.x < 0)
        {
            Player.transform.localScale = new Vector3(-_playerScale, Player.transform.localScale.y);
            GunPosition.localScale = new Vector2(-_gunScale.x, -_gunScale.y);
        } else
        {
            Player.transform.localScale = new Vector3(_playerScale, Player.transform.localScale.y);
            GunPosition.localScale = new Vector2(_gunScale.x, _gunScale.y);
        }
    }
}
