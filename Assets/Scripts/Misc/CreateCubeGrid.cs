using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubeGrid : MonoBehaviour
{
    public Vector2 Size;

    [ContextMenu("CreateGrid")]
    public void CreateGrid()
    {
        Transform origin = new GameObject().transform;
        origin.name = "root";

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Transform cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;

                cube.position = new Vector3(x, 0f, y);
                cube.name = x.ToString() + "_" + y.ToString();
                cube.SetParent(origin);
            }
        }
    }
}
