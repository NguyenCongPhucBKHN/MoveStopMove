using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] public Transform TF;
    [SerializeField]public  Rigidbody rb;
    [SerializeField]public float speedBullet;
    public bool IsDead;
    public Character character; //Nhan vat ban dan
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    
    void Update()
    {
        if(!character.IsDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnInit()
    {
        TF= transform;
        rb = GetComponent<Rigidbody>();
        rb.useGravity= false;
        IsDead = false;
    }
    public virtual void Move(Vector3 dirAttact)
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
      
        if(hit != null && character!=null)
        {
            hit.OnHit(this, character);
        }
    }

    public virtual void OnDespawn()
    {
        Debug.Log("destroy");
        IsDead=true;
        Destroy(this.gameObject);
    }
}
