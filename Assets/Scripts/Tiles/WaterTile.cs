using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return true;//GameManager.Instance.DoesPlayerPosessAbility(typeof(Swim));
    }

    public override string CheckTileType() {
        return "water";
    }

    public override void DebugDisplay()
    {

    }
}
