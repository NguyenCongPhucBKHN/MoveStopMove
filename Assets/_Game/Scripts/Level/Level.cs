using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform groudTF;
    [SerializeField] Transform obstacleTF;
    [SerializeField] Character BotPrefab;
    [SerializeField] Player player;
    
    public List<Character> listCharacters;
    public List<EBodyMaterialType> listBodyMaterialType = new List<EBodyMaterialType>();
    public bool isWin;
    public Vector3 sizeGround;
    float sizeObstacle;
    float currentAmount=> listCharacters.Count;
    float targetAmount=5;
    float totalAmount;
   

    void Awake()
    {
        if(sizeGround!=null)
        {
            
            sizeGround = groudTF.localScale;
            sizeObstacle = obstacleTF.localScale.x > obstacleTF.localScale.z? obstacleTF.localScale.x : obstacleTF.localScale.z; 
            listCharacters = new List<Character>();
        }  

    }

   

    public void OnStart()
    {
        OnInit();
    }

    public void OnInit()
    {   
       
        InitDataSO();
        SpawnPlayer();
        SpawnAmountBot();

    }
    public void SpawnPlayer()
    {
        player= FindObjectOfType<Player>();
        if(player==null)   
        {
            player = LevelManager.Instance.player;
            player.gameObject.SetActive(true);
    
        }
        
        player.level= this;
        player.OnInit();
        listCharacters.Add(player);
    }

     public void SpawnAmountBot()
    {
        for(int i =0; i< targetAmount+1; i++)
        {
             SpawnABot();
        }
    }
    
    public void SpawnABot()
    {
        if(groudTF!=null)
        {
            float x = groudTF.position.x-sizeGround.x/2+ Random.Range(0, sizeGround.x);
            float z = groudTF.position.z-sizeGround.z/2+ Random.Range(0, sizeGround.z);
            float y = groudTF.position.y + sizeGround.y/2 + BotPrefab.transform.localScale.y/2+0.5f;
            Vector3 position = new Vector3(x, y, z);
            if(!isObjectHere(position, sizeObstacle) && listCharacters.Count<targetAmount)
            {
                Character bot = SimplePool.Spawn<Character>(BotPrefab, position, Quaternion.identity);
                bot.level = this;
                bot.OnInit();
                listCharacters.Add(bot);
            }
        }
          
    }

    public void DespawnChar(Character character)
    {
        RemoveCharInAreaAttack(character);
        listCharacters.Remove(character);
        // character.indicator.OnDespawn();
        character.OnDeath();
        SpawnABot();
        
        
    }

    public void RemoveCharInAreaAttack(Character character)
    {
        for(int i =0; i<listCharacters.Count; i++)
        {
            if(listCharacters[i].listCharInAttact.Contains(character))
            {
                listCharacters[i].listCharInAttact.Remove(character);
            }
        }
    }

    public void Despawn()
    {
        listCharacters.Clear();
        SimplePool.CollectAll();
        
    }

    public Vector3 GenPointTarget()
    {
        if(groudTF!=null)
        {
            Vector3 position = RandomPos();
            if(!isObjectHere(position, sizeObstacle))
            {
                return position;
            }
            }
            return Vector3.zero;
    }

    public bool IsExistChar(Character charr)
    {
        return this.listCharacters.Contains(charr);
    }

    bool isObjectHere(Vector3 position, float distance)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, distance);
        if (intersecting.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void InitDataSO()
    {
        listBodyMaterialType.Clear();
        for(int i =0; i<Constant.NUMBER_BODY_MATERIAL; i++)
        {
            listBodyMaterialType.Add((EBodyMaterialType) i);
        }
    }

    public Vector3 RandomPos()
    {
        float x = groudTF.position.x-sizeGround.x/2+ Random.Range(0, sizeGround.x);
        float z = groudTF.position.z-sizeGround.z/2+ Random.Range(0, sizeGround.z);
        float y = groudTF.position.y + sizeGround.y/2 + BotPrefab.transform.localScale.y/2+0.5f;
        Vector3 position = new Vector3(x, y, z);
        return position;
    }
}
