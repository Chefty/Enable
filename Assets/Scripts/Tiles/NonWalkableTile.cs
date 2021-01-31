using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonWalkableTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return false;
    }

    public override void DebugDisplay()
    {
        var rend = GetComponent<MeshRenderer>();

        if (TileOwnAbility != null)
        {
            Material mat = new Material(rend.sharedMaterial);
            mat.SetColor("_Color", TileOwnAbility.PlaceHolderProps.GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color"));

            rend.sharedMaterial = mat;
        }
        else
        {
            rend.sharedMaterial.SetColor("_Color", Color.black);
        }
    }
}
