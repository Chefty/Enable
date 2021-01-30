using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Ability TileOwnAbility;

    private void Start()
    {
        if (TileOwnAbility != null)
        {
            TileOwnAbility.SpawnProps(transform, transform.position + (Vector3.up));
        }
    }
}
