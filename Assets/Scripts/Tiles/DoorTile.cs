using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorTile : Tile
{
    [SerializeField] private float _rotationOffset;
    [SerializeField] private Transform _leftPart;
    [SerializeField] private Transform _rightPart;

    public override bool CheckTileAccessibility()
    {
        return GameManager.Instance.DoesPlayerPosessAbility(typeof(Key));
    }

    public override void TileBehaviour()
    {
        GameManager.Instance.DestroyAbility(
            GameManager.Instance.GetFirstAbility(typeof(Key)));
    }

    [ContextMenu("RotateDoor")]
    public void RotateDoor()
    {
        print("dfd");
        _leftPart.DORotate(_leftPart.eulerAngles + (Vector3.down * _rotationOffset),
            1f,
            RotateMode.LocalAxisAdd);
        _rightPart.DORotate(_rightPart.eulerAngles + (Vector3.up * _rotationOffset),
             1f,
             RotateMode.LocalAxisAdd);
    }
}
