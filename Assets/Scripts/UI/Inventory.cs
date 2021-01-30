using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private List<GameObject> abilityItems;
    private Camera mainCamera;

    private void Awake() {
        foreach (Transform child in transform)
            abilityItems.Add(child.gameObject);
        mainCamera = Camera.main;
    }

    private void Update() {
        var camToPlayerDist = Vector3.Distance(mainCamera.transform.position, player.transform.position);
        
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camToPlayerDist);
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        camToPlayerDist = Vector3.Distance(mousePosition, player.transform.position);

        if (camToPlayerDist <= 5f)
            StartCoroutine(ShowHideAbilitiesInventory(true));
        else
            StartCoroutine(ShowHideAbilitiesInventory(false));
    }

    IEnumerator ShowHideAbilitiesInventory(bool isShowing) {

        for (int i = 0; i < abilityItems.Count; i++) {
            abilityItems[i].SetActive(isShowing);
        }

        yield return null;
    }
}
