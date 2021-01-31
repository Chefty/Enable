using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return GameManager.Instance.DoesPlayerPosessAbility(typeof(Swim));
    }

    public override void DebugDisplay()
    {

    }
}
