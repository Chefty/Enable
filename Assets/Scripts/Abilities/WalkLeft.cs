using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkLeft", menuName = "Abilities/WalkLeft")]
public class WalkLeft : Ability
{
    public override void ActionForTile()
    {
        throw new NotImplementedException();
    }

    public override void RunAction()
    {
        if (Input.GetKeyUp(ActionKeycode))
        {
            GameManager.Instance.Player.transform.position += Vector3.left;
        }
    }
}
