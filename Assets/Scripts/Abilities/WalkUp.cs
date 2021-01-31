using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkUp", menuName = "Abilities/WalkUp")]
public class WalkUp : Ability
{
    public override void ActionForTile()
    {
        throw new NotImplementedException();
    }

    public override void RunAction()
    {
        if (Input.GetKeyUp(ActionKeycode))
        {
            Vector3 newpos = GameManager.Instance.Player.position + (Vector3.forward);

            if (GameManager.Instance.GetTileAccessibility(newpos))
            {
                GameManager.Instance.playerMovement.WalkAction(Vector3.forward, Quaternion.Euler(Vector3.forward));
            }
        }
    }
}
