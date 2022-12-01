using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSkin : Singleton<PresentSkin>
{
    
    public ESkinType currentType;
    public int currentIndex;
    public GenSkin currentSkin;
    private void Start() {
        currentType = ESkinType.Hat;
    }
    public void SpawnItem()
    {
        currentSkin.SpawnSkin(currentType, currentIndex);
    }
}
