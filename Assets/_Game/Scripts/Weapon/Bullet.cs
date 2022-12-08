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
    public float speedBullet=10 ;
    public bool IsDead;
    public Character character; //Nhan vat ban dan
   
    // Start is called before the first frame update
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

    // public virtual void OnDespawn()
    // {
    //     character.weapon.gameObject.SetActive(true);
    //     IsDead=true;
    //     Destroy(this.gameObject);
    // }

    public override void OnInit()
    {
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
