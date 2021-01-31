using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DirectionToArrow
{
    public Vector3 Direction;
    public GameObject Arrow;
}

public class AbiltiesRotatedAssets : MonoBehaviour
{
    public static AbiltiesRotatedAssets Instance;

    public List<DirectionToArrow> Arrows;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetWalkArrowFromRotation(Vector3 walkDirection)
    {
        return Arrows.Where(x => x.Direction == walkDirection).First().Arrow;
    }
}
