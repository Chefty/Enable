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
            Vector3 newpos = GameManager.Instance.Player.position + (Vector3.back);

            if (GameManager.Instance.GetTileAccessibility(newpos))
            {
                GameManager.Instance.playerMovement.WalkAction(Vector3.back, Quaternion.Euler(Vector3.back));

            }
        }
    }
}
