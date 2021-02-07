using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerTile : Tile
{
    [SerializeField] private DoorTile _door;

    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void TileBehaviour()
    {
        if (GameManager.Instance.DoesPlayerPosessAbility(typeof(Key)))
        {
            _door.OpenDoor();
            GameManager.Instance.DestroyAbility(
                GameManager.Instance.GetFirstAbility(typeof(Key)));
            _door.canPlayerEnter = true;
        }
    }
}
