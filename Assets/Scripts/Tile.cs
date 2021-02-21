using UnityEngine;

public class Tile : MonoBehaviour
{
    public Ability TileOwnAbility;

    private BoxCollider TriggerCollider;

    private Color _startColor = Color.white;

    private void Start()
    {
        if (TileOwnAbility != null)
        {
            TileOwnAbility = Instantiate(TileOwnAbility);
        }

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
            TileOwnAbility.SpawnProps(transform, transform.position + new Vector3(0f, .15f, 0f));
        }
    }

    public virtual bool CheckTileAccessibility()
    {
        return true;
    }

    public virtual string CheckTileType() {
        return "normal";
    }

    public virtual void TileBehaviour()
    {
        // do something..
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.SetCurrentTile(this);

        TileBehaviour();
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
