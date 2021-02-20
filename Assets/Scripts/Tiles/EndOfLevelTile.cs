using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelTile : Tile
{
    public override bool CheckTileAccessibility()
    {
        return true;
    }

    public override void TileBehaviour()
    {
        SoundFxManager.Instance.PlayWinSound();
        GameManager.Instance.PrepareLoadNextLevel();
    }
}
