using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class JoystickInput : Singleton<JoystickInput>
{
     private Rigidbody _rigidbody;
    
    // [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public DynamicJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] Transform tfCenterJoystick;
    [SerializeField] Transform playerTF;

    
    public bool isControl => Vector3.Distance(tfCenterJoystick.localPosition, Vector3.zero)>0.1;

   
    private void Awake() {
        _rigidbody = FindObjectOfType<Player>().GetComponent<Rigidbody>();
        playerTF =  _rigidbody.transform;
        
        

        

    }
    public void Move()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal *_moveSpeed, _rigidbody.velocity.y, _joystick.Vertical*_moveSpeed);
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
           playerTF.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        _rigidbody.AddForce(Vector3.down*10f);
    }
}

