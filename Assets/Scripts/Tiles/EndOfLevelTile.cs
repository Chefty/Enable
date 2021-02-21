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
