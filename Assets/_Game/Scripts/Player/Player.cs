using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Transform TF;
    void Awake()
    {
        TF= transform;
    }

    // Update is called once per frame
    void Update()
    {
     JoystickInput.Instance.Move();   
    }
}
