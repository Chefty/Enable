using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void DebugDisplay()
    {
    }

    public override void TileBehaviour()
    {
        if (GameManager.Instance.DoesPlayerPosessAbility(typeof(Shoes)))
        {
            return;
        }
        else
        {

            GameManager.Instance.Player.gameObject.SetActive(false);
        }
    }
}
