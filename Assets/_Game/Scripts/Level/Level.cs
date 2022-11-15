using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform groudTF;
    [SerializeField] Transform obstacleTF;
    [SerializeField] Character BotPrefab;
    [SerializeField] Player player;
    public List<Character> listCharacters;
    public bool isWin;
    Vector3 sizeGround;
    float sizeObstacle;
    float currentAmount=> listCharacters.Count;
    float targetAmount=5;
    float totalAmount;
    public float scaleRadius=10f;

    void Awake()
    {
        sizeGround = groudTF.localScale;
        sizeObstacle = obstacleTF.localScale.x > obstacleTF.localScale.z? obstacleTF.localScale.x : obstacleTF.localScale.z; 
        listCharacters = new List<Character>();
        player= FindObjectOfType<Player>();
        player.level= this;
        listCharacters.Add(player);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        SpawnAmountBot();
        
        // if(Input.GetKeyDown(KeyCode.D))
        // {
        //     int random = Random.Range(0, listCharacters.Count);
        //     DespawnChar(listCharacters[random]);
            
        // }
    }

    public void OnInit()
    {

    }

    public void OnStart()
    {

    }
    public void SpawnABot()
    {
        float x = groudTF.position.x-sizeGround.x/2+ Random.Range(0, sizeGround.x);
        float z = groudTF.position.z-sizeGround.z/2+ Random.Range(0, sizeGround.z);
        float y = groudTF.position.y + sizeGround.y/2 + BotPrefab.transform.localScale.y/2+0.5f;
        Vector3 position = new Vector3(x, y, z);
        // Instantiate(BotPrefab, position, Quaternion.identity);
        if(!isObjectHere(position, sizeObstacle))
        {
            Character bot = Instantiate(BotPrefab, position, Quaternion.identity);
            bot.level = this;
            listCharacters.Add(bot);
        }  
    }

    public Vector3 GenPointTarget()
    {
        float x = groudTF.position.x-sizeGround.x/2+ Random.Range(0, sizeGround.x);
        float z = groudTF.position.z-sizeGround.z/2+ Random.Range(0, sizeGround.z);
        float y = groudTF.position.y + sizeGround.y/2 + BotPrefab.transform.localScale.y/2+0.5f;
        Vector3 position = new Vector3(x, y, z);
        return position;
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
}
