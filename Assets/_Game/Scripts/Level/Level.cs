using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform groudTF;
    [SerializeField] Transform obstacleTF;
    [SerializeField] Bot BotPrefab;
    private List<Bot> bots;
    public bool isWin;
    Vector3 sizeGround;
    float sizeObstacle;
    float currentAmount=> bots.Count;
    float targetAmount=5;
    float totalAmount;

    void Awake()
    {
        // groudTF = FindObjectOfType<Level>().transform;
        sizeGround = groudTF.localScale;
        sizeObstacle = obstacleTF.localScale.x > obstacleTF.localScale.z? obstacleTF.localScale.x : obstacleTF.localScale.z; 
        bots = new List<Bot>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
            SpawnAmountBot();
        
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            DespawnBot();
        }
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
            Bot bot = Instantiate(BotPrefab, position, Quaternion.identity);
            bots.Add(bot);
        }
        
    }

    public void SpawnAmountBot()
    {
       if(currentAmount< targetAmount)
       {
        SpawnABot();
       }
    }
    public void DespawnBot()
    {
        Bot bot = bots[0];
        bots.Remove(bot);
        Destroy(bot.gameObject);
    
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
