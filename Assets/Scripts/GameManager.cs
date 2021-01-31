using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TileAbilityPair
{
    public Tile tileWithAbility;
    public Ability Ability;
}

[Serializable]
public class StartInfos
{
    public List<TileAbilityPair> StartPairs;
    public Vector3 PlayerStartPosition;
    public List<Ability> StartAbilities;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Inventory inventory;
    public Transform Player;

    public int MaxAmountOfAbilities;
    public List<Ability> PlayerAbilities;
    public LayerMask mask;

    public Tile _currentTile;
    public Tile _prevTile;

    public StartInfos _levelAwakeState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // we save the level infos
        RegisterLevelStartInformations();

        if (inventory == null)
        {
            Debug.LogError("Please fill the Inventory variable in GameManager.");
        }
        if (Player == null)
        {
            Debug.LogError("Please fill the Player variable in GameManager.");
        }

        FillUI();
    }

    private void Update()
    {
        if (Player.gameObject.activeSelf)
        {
            for (int i = 0; i < PlayerAbilities.Count; i++)
            {
                PlayerAbilities[i].RunAction();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // restart the level here
            LevelFlush();
            LevelReload();
        }
    }

    private void FillUI()
    {
        for (int i = 0; i < PlayerAbilities.Count; i++)
        {
            inventory.AddAbility(PlayerAbilities[i]);
        }
    }

    public bool GetTileAccessibility(Vector3 pos)
    {
        Tile tile = GetTile(pos);

        if (tile != null)
        {
            return tile.CheckTileAccessibility();
        }

        return false;
    }

    public bool AddAbility(Ability newAbility)
    {
        if (PlayerAbilities.Count < MaxAmountOfAbilities)
        {
            if (!PlayerAbilities.Contains(newAbility))
            {
                PlayerAbilities.Add(newAbility);

                //TODO pas ouf à refacto
                _currentTile.TileOwnAbility.AbilityTaken();
                _currentTile.TileOwnAbility = null;

                _currentTile.DebugDisplay();

                CheckForCurrentTileAbility();

                // did take the ability
                return true;
            }
        }

        // didn't take the ability
        return false;
    }

    public void SwapAbility(Ability UIAbility)
    {
        Ability newAbility = _currentTile.TileOwnAbility;

        print("[SwapAbility][UIAbility][newAbility]" + UIAbility.name + " " + newAbility.name);

        _currentTile.TileOwnAbility = UIAbility;
        _currentTile.DisplayAbility();

        PlayerAbilities.Remove(UIAbility);
        PlayerAbilities.Add(newAbility);

        newAbility.AbilityTaken();

        CheckForCurrentTileAbility();
    }

    public void DumpAbility(Ability ability)
    {
        if (!PlayerAbilities.Contains(ability))
        {
            return;
        }

        Tile tile = GetTile(Player.transform.position);

        if (tile.TileOwnAbility != null)
        {
            return;
        }

        tile.TileOwnAbility = ability;
        tile.DisplayAbility();

        PlayerAbilities.Remove(ability);
    }

    public Tile GetTile(Vector3 pos)
    {
        RaycastHit m_Hit;

        if (Physics.Raycast(pos + (Vector3.up * 15f), Vector3.down, out m_Hit, 50f, mask))
        {
            print("found " + m_Hit.collider.name + " at " + pos);

            return m_Hit.collider.GetComponent<Tile>();
        }

        return null;
    }

    public bool DoesPlayerPosessAbility(Type type)
    {
        for (int i = 0; i < PlayerAbilities.Count; i++)
        {
            if (PlayerAbilities[i].GetType() == type)
            {
                return true;
            }
        }

        return false;
    }

    public void SetCurrentTile(Tile newTile)
    {
        _prevTile = _currentTile;
        _currentTile = newTile;

        CheckForCurrentTileAbility();
    }

    private void CheckForCurrentTileAbility()
    {
        // if any ability available on the cell
        // display swipe UI
        if (_currentTile.TileOwnAbility != null)
        {
            print("CheckForCurrentTileAbility true " + _currentTile.TileOwnAbility);
            inventory.ShowHideSwapUI(true, _currentTile.TileOwnAbility);
        }
        else
        {
            print("CheckForCurrentTileAbility false");

            inventory.ShowHideSwapUI(false, null);
        }
    }

    #region Level Flush

    private void LevelFlush()
    {
        FlushAllTilesWithAbility();
        FlushUI();
        FlushPlayerAbilities();
    }

    private void FlushPlayerAbilities()
    {
        PlayerAbilities.Clear();
    }

    private void FlushUI()
    {
        inventory.FlushUI();
    }

    private void FlushAllTilesWithAbility()
    {
        List<Tile> TilesWithAbilities = FindObjectsOfType<Tile>().Where(x => x.TileOwnAbility != null).ToList();

        TilesWithAbilities.ForEach(x =>
        {
            x.TileOwnAbility.AbilityTaken();
            x.TileOwnAbility = null;
            x.DebugDisplay();
        });        
    }

    #endregion

    #region Level reload

    private void LevelReload()
    {
        // to reload
        print("LevelReload");
        ReFillPlayerAbilities();
        ReFillTilesWithAbility();
        FillUI();
        RePlacePlayer();
    }

    private void RePlacePlayer()
    {
        Player.position = _levelAwakeState.PlayerStartPosition;
        Player.gameObject.SetActive(true);
    }

    private void ReFillTilesWithAbility()
    {
        _levelAwakeState.StartPairs.ForEach(x =>
        {
            x.tileWithAbility.TileOwnAbility = x.Ability;
            x.tileWithAbility.DisplayAbility();
        });
    }

    private void ReFillPlayerAbilities()
    {
        PlayerAbilities = new List<Ability>(_levelAwakeState.StartAbilities);
    }

    #endregion

    #region Level Save

    void RegisterLevelStartInformations()
    {
        _levelAwakeState = new StartInfos()
        {
            StartPairs = GetTilesAndTheirAbilities(),
            PlayerStartPosition = Player.transform.position,
            StartAbilities = new List<Ability>(PlayerAbilities)
        };
    }

    List<TileAbilityPair> GetTilesAndTheirAbilities()
    {
        List<Tile> TilesWithAbilities = FindObjectsOfType<Tile>().Where(x => x.TileOwnAbility != null).ToList();
        List<TileAbilityPair> pairs = new List<TileAbilityPair>();

        TilesWithAbilities.ForEach(x => pairs.Add(new TileAbilityPair()
        {
            tileWithAbility = x,
            Ability = x.TileOwnAbility
        }));

        return pairs;
    }

    #endregion
}
