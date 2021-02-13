using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : Tile
{
    public float RotationDirection;
    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void TileBehaviour()
    {
        print("RotationTile.TileBehaviour");
        GameManager.Instance.RotateLevel(RotationDirection);
    }
}
