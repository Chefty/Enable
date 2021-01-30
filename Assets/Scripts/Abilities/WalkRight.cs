using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkRight", menuName = "Abilities/WalkRight")]
public class WalkRight : Ability
{
    public override void ActionForTile()
    {
        throw new NotImplementedException();
    }

    public override void RunAction()
    {
        if (Input.GetKeyUp(ActionKeycode))
        {
            GameManager.Instance.Player.transform.position += Vector3.right;
        }
    }
}
