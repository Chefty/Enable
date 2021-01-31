using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubeGrid : MonoBehaviour
{
    public PlaceHolderTile PlaceHolderPrefab;
    public Vector2 Size;

    private void Start()
    {
        var Tiles = GameObject.FindObjectsOfType<PlaceHolderTile>();

        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].GenerateForPlayMode();
        }

        Destroy(gameObject);
    }

    [ContextMenu("CreateGrid")]
    public void CreateGrid()
    {
        Transform origin = new GameObject().transform;
        origin.name = "root";

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
#if UNITY_EDITOR
                Transform cube = (UnityEditor.PrefabUtility.InstantiatePrefab(PlaceHolderPrefab, origin) as PlaceHolderTile).gameObject.transform;
#endif
                cube.position = new Vector3(x, 0f, y);
                cube.name = x.ToString() + "_" + y.ToString();
                cube.SetParent(origin);
            }
        }
    }

    [ContextMenu("ReplacePlaceHolders")]
    public void ReplacePlaceHolders()
    {
        var Tiles = GameObject.FindObjectsOfType<PlaceHolderTile>();

        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].GenerateRealTile();
        }
    }

    [ContextMenu("RevealAbilities")]
    public void RevealAbilities()
    {
        var Tiles = GameObject.FindObjectsOfType<PlaceHolderTile>();

        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].DebugDisplay();
        }
    }
}
