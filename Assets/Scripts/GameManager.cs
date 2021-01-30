using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform Player;

    public int MaxAmountOfAbilities;
    public List<Ability> PlayerAbilities;

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
    }

    public bool GetTileAccessibility(Vector3 pos)
    {
        // TODO code accessibility
        return true;
    }

    public void AddAbility(Ability newAbility)
    {
        if (PlayerAbilities.Count < MaxAmountOfAbilities)
        {
            if (!PlayerAbilities.Contains(newAbility))
            {
                PlayerAbilities.Add(newAbility);
            }
        }
    }
}
