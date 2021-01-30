using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Inventory inventory;
    public Transform Player;

    public int MaxAmountOfAbilities;
    public List<Ability> PlayerAbilities;
    public LayerMask mask;

    Tile _currentTile;

    private void Awake()
    {
        Instance = this;
    }

    private void Start() {
        for (int i = 0; i < PlayerAbilities.Count; i++) {
            inventory.AddAbility(PlayerAbilities[i]);
        }
    }

    private void Update()
    {
        for (int i = 0; i < PlayerAbilities.Count; i++)
        {
            PlayerAbilities[i].RunAction();
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
}
