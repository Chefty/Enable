using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return true;//GameManager.Instance.DoesPlayerPosessAbility(typeof(Swim));
    }

    public override string CheckTileType() {
        return "water";
    }

    public override void TileBehaviour()
    {
        if (!GameManager.Instance.DoesPlayerPosessAbility(typeof(Swim)))
        {
            StartCoroutine(StartDeathDelayCO(.25f));
        }
    }

    private IEnumerator StartDeathDelayCO(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.playerMovement.secondState = eState.death;
        SoundManager.Instance.PlayDeathSound();
        GameManager.Instance.onDieOnLava();
        GameManager.Instance.isDead = true;
    }
}
