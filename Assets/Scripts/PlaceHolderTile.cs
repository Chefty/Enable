using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderTile : MonoBehaviour
{
    public Tile TilePrefab;
    public Ability TileAbility;

    public  void DebugDisplay()
    {
        var rend = GetComponent<MeshRenderer>();

        if (TileAbility != null)
        {
            Material mat = new Material(rend.sharedMaterial);

            mat.SetColor("_Color", Color.magenta);
            rend.sharedMaterial = mat;
        }
        else
        {
            rend.sharedMaterial.SetColor("_Color", Color.white);
        }
    }

    public void GenerateRealTile()
    {
        if (TilePrefab == null)
        {
            return;
        }

        var tile = Instantiate(TilePrefab, transform.parent);

        tile.TileOwnAbility = TileAbility;
        tile.transform.position = transform.position;

        DestroyImmediate(gameObject);
    }
}
