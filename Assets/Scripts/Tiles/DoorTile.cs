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

    private void Start()
    {
        _leftPart.localRotation = Quaternion.identity;
        _rightPart.eulerAngles = Vector3.zero;
    }

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

        StartCoroutine(PUUUTEUUUh());
    }

    // TODO use DOTween instead
    IEnumerator PUUUTEUUUh()
    {
        float currentDuration = 0f;
        Vector3 currentRotation = Vector3.zero;

        while (currentDuration < _rotationDuration)
        {
            currentDuration += Time.deltaTime;
            currentRotation = Vector3.Lerp(Vector3.zero, Vector3.up * _rotationOffset, _rotationDuration / currentDuration);

            _leftPart.eulerAngles = currentRotation * -1f;
            _rightPart.eulerAngles = currentRotation;

            print(currentDuration);
        }

        yield return null;
    }
}
