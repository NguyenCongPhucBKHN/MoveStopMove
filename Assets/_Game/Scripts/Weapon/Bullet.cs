using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] public Transform TF;
    [SerializeField] public Transform Img;
    [SerializeField]public  Rigidbody rb;
    [SerializeField] public Vector3 offsetRotation;

    [SerializeField] public Vector3 offsetQuaternion;
    [SerializeField] public MeshRenderer meshRenderer;
    protected Quaternion bulletOffsetQuaternion;
    public float speedBullet ;
    public bool IsDead;
    public Character character; //Nhan vat ban dan
    
    void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
        TF= transform;
    }

    void Update()
    {
        if(character.IsDead)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void OnInit()
    {
        TF= transform;
        rb = GetComponent<Rigidbody>();
        rb.useGravity= false;
        IsDead = false;
    }
    public virtual void Move(Vector3 dirAttact)
    {
        
        Quaternion rotation = Quaternion.LookRotation(dirAttact, Vector3.forward);
        // rotation.x =90;
        TF.rotation= rotation;
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

    public virtual void OnDespawn()
    {
        character.weapon.gameObject.SetActive(true);
        IsDead=true;
        Destroy(this.gameObject);
    }
}
