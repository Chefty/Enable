using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorTile : Tile
{
    [SerializeField] private float _rotationOffset;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private Transform _leftPart;
    [SerializeField] private Transform _rightPart;

    public bool canPlayerEnter = false;

    public override bool CheckTileAccessibility()
    {
        return canPlayerEnter;
    }

    [ContextMenu("RotateDoor")]
    public void OpenDoor()
    {
        StartCoroutine(DoOpenDoor());
    }

    IEnumerator DoOpenDoor()
    {
        _leftPart.DOLocalRotate(
            new Vector3(0, -_rotationOffset, 0),
            1f,
            RotateMode.Fast).SetEase(Ease.InOutSine);
        _rightPart.DOLocalRotate(
             new Vector3(0, _rotationOffset, 0),
             1f,
            RotateMode.Fast).SetEase(Ease.InOutSine);

        yield return null;
    }
}
