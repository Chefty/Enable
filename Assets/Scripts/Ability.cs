using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public GameObject PlaceHolderProps;
    public KeyCode ActionKeycode;

    GameObject _ownProps;
    public abstract void RunAction();
    public abstract void ActionForTile();
    public void SpawnProps(Transform tile, Vector3 pos)
    {
        _ownProps = Instantiate(PlaceHolderProps, tile);

        _ownProps.transform.position = pos;
    }
}
