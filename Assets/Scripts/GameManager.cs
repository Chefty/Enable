using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform Player;

    public int MaxAmountOfAbilities;
    public List<Ability> PlayerAbilities;
    public LayerMask mask;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        for (int i = 0; i < PlayerAbilities.Count; i++)
        {
            PlayerAbilities[i].RunAction();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            DumpAbility(1);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            DumpAbility(2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            DumpAbility(3);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            DumpAbility(4);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            DumpAbility(5);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            DumpAbility(6);
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            DumpAbility(7);
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            DumpAbility(8);
        }
    }

    public bool GetTileAccessibility(Vector3 pos)
    {
        // TODO code accessibility
        return true;
    }

    public bool AddAbility(Ability newAbility)
    {
        if (PlayerAbilities.Count < MaxAmountOfAbilities)
        {
            if (!PlayerAbilities.Contains(newAbility))
            {
                PlayerAbilities.Add(newAbility);

                // did take the ability
                return true;
            }
        }

        // didn't take the ability
        return false;
    }

    public void DumpAbility(int number)
    {
        if (PlayerAbilities.Count < number)
        {
            return;
        }

        Tile tile = GetTile(Player.transform.position);

        if (tile.TileOwnAbility != null)
        {
            return;
        }

        tile.TileOwnAbility = PlayerAbilities[number - 1];
        tile.DisplayAbility();

        PlayerAbilities.RemoveAt(number - 1);

    }

    private Tile GetTile(Vector3 pos)
    {
        RaycastHit m_Hit;

        if (Physics.Raycast(pos + (Vector3.up * 15f), Vector3.down, out m_Hit, 50f, mask))
        {
            print("found " + m_Hit.collider.name + " at " + pos);

            return m_Hit.collider.GetComponent<Tile>();
        }

        return null;
    }
}
