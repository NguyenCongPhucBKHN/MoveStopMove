using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : UICanvas
{
    [SerializeField] Text coin;
    
    private void Start() {
        DataPlayerController.updateCoinEvent.AddListener(UpdateCoin);
        DataPlayerController.updateCoinEvent.Invoke();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            DataPlayerController.AddCoin(10);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            DataPlayerController.SubCoin(9);
        }
    }
    public void UpdateCoin()
    {
        coin.text = DataPlayerController.GetCoin().ToString();
    }
    
}
