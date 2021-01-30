using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapDebugDisplay : MonoBehaviour
{
    [ContextMenu("UpdateMapRenderers")]
    public void UpdateMapRenderers()
    {
        var Tiles = GameObject.FindObjectsOfType<Tile>();

        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].DebugDisplay();
        }
    }
}
