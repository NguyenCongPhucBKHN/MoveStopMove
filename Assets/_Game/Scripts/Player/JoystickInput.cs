using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class JoystickInput : Singleton<JoystickInput>
{
     private Rigidbody _rigidbody;
     private float playerSpeed = 8;
     
    [SerializeField] public DynamicJoystick _joystick;
    private float _moveSpeed =8;
    [SerializeField] Transform tfCenterJoystick;
    [SerializeField] Transform playerTF;
    public bool isMouse;

    
    public bool isControl => Vector3.Distance(tfCenterJoystick.localPosition, Vector3.zero)>0.0000001;

    private void Start() {
        _rigidbody = FindObjectOfType<Player>().GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<DynamicJoystick>();
        playerTF =  _rigidbody.transform;
    }
    
    private void FixedUpdate()
    {
        isMouse = Input.GetMouseButtonDown(0);
        isMouse = !Input.GetMouseButtonUp(0);
        if(GameManagerr.Instance.IsState(EGameState.Pause) || GameManagerr.Instance.IsState(EGameState.Finish))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Move()
    {
        _moveSpeed = playerSpeed ;
        _rigidbody.velocity = isControl ? new Vector3(_joystick.Horizontal *_moveSpeed, _rigidbody.velocity.y, _joystick.Vertical*_moveSpeed): Vector3.zero;
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
           playerTF.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        _rigidbody.AddForce(Vector3.down*10f);
    }
}