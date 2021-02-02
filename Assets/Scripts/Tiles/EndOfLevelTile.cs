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
        print(SceneManager.GetActiveScene().buildIndex + 1);

        //print("Congrat you finished the level !! ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
