using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Present : Singleton<Present>
{
[SerializeField] PresentWeapons presentWeapons;
public WeaponDataa weaponDataa;
private ShopWeaponElement ShopWeaponElementPrefab;
[SerializeField] private ShopItemSelect shopItemSelectPrefab;
[SerializeField] private Transform TF;
[SerializeField] private Transform PageTF;
private Dictionary<ShopWeaponElement, bool> listShopItems = new Dictionary<ShopWeaponElement, bool> ();
private List<ShopWeaponElement> listWeaponPrefabs = new List<ShopWeaponElement>();
 private int playerIndex;

//  public Button nextButton;
//  public Button prevButton;
 public GameObject player;
 public RectTransform weapon;
 private Vector2 sizeCanvas;
private int count;
public int indexSelect; //index Material
 ShopItemSelect shopItemSelect;
 private int currentWeaponType = 0;


 void Awake()
 {
    playerIndex= DataPlayer.GetCurrentItem();
   //  check
   //  count = weaponDataa.listWeaponMaterials.GetWeaponMaterialDatas((EWeaponType)(currentWeaponType)).numberMaterial;
   //  nextButton.onClick.AddListener(OnNext);
   //  prevButton.onClick.AddListener(OnPrev);
 }  

 public void OnNext()
 {
   if(currentWeaponType<presentWeapons.GetCountWeapon()-1)
   {
      currentWeaponType++;
   }
   Debug.Log("currentWeaponType: "+ currentWeaponType);
   // else
   // {
   //    currentWeaponType--;
   // }
   InitData();
   //  Destroy(player);
   //  playerIndex = DataPlayer.GetNextItem();
    //TODO INIT PLAYER
 }
 public void OnPrev()
 {
   if(currentWeaponType>1)
   {
      currentWeaponType--; 
   }
   Debug.Log("currentWeaponType: "+ currentWeaponType);
   // else
   // {
   //    currentWeaponType++;
   // }
   InitData();
   //  Destroy(player);
   //  playerIndex = DataPlayer.GetPrevItem();
    //TODO INIT PLAYER
 }

 private void Start()
 {
   
   weaponDataa?.SetEWeaponType((int)currentWeaponType);
   shopItemSelect = Instantiate(shopItemSelectPrefab,PageTF );
   InitData();
 }

 /// <summary>
 /// Update is called every frame, if the MonoBehaviour is enabled.
 /// </summary>
 private void Update()
 {
   if(Input.GetKeyDown(KeyCode.P))
   {
      ShopWeaponElement[] listChilds = GetComponentsInChildren<ShopWeaponElement>();
      Debug.Log("number check: "+ listChilds.Length);
   }
 }

 private void InitData()
 {
   count = weaponDataa.listWeaponMaterials.GetWeaponMaterialDatas((EWeaponType)(currentWeaponType)).numberMaterial;
   for(int i =0; i< count; i++)
   {
     ShopWeaponElement ShopWeaponElement= SetWeapon(i);
     ShopWeaponElement.present = this;
     ShopWeaponElement.index = i;
   }
   indexSelect = 0;

   UpdateSelect();
 }
 
 private ShopWeaponElement SetWeapon(int i) 
 {
   ShopWeaponElementPrefab = presentWeapons.GetPrefabWeapon(currentWeaponType);
   ShopWeaponElement ShopWeaponElement = Instantiate(ShopWeaponElementPrefab, TF);
   listShopItems.Add(ShopWeaponElement, true);
   
   weaponDataa?.SetEWeaponType(currentWeaponType);
   // weaponDataa?.SetIndexMaterial(i);
   weaponDataa?.SetMaterial(i);
   ShopWeaponElement.meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
   weapon = ShopWeaponElement.GetComponent<RectTransform>();
   Vector3 pos = Vector3.zero;
   pos.x = 0.5f*((count+1)%2)+ 1*(i-count/2) + i*0.3f ;
   weapon.anchoredPosition3D= pos;
   return ShopWeaponElement;
 }

 public void UpdateSelect()
 {

   shopItemSelect.weaponDataa?.SetEWeaponType(currentWeaponType);
   shopItemSelect.weaponDataa.SetMaterial(indexSelect);
   shopItemSelect.meshRenderer.materials= shopItemSelect.weaponDataa.GetMaterial().ToArray();
 }

 
   public List<Item> LoadPrefab()
   {
      List<Item> listItems = new List<Item>();
      for(int i =0; i<presentWeapons.GetCountWeapon(); i++)
      {
         listItems.Add(presentWeapons.listDataWeapons[i].weaponprefab);
      }
      return listItems;
      
   }


 

}
