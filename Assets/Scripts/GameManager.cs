using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform Player;

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
}
