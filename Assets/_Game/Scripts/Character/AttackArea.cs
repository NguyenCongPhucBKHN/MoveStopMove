using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour, IHit
{
    [SerializeField] Transform TF;
    public Character character;
    public float chaseRange => transform.lossyScale.x;
    void OnTriggerEnter(Collider other)
    {
        Character charInArea = other.GetComponent<Character>();
        if(charInArea != null /* && character!=null && charInArea.gameObject != character.gameObject*/ )
        {
            Debug.Log("Character: "+ charInArea.gameObject.name);
            character.listCharInAttact.Add(charInArea);
            // character.IsInRangeAttack= true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        Character charInArea = other.GetComponent<Character>();
        if(charInArea != null && character!=null &&  charInArea.gameObject != character.gameObject )
        {
            character.listCharInAttact.Remove(charInArea);
            // character.IsInRangeAttack= false;
        }
    }
   void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(TF.position, chaseRange/2);
    }

    public void OnHit(Bullet bullet, Character character)
    {
        
    }
    public void OnHitExit(Bullet bullet, Character character)
    {
        if(bullet.character == this.character)
        {
            Destroy(bullet.gameObject);
        }
    }
}
