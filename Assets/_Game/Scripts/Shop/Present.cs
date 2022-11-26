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
private List<ShopItemSelect> listSelectedItem = new List<ShopItemSelect>();
 private int playerIndex;

 public GameObject player;
 public RectTransform weapon;
 private Vector2 sizeCanvas;
private int count;
public int indexSelect=0; //index Material
 ShopItemSelect shopItemSelect;
public int currentWeaponType = 0;

 void Awake()
 {
    shopItemSelect = new ShopItemSelect();
    
   
 }  


 public void OnNext()
 {
  listSelectedItem[currentWeaponType].gameObject.SetActive(false);
   if(currentWeaponType<presentWeapons.GetCountWeapon()-1)
   {
      currentWeaponType++;
   }
   shopItemSelectPrefab = presentWeapons.GetPrefabItemSelect(currentWeaponType);
   
   listSelectedItem[currentWeaponType].gameObject.SetActive(true);
   InitData();
   //  Destroy(player);
   //  playerIndex =DataServices.GetNextItem();
    //TODO INIT PLAYER
 }
 public void OnPrev()
 {
   listSelectedItem[currentWeaponType].gameObject.SetActive(false);
   if(currentWeaponType > 0)
   {
      currentWeaponType--; 
   }
   
  InitData();

    //TODO INIT PLAYER
 }

void InitSelectedItem()
{
  for(int i =0; i < presentWeapons?.GetCountWeapon(); i++)
  {
    ShopItemSelect prefab = presentWeapons.GetPrefabItemSelect(i);
    ShopItemSelect item = Instantiate(prefab, PageTF);
    item.gameObject.SetActive(false);
    listSelectedItem.Add(item);
  }
}
 private void Start()
 {
   
   weaponDataa?.SetEWeaponType(currentWeaponType);
  //  shopItemSelectPrefab = presentWeapons.GetPrefabItemSelect(currentWeaponType);
  //  shopItemSelect = Instantiate(shopItemSelectPrefab,PageTF );
   InitSelectedItem();
   InitData();
    

 }

 

 private void InitData()
 {
    CreatListItem();
   indexSelect = 0;
   UpdateSelect();
    listSelectedItem[currentWeaponType].gameObject.SetActive(true);
 }

private void CreatListItem()
{
  shopWeaponElementPrefab = presentWeapons?.GetPrefabWeapon(currentWeaponType);
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
    ShopWeaponElement shopWeaponElement = Instantiate(prefab, TF);
    listWeapons.Add(shopWeaponElement);
    weaponDataa?.SetEWeaponType(currentWeaponType);
    weaponDataa?.SetMaterial(indexMaterial);
    shopWeaponElement.meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
    weapon = shopWeaponElement.GetComponent<RectTransform>();
    Vector3 pos = Vector3.zero;
    pos.x = 0.5f*((count+1)%2)+ 1*(indexMaterial-count/2) + indexMaterial*0.3f ;
    weapon.anchoredPosition3D= pos;
     return shopWeaponElement;
   }



 public void UpdateSelect()
 {
   shopItemSelect = listSelectedItem[currentWeaponType];
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
    
    return (int) weaponDataa?.listWeaponMaterials.GetWeaponMaterialDatas( sweaponType).numberMaterial;

   
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
   bool isOwned = DataService.IsOwnedWithId(currentWeaponType);
        if(isOwned) //Neu so huu thi khong cho mua
        {
            Debug.Log("Done1");
        }
        else
        {
            Debug.Log("Done2");
        }
  
  }
 

}
