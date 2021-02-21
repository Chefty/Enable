using UnityEngine;

public class AddASlotTile : Tile
{
    public Material grass;
    private bool _isAlreadyUsed = false;
    MeshRenderer rend;
    RandomFauna fauna;
    Transform Icon;

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
        if (!_isAlreadyUsed)
        {
            GameManager.Instance.AddSlot();
        }

        _isAlreadyUsed = true;

        rend.sharedMaterial = grass;
        fauna.enabled = true;

        Destroy(Icon.gameObject);
    }
}
