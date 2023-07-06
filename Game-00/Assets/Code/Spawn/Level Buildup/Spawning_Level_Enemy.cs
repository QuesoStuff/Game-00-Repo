using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawning_Level_Enemy : Spawning_Level
{
    public override GameObject RandomPickEntity()
    {
        GameObject currItem = null;
        int randomIndex = UnityEngine.Random.Range(0, prefabs_.Count);
        currItem = prefabs_[randomIndex];
        return currItem;
    }





}
