using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkDown", menuName = "Abilities/WalkDown")]
public class WalkDown : Ability
{
    public override void ActionForTile()
    {
        throw new NotImplementedException();
    }

    public override void RunAction()
    {
        if (Input.GetKeyUp(ActionKeycode))
        {
            GameManager.Instance.Player.transform.position += Vector3.back;
        }
    }
}
