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
            _ownProps = Instantiate(PlaceHolderProps, tile);
        }
        else
        {
            _ownProps.SetActive(true);
        }

        _ownProps.transform.position = pos;
    }

    public void AbilityTaken()
    {
        _ownProps.SetActive(false);
    }
}
