using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class JoystickInput : Singleton<JoystickInput>
{
     private Rigidbody _rigidbody;
     private float playerSpeed = 8;
    
    // [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public DynamicJoystick _joystick;
    [SerializeField] private float _moveSpeed =8;
    [SerializeField] Transform tfCenterJoystick;
    [SerializeField] Transform playerTF;
    public bool isMouse;

    
    public bool isControl => Vector3.Distance(tfCenterJoystick.localPosition, Vector3.zero)>0.1;

   
    // private void Awake() {
    //     _rigidbody = FindObjectOfType<Player>().GetComponent<Rigidbody>();
    //     playerTF =  _rigidbody.transform;
    // }
    private void Start() {
        _rigidbody = FindObjectOfType<Player>().GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<DynamicJoystick>();
        Debug.Log("rb: "+ _rigidbody);
        playerTF =  _rigidbody.transform;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        isMouse = Input.GetMouseButtonDown(0);
        isMouse = !Input.GetMouseButtonUp(0);
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