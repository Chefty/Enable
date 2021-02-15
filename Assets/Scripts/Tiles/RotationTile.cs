using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : Tile
{
    public float RotationDirection;
    public Material grass;
    public Transform Icon;

    MeshRenderer rend;
    RandomFauna fauna;
    bool hasBeenUsed;

    private void Awake()
    {
        Icon = transform.GetChild(0);
        rend = GetComponent<MeshRenderer>();
        fauna = GetComponent<RandomFauna>();
    }

    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void TileBehaviour()
    {
        if (hasBeenUsed)
        {
            return;
        }

        GameManager.Instance.RotateLevel(RotationDirection);

        rend.sharedMaterial = grass;
        fauna.enabled = true;

        Destroy(Icon.gameObject);
        hasBeenUsed = true;
    }
}
