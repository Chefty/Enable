using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return GameManager.Instance.DoesPlayerPosessAbility(typeof(Shoes));
    }

    public override void DebugDisplay()
    {

    }
}
