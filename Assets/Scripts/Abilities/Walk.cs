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
                if (GameManager.Instance.GetTile(newpos).CheckTileType() == "water" &&
                    GameManager.Instance._currentTile.CheckTileType() == "normal") {
                    GameManager.Instance.playerMovement.Action(WalkDirection, eState.jump, eState.swim);
                }
                else if (GameManager.Instance.GetTile(newpos).CheckTileType() == "normal" &&
                    GameManager.Instance._currentTile.CheckTileType() == "water") {
                    GameManager.Instance.playerMovement.Action(WalkDirection, eState.jump, eState.idle);
                }
                else if (GameManager.Instance.GetTile(newpos).CheckTileType() == "normal")
                    GameManager.Instance.playerMovement.Action(WalkDirection, eState.walk);
            }
        }
    }

    public void UpdateDirection(Vector3 newDirection)
    {
        Vector3 propPosition = _ownProps.transform.position;
        bool wasenabled = _ownProps.activeSelf;

        WalkDirection = newDirection;
        Destroy(_ownProps);
        // just to be sure
        _ownProps = null;
        PlaceHolderProps = AbiltiesRotatedAssets.Instance.GetWalkArrowFromRotation(newDirection);

        if (wasenabled)
        {
            SpawnProps(
                GameManager.Instance.GetTile(propPosition + Vector3.up).transform,
                propPosition);
        }
    }
}
