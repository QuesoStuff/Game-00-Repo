using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Level_Item : Spawning_Level
{
    [SerializeField] protected List<GameObject> prefabs_Extra;
    [SerializeField] protected List<GameObject> prefabs_Random_SP;

    public override GameObject RandomPickEntity()
    {
        GameObject currItem = null;
        int randomIndex = 0;
        if (!GENERIC.CoinToss(80, 20))
        {
            randomIndex = UnityEngine.Random.Range(0, prefabs_.Count);
        }
        else
        {
            randomIndex = UnityEngine.Random.Range(0, prefabs_Extra.Count);
        }
        currItem = prefabs_[randomIndex];
        return currItem;
    }






}
