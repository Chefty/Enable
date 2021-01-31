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
            ForceRun();
        }
    }

    public void ForceRun()
    {
        Debug.Log(name);
        Vector3 newpos = GameManager.Instance.Player.parent.TransformPoint(
            GameManager.Instance.Player.localPosition + WalkDirection);
        //Vector3 newpos = GameManager.Instance.Player.position + WalkDirection;

        if (GameManager.Instance.GetTileAccessibility(newpos))
        {
            if (GameManager.Instance.GetTile(newpos).CheckTileType() == "water" &&
                GameManager.Instance._currentTile.CheckTileType() == "normal")
            {
                Debug.Log("001");
                GameManager.Instance.playerMovement.Action(WalkDirection, eState.jump, eState.swim);
            }
            else if (GameManager.Instance.GetTile(newpos).CheckTileType() == "normal" &&
                GameManager.Instance._currentTile.CheckTileType() == "water")
            {
                Debug.Log("002");
                GameManager.Instance.playerMovement.Action(WalkDirection, eState.jump, eState.unhappy);
            }
            else if (GameManager.Instance.GetTile(newpos).CheckTileType() == "water" &&
                  GameManager.Instance._currentTile.CheckTileType() == "water")
            {
                Debug.Log("002.5");
                GameManager.Instance.playerMovement.Action(WalkDirection, eState.swim, eState.idle);
            }
            else if (GameManager.Instance.GetTile(newpos).CheckTileType() == "normal")
            {
                Debug.Log("003");
                GameManager.Instance.playerMovement.Action(WalkDirection, eState.walk);
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
