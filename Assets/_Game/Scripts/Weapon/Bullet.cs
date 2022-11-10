using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IHit
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speedBullet;
    public Character character; //Nhan vat ban dan
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(character!=null)
        {
            Move();
        }
        
    }

    void Move()
    {
        rb.velocity = character.dirAttact * speedBullet;
    }

    public void OnHit(Bullet bullet, Character character)
    {

    }
    public void OnHitExit(Bullet bullet, Character character)
    {

    }

    void OnTriggerExit(Collider other)
    {
        IHit hit = other.GetComponent<IHit>();
        if(hit != null)
        {
            hit.OnHitExit(this, character);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        IHit hit = other.GetComponent<IHit>();
        // Debug.Log("hit enter: "+ hit);
        if(hit != null)
        {
            hit.OnHit(this, character);
        }
    }
}
