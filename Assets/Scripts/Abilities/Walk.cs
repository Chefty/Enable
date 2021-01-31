using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Walk", menuName = "Abilities/Walk")]
public class Walk : Ability
{
    public Vector3 WalkDirection;

    public override void ActionForTile()
    {
        throw new NotImplementedException();
    }

    public override void RunAction()
    {
        if (Input.GetKeyUp(ActionKeycode))
        {
            Vector3 newpos = GameManager.Instance.Player.position + WalkDirection;

            if (GameManager.Instance.GetTileAccessibility(newpos))
            {
                GameManager.Instance.playerMovement.WalkAction(WalkDirection);
            }
        }
    }

    public void UpdateDirection(Vector3 newDirection)
    {
        //WalkDirection = newDirection;
        // just to be sure
        AbilityIcon = AbiltiesRotatedAssets.Instance.GetWalkArrowFromRotation(newDirection);
        ActionKeycode = AbiltiesRotatedAssets.Instance.GetKeycodeForDirection(newDirection);

        //if (wasenabled)
        //{
        //    SpawnProps(
        //        GameManager.Instance.GetTile(propPosition + Vector3.up).transform,
        //        propPosition);
        //}
    }
}
