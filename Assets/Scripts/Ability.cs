using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public GameObject PlaceHolderProps;
    public Sprite AbilityIcon;
    public KeyCode ActionKeycode;

    protected GameObject _ownProps;

    public abstract void RunAction();
    public abstract void ActionForTile();

    public void SpawnProps(Transform tile, Vector3 pos)
    {
        if (_ownProps == null)
        {
            if (this.GetType() == typeof(Walk))
            {
                PlaceHolderProps = AbiltiesRotatedAssets.Instance.GetPlaceholderForDirection(((Walk)this).WalkDirection);
            }
            _ownProps = Instantiate(PlaceHolderProps, tile);
        }
        else
        {
            if (this.GetType() == typeof(Walk) && ((Walk)this).PlaceHolderProps != AbiltiesRotatedAssets.Instance.GetPlaceholderForDirection(((Walk)this).WalkDirection))
            {
                PlaceHolderProps = AbiltiesRotatedAssets.Instance.GetPlaceholderForDirection(((Walk)this).WalkDirection);
                Destroy(_ownProps.gameObject);
                _ownProps = Instantiate(PlaceHolderProps, tile);
            }

            _ownProps.SetActive(true);
        }

        _ownProps.transform.position = pos;
    }

    public void AbilityTaken()
    {
        _ownProps.SetActive(false);
        SoundFxManager.Instance.PlayPickSound();
    }
}
