using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Present : Singleton<Present>
{
[SerializeField] PresentWeapons presentWeapons;
public WeaponDataa weaponDataa;
private ShopWeaponElement shopWeaponElementPrefab;
[SerializeField] private ShopItemSelect shopItemSelectPrefab;
[SerializeField] private Transform TF;
[SerializeField] private Transform PageTF;
private Dictionary<ShopWeaponElement, bool> listShopItems = new Dictionary<ShopWeaponElement, bool> ();
private List<ShopWeaponElement> listWeapons = new List<ShopWeaponElement>();
private List<ShopWeaponElement> listWeaponPrefab = new List<ShopWeaponElement>();
private Dictionary<ShopWeaponElement, ShopWeaponElement> dictItems = new Dictionary<ShopWeaponElement, ShopWeaponElement>();
 private int playerIndex;

//  public Button nextButton;
//  public Button prevButton;
 public GameObject player;
 public RectTransform weapon;
 private Vector2 sizeCanvas;
private int count;
public int indexSelect; //index Material
 ShopItemSelect shopItemSelect;
public int currentWeaponType = 0;

 void Awake()
 {
    playerIndex= DataPlayer.GetCurrentItem();
   
 }  

 public void OnNext()
 {
  Debug.Log("presentWeapons.GetCountWeapon() 1:"+ presentWeapons.GetCountWeapon());
   if(currentWeaponType<presentWeapons.GetCountWeapon()-1)
   {
      currentWeaponType++;
   }
   else
   {
    Debug.Log("Check1");
   }
   Debug.Log("currentWeaponType: "+ currentWeaponType);
   InitData();
   //  Destroy(player);
   //  playerIndex = DataPlayer.GetNextItem();
    //TODO INIT PLAYER
 }
 public void OnPrev()
 {
   Debug.Log("presentWeapons.GetCountWeapon() 2:"+ presentWeapons.GetCountWeapon());
   if(currentWeaponType > 0)
   {
      currentWeaponType--; 
   }
   else
   {
    Debug.Log("Check2");
   }
  Debug.Log("currentWeaponType: "+ currentWeaponType);
  InitData();

    //TODO INIT PLAYER
 }

 private void Start()
 {
   
   weaponDataa?.SetEWeaponType(currentWeaponType);
   shopItemSelect = Instantiate(shopItemSelectPrefab,PageTF );
   InitData();
 }

 /// <summary>
 /// Update is called every frame, if the MonoBehaviour is enabled.
 /// </summary>
 private void Update()
 {
  
 }

 private void InitData()
 {
    CreatListItem();
   indexSelect = 0;
   UpdateSelect();
 }

private void CreatListItem()
{
  shopWeaponElementPrefab = presentWeapons.GetPrefabWeapon(currentWeaponType);
  if(!listWeaponPrefab.Contains(shopWeaponElementPrefab))
  {
    SpawnListItem(currentWeaponType, shopWeaponElementPrefab);
  }
  else
  {
    DeActivateListExceptItem(shopWeaponElementPrefab);
    ActivateListItem(shopWeaponElementPrefab);
  }
}

void ActivateListItem(ShopWeaponElement shopWeaponElementPrefab)
{
  List<ShopWeaponElement> listWeapons = dictItems.Where(kvp => kvp.Value == shopWeaponElementPrefab).Select(kvp => kvp.Key).ToList();
    for(int i =0; i<listWeapons.Count; i++)
    {
      listWeapons[i].gameObject.SetActive(true);
    }
}

void DeActivateListExceptItem(ShopWeaponElement shopWeaponElementPrefab)
{
  List<ShopWeaponElement> listDeWeapons = dictItems.Where(kvp => kvp.Value != shopWeaponElementPrefab).Select(kvp => kvp.Key).ToList();
    for(int i =0; i<listDeWeapons.Count; i++)
    {
      listDeWeapons[i].gameObject.SetActive(false);
    }
}

void SpawnListItem(int currentWeaponType, ShopWeaponElement shopWeaponElementPrefab)
{
  count = GetNumMatsOfAWeapon((EWeaponType)(currentWeaponType));
    listWeaponPrefab.Add(shopWeaponElementPrefab);
    for(int i =0; i<count; i++)
    {
      ShopWeaponElement weapon = SetWeapon(i, shopWeaponElementPrefab);
      // weapon.present = this;
      weapon.SetIndexMaterial(i);
      weapon.SetWeaponType((EWeaponType)(currentWeaponType));
      dictItems.Add(weapon, shopWeaponElementPrefab);
    }
    DeActivateListExceptItem(shopWeaponElementPrefab);
}



 
 private ShopWeaponElement SetWeapon(int indexMaterial, ShopWeaponElement prefab) // Tao 1 cai
 {
  
    // listWeaponPrefab.Add(prefab);
    ShopWeaponElement shopWeaponElement = Instantiate(prefab, TF);
    listWeapons.Add(shopWeaponElement);
  //  ShopWeaponElement ShopWeaponElement = Spawn((EWeaponType)currentWeaponType);
    weaponDataa?.SetEWeaponType(currentWeaponType);
    weaponDataa?.SetMaterial(indexMaterial);
    shopWeaponElement.meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
    weapon = shopWeaponElement.GetComponent<RectTransform>();
    Vector3 pos = Vector3.zero;
    pos.x = 0.5f*((count+1)%2)+ 1*(indexMaterial-count/2) + indexMaterial*0.3f ;
    weapon.anchoredPosition3D= pos;
     return shopWeaponElement;
   }

  // //  listWeaponPrefab.Add(shopWeaponElementPrefab);
  // //   ShopWeaponElement shopWeaponElement = Instantiate(shopWeaponElementPrefab, TF);
  // //   listWeapons.Add(shopWeaponElement);
  //   ShopWeaponElement shopWeaponElement = Spawn((EWeaponType)currentWeaponType);
  //   weaponDataa?.SetEWeaponType(currentWeaponType);
  //   weaponDataa?.SetMaterial(indexMaterial);
  //   shopWeaponElement.meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
  //   weapon = shopWeaponElement.GetComponent<RectTransform>();
  //   Vector3 pos = Vector3.zero;
  //   pos.x = 0.5f*((count+1)%2)+ 1*(indexMaterial-count/2) + indexMaterial*0.3f ;
  //   weapon.anchoredPosition3D= pos;
  //    return shopWeaponElement;
    
//  }

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

  public int GetNumMatsOfAWeapon(EWeaponType sweaponType)
  {
    
    return  weaponDataa.listWeaponMaterials.GetWeaponMaterialDatas( sweaponType).numberMaterial;
  }
  
  // public List<ShopWeaponElement> SpawnListWeapon(EWeaponType eWeaponType)
  // {
  //   int numberMat = GetNumMatsOfAWeapon(eWeaponType);
  //   switch (eWeaponType) {
  //   case (EWeaponType) 0:
  //     return ItemManager.Instance.SpawnListItem<ShopBoomerangElement>(numberMat) ;
  //   case (EWeaponType) 1: 
  //     return ItemManager.Instance.SpawnListItem<ShopHammerElement>(numberMat);
  //   case (EWeaponType) 2:
  //     return ItemManager.Instance.SpawnListItem<ShopKnifeElement>(numberMat);
  //   default :
      
  //     return null;
  //  }
  // }
  
  public void SelectItem()
  {
   
  
  }
 

}
