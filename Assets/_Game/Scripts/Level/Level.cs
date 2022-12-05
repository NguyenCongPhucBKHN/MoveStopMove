using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]public Transform groudTF;
    [SerializeField] Transform obstacleTF;
    [SerializeField] Character BotPrefab;
    [SerializeField] Player player;
     [SerializeField] Player playerPrefab;
    public List<Character> listCharacters;
    public List<EBodyMaterialType> listBodyMaterialType = new List<EBodyMaterialType>();
    public bool isWin;
    public Vector3 sizeGround;
    float sizeObstacle;
    float currentAmount=> listCharacters.Count;
    float targetAmount=5;
    float totalAmount;
    public float scaleRadius=10f;

    void Awake()
    {
        if(sizeGround!=null)
        {
            OnInit();
            sizeGround = groudTF.localScale;
            sizeObstacle = obstacleTF.localScale.x > obstacleTF.localScale.z? obstacleTF.localScale.x : obstacleTF.localScale.z; 
            listCharacters = new List<Character>();
            listCharacters.Add(player);

        }
       
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        SpawnAmountBot();
    }

    public void OnInit()
    {   
        InitDataSO();
        InitPlayer();
    }
    public void InitPlayer()
    {
        player= FindObjectOfType<Player>();
        if(player==null)   
        {
            player = LevelManager.Instance.player;
            player.gameObject.SetActive(true);
        }
        player.level= this;
        
    }

    public void OnStart()
    {

    }
    public void SpawnABot()
    {
        if(groudTF!=null)
        {
            float x = groudTF.position.x-sizeGround.x/2+ Random.Range(0, sizeGround.x);
            float z = groudTF.position.z-sizeGround.z/2+ Random.Range(0, sizeGround.z);
            float y = groudTF.position.y + sizeGround.y/2 + BotPrefab.transform.localScale.y/2+0.5f;
            Vector3 position = new Vector3(x, y, z);

            if(!isObjectHere(position, sizeObstacle))
            {
                Character bot = SimplePool.Spawn<Character>(BotPrefab, position, Quaternion.identity);
                bot.level = this;
                bot.OnInit();
                listCharacters.Add(bot);
            }
        }
          
    }

    public Vector3 GenPointTarget()
    {
        if(groudTF!=null)
        {
            float x = groudTF.position.x-sizeGround.x/2+ Random.Range(0, sizeGround.x);
            float z = groudTF.position.z-sizeGround.z/2+ Random.Range(0, sizeGround.z);
            float y = groudTF.position.y + sizeGround.y/2 + BotPrefab.transform.localScale.y/2+0.5f;
            Vector3 position = new Vector3(x, y, z);
            if(!isObjectHere(position, sizeObstacle))
            {
                return position;
            }
            }
            return Vector3.zero;
    }

    public void SpawnAmountBot()
    {
       if(currentAmount< targetAmount + 1)
       {
        SpawnABot();
       }
    }
    public void DespawnChar(Character character)
    {
        character.OnDeath();
        listCharacters.Remove(character);
    }
    public void Despawn()
    {
        // for(int i =0; i <listCharacters.Count; i++)
        // {
        //     // listCharacters[i].indicator.gameObject.SetActive(false);
        //     listCharacters[i].gameObject.SetActive(false);
            
        // }
        SimplePool.CollectAll();
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
}
