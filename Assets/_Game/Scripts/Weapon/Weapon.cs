using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform TF;
    protected EWeaponType eWeaponType;
    [SerializeField]
    protected Bullet bulletPrefab;
    [SerializeField] public WeaponDatas weaponDatas;
    [SerializeField] public Vector3 offsetRotation;
    [SerializeField] private MeshRenderer meshRenderer;
    public WeaponDataa weaponDataa;
    public Character character;
    protected bool isActivate = true;
    public int indexMat ;
    public Bullet bullet;
   
    void Start()
    {
        indexMat = Random.Range(0,3);
    }
    
  
    
    public void InitData(int eType,int indexMaterial) 
    {
        this.indexMat = indexMaterial;
        if(character!=null && weaponDataa!=null)
        {
            eWeaponType =  character.currentWeaponType;
            weaponDataa.SetEWeaponType((int)eWeaponType);
            weaponDataa.SetMaterial( this.indexMat);
            meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
        }
        else
        {
            eWeaponType =(EWeaponType) eType;
            weaponDataa?.SetEWeaponType((int)eWeaponType);
            weaponDataa?.SetMaterial( this.indexMat);
            meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
        }
        
    }
    
    public virtual void Attack()

    {   
            bulletPrefab = weaponDatas.GetBulletPrefab(eWeaponType);
            character.dirAttact.y=0;
            bullet = Instantiate(bulletPrefab, TF.position,Quaternion.identity);
            bullet.meshRenderer.materials = weaponDataa.GetMaterial().ToArray();
            // bullet.TF.localScale = character.TF.localScale;
            bullet.TF.localScale= character.TF.localScale;
            bullet.character= character;
            bullet.Move(character.dirAttact);
    }

    public void OnDespawn()
    {
        
        // if(this.eWeaponType!= character.currentWeaponType)
        // {
            // gameObject.SetActive(false);
            Destroy(gameObject);
            
        // }
    }

    //  public void SpawnBullet (Vector2 point, Quaternion rot) {
    //      bullets[i]= SimplePool.Spawn<Bullet>(bulletPrefab, character.weaponGenTF.position + new Vector3((i-1)*0.5f, 0, 0),  Quaternion.identity /* bulletPrefab.transform.rotation*/ /*TF.rotation*Quaternion.Euler(0f, (i-1)*10f, 0f) */ /*Quaternion.identity*/);
//         bullets[i].tf.localScale= character.TF.localScale;
//         bullets[i].meshRenderer.materials = weaponDataa.GetMaterial().ToArray();
//         bullets[i].character= character;
//         bullets[i].Move(character.dirAttact + new Vector3(0, 0, (i-1)*0.2f));
    // }
    
}
