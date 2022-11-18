using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Present : MonoBehaviour
{
 private int playerIndex;
 public Button nextButton;
 public Button prevButton;
 public GameObject player;

 void Awake()
 {
    playerIndex= DataPlayer.GetCurrentItem();
    nextButton.onClick.AddListener(OnNext);
    prevButton.onClick.AddListener(OnPrev);
 }  

 void OnNext()
 {
    Destroy(player);
    playerIndex = DataPlayer.GetNextItem();
    //TODO INIT PLAYER
 }
 void OnPrev()
 {
    Destroy(player);
    playerIndex = DataPlayer.GetPrevItem();
    //TODO INIT PLAYER
 }

}
