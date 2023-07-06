using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Level_Wall : Spawning_Level
{
    public override GameObject RandomPickEntity()
    {
        GameObject currWall = prefabs_[1]; // dynamcie wall
        if (GENERIC.CoinToss(60, 40))
            currWall = prefabs_[0]; // normal wall has 60%
        return currWall;
    }



}
