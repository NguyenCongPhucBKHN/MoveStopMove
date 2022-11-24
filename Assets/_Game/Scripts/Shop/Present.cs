using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Present : MonoBehaviour
{
[SerializeField] PresentWeapons presentWeapons;
public WeaponDataa weaponDataa;
private ShopHammerElement shopHammerElementPrefab;
[SerializeField] private ShopItemSelect shopItemSelectPrefab;
[SerializeField] private Transform TF;
[SerializeField] private Transform PageTF;
private Dictionary<ShopHammerElement, bool> listShopItems = new Dictionary<ShopHammerElement, bool> ();
private List<ShopHammerElement> listWeaponPrefabs = new List<ShopHammerElement>();
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
   Debug.Log("currentWeaponType start: "+ currentWeaponType);
   weaponDataa?.SetEWeaponType((int)currentWeaponType);
   shopItemSelect = Instantiate(shopItemSelectPrefab,PageTF );
   InitData();
 }

 private void InitData()
 {
   count = weaponDataa.listWeaponMaterials.GetWeaponMaterialDatas((EWeaponType)(currentWeaponType)).numberMaterial;
   for(int i =0; i< count; i++)
   {
     ShopHammerElement shopHammerElement= SetWeapon(i);
     shopHammerElement.present = this;
     shopHammerElement.index = i;
   }
   indexSelect = 0;

   UpdateSelect();
 }
 
 private ShopHammerElement SetWeapon(int i) 
 {
   shopHammerElementPrefab = presentWeapons.GetPrefabWeapon(currentWeaponType);
   ShopHammerElement shopHammerElement = Instantiate(shopHammerElementPrefab, TF);
   listShopItems.Add(shopHammerElement, true);
   
   weaponDataa?.SetEWeaponType(currentWeaponType);
   // weaponDataa?.SetIndexMaterial(i);
   weaponDataa?.SetMaterial(i);
   shopHammerElement.meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
   weapon = shopHammerElement.GetComponent<RectTransform>();
   Vector3 pos = Vector3.zero;
   pos.x = 0.5f*((count+1)%2)+ 1*(i-count/2) + i*0.3f ;
   weapon.anchoredPosition3D= pos;
   return shopHammerElement;
 }

 public void UpdateSelect()
 {

   shopItemSelect.weaponDataa?.SetEWeaponType(currentWeaponType);
   shopItemSelect.weaponDataa.SetMaterial(indexSelect);
   shopItemSelect.meshRenderer.materials= shopItemSelect.weaponDataa.GetMaterial().ToArray();
 }

 public void OnDespawn()
 {

 }

 

}
