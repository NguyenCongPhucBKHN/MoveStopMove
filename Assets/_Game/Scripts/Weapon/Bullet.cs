using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : GameUnit
{
    // [SerializeField] public Transform TF;
    [SerializeField] public Transform Img;
    [SerializeField]public  Rigidbody rb;
    [SerializeField] public Vector3 offsetRotation;

    [SerializeField] public Vector3 offsetQuaternion;
    [SerializeField] public MeshRenderer meshRenderer;
    protected Quaternion bulletOffsetQuaternion;
    [SerializeField]
    public float speedBullet=5 ;
    public bool IsDead;
    public Character character; 
   

    void Start()
    {
        OnInit();
        tf= transform;
    }

    public virtual void Move(Vector3 dirAttact)
    {
        
        Quaternion rotation = Quaternion.LookRotation(dirAttact, Vector3.forward);
        tf.rotation= rotation;
        rb.velocity = dirAttact* speedBullet ;
    }

    public void OnHit(Bullet bullet, Character character)
    {

    }
    public void OnHitExit(Bullet bullet, Character character)
    {

    }

    void OnTriggerExit(Collider other)
    {
        //TODO: cache
        IHit hit = Cache.GetIHit(other);
        if(hit != null)
        {
            hit.OnHitExit(this, character);
        }
    }

    void OnTriggerEnter(Collider other)
    {   
        //TODO: cache
        IHit hit = Cache.GetIHit(other);
      
        if(hit != null && character!=null)
        {
            hit.OnHit(this, character);
        }
    }

    public override void OnInit()
    {
        //TODO: dua ve awake
        tf= transform;
        rb = GetComponent<Rigidbody>();
        rb.useGravity= false;
        IsDead = false;
    }

    public override void OnDespawn()
    {
        character.weapon.gameObject.SetActive(true);
        IsDead=true;
        SimplePool.Despawn(this);

        // throw new System.NotImplementedException();
    }

}
