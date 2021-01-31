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
}

public class AbiltiesRotatedAssets : MonoBehaviour
{
    public static AbiltiesRotatedAssets Instance;

    public List<DirectionToArrow> Arrows;

    private void Awake()
    {
        Instance = this;
    }

    // TODO just change the sprite
    public Sprite GetWalkArrowFromRotation(Vector3 walkDirection)
    {
        return Arrows.Where(x => x.Direction == walkDirection).First().Arrow;
    }
    
    // TODO just change the sprite
    public KeyCode GetKeycodeForDirection(Vector3 walkDirection)
    {
        return Arrows.Where(x => x.Direction == walkDirection).First().keycode;
    }
}
