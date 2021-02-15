using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void DebugDisplay()
    {
    }

    public override void TileBehaviour() {
        if (!GameManager.Instance.DoesPlayerPosessAbility(typeof(Shoes))) {
            StartCoroutine(StartDeathDelayCO(.25f));
        }
    }

    private IEnumerator StartDeathDelayCO(float delay) {

        yield return new WaitForSeconds(delay);

        SoundManager.Instance.PlayDeathSound();
        GameManager.Instance.playerMovement.currentState = eState.death;
        GameManager.Instance.onDieOnLava();
        GameManager.Instance.isDead = true;
    }
}
