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
            Vector3 newpos = GameManager.Instance.Player.position + (Vector3.right);

            if (GameManager.Instance.GetTileAccessibility(newpos))
            {
                GameManager.Instance.Player.transform.position += Vector3.right;
            }
        }
    }
}
