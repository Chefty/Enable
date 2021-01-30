using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Ability TileOwnAbility;

    private BoxCollider TriggerCollider;

    private void Start()
    {
        if (TileOwnAbility != null)
        {
            TileOwnAbility.SpawnProps(transform, transform.position + Vector3.up);
        }

        TriggerCollider = gameObject.AddComponent<BoxCollider>();

        TriggerCollider.center = (Vector3.up * transform.localScale.y);
        TriggerCollider.isTrigger = true;
        TriggerCollider.size = transform.localScale;

        DebugDisplay();
    }

    public bool CheckTileAccessibility()
    {
        return true;
    }

    public void TileBehaviour()
    {
        // do something..
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TileOwnAbility != null)
        {
            GameManager.Instance.AddAbility(TileOwnAbility);
        }
    }

    public void DebugDisplay()
    {
        if (TileOwnAbility != null)
        {
            GetComponent<MeshRenderer>().sharedMaterial.color =
                TileOwnAbility.PlaceHolderProps.GetComponent<MeshRenderer>().sharedMaterial.color;
        }
    }
}
