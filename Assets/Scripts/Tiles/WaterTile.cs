using System.Collections;
using UnityEngine;

public class WaterTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return true;
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
        SoundFxManager.Instance.PlayDeathSound();
        GameManager.Instance.onDieOnLava();
        GameManager.Instance.isDead = true;
        GameManager.Instance.DisplayDeathScreen();
    }
}
