using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class Inventory : MonoBehaviour {
    [SerializeField] private GameObject UI;
    [SerializeField] private DragDrop SwapDragDrop;
    private Canvas playerCanvas;
    [SerializeField] GameObject player;
    [SerializeField] private List<DragDrop> abilityItems;
    private Camera mainCamera;

    private void Awake() {
        abilityItems = GetComponentsInChildren<DragDrop>().ToList();
        mainCamera = Camera.main;
        playerCanvas = GetComponentInParent<Canvas>();
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

    public void ShowHideSwapUI(bool isShowing, Ability swapableAbility)
    {
        UI.gameObject.SetActive(isShowing);

        if (swapableAbility != null)
        {
        print("ShowHideSwapUI " + swapableAbility.name);
            SwapDragDrop.SetAbility(swapableAbility);
        }
    }

    IEnumerator ShowHideAbilitiesInventory(bool isShowing) {

        for (int i = 0; i < abilityItems.Count; i++) {
            playerCanvas.enabled = isShowing;
        }

        yield return null;
    }

    public void AddAbility(Ability ability) {
        for (int i = 0; i < abilityItems.Count; i++) {
            if (abilityItems[i].ability == null) {
                abilityItems[i].SetAbility(ability);
                break;
            }
        }
    }
}
