using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Ability TileOwnAbility;

    private BoxCollider TriggerCollider;

    private Color _startColor;

    private void Start()
    {
        _startColor = GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color");
        DisplayAbility();

        TriggerCollider = gameObject.AddComponent<BoxCollider>();

        TriggerCollider.center = (Vector3.up * transform.localScale.y);
        TriggerCollider.isTrigger = true;
        TriggerCollider.size = transform.localScale;
    }

    public void DisplayAbility()
    {
        if (TileOwnAbility != null)
        {
             TileOwnAbility.SpawnProps(transform, transform.position + Vector3.up);
            DebugDisplay();
        }
    }

    public virtual bool CheckTileAccessibility()
    {
        print("Walking next on tile " + name);
        return true;
    }

    public virtual void TileBehaviour()
    {
        // do something..
        print("base.TileBehaviour");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.SetCurrentTile(this);

        print("OnTriggerEnter");
        TileBehaviour();
        //Not taking ability automatically for now
        /*if (TileOwnAbility != null)
        {
            if (GameManager.Instance.AddAbility(TileOwnAbility))
            {
                TileOwnAbility.AbilityTaken();
                TileOwnAbility = null;

                DebugDisplay();
            }
        }*/
    }

    public virtual void DebugDisplay()
    {
        var rend = GetComponent<MeshRenderer>();

        if (TileOwnAbility != null)
        {
            Material mat = new Material(rend.sharedMaterial);
            mat.SetColor("_Color", TileOwnAbility.PlaceHolderProps.GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color"));

            rend.sharedMaterial = mat;                
        }
        else
        {
            rend.sharedMaterial.SetColor("_Color", _startColor);
        }
    }
}
