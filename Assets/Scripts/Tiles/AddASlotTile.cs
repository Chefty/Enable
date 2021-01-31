using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddASlotTile : Tile
{
    private bool _isAlreadyUsed = false;

    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void DebugDisplay()
    {

    }

    public override void TileBehaviour()
    {
        if (!_isAlreadyUsed)
        {
            GameManager.Instance.AddSlot();
        }

        _isAlreadyUsed = true;
    }
}
