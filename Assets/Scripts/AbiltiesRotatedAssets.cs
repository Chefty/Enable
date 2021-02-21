using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DirectionToArrow
{
    public Vector3 Direction;
    public Sprite Arrow;
    public KeyCode keycode;
    public GameObject placeholder;
}

public class AbiltiesRotatedAssets : MonoBehaviour
{
    public static AbiltiesRotatedAssets Instance;

    public List<DirectionToArrow> Arrows;

    private void Awake()
    {
        Instance = this;
    }

    public Sprite GetWalkArrowFromRotation(Vector3 walkDirection)
    {
        return Arrows.Where(x => x.Direction == walkDirection).First().Arrow;
    }

    public KeyCode GetKeycodeForDirection(Vector3 walkDirection)
    {
        return Arrows.Where(x => x.Direction == walkDirection).First().keycode;
    }

    public GameObject GetPlaceholderForDirection(Vector3 walkDirection)
    {
        return Arrows.Where(x => x.Direction == walkDirection).First().placeholder;
    }
}
