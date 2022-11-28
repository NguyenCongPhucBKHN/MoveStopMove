using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DebugCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DebugCurrentWeapon();
        }
    }

    void DebugCurrentWeapon()
    {
        ItemModel item = DataPlayerController.GetCurrentWeapon();
        Debug.Log("test: " + item.indexType + item.indexItem);
    }
}
