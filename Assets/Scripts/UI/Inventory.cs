using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using DG.Tweening;

public class Inventory : MonoBehaviour {
    [SerializeField] private GameObject UI = null;
    [SerializeField] private DragDrop SwapDragDrop = null;
    private CanvasGroup playerCanvasGroup;
    [SerializeField] GameObject player = null;
    [SerializeField] private List<DragDrop> abilityItems;
    private Camera mainCamera;

    private void Awake() {
        abilityItems = GetComponentsInChildren<DragDrop>().ToList();
        mainCamera = Camera.main;
        playerCanvasGroup = GetComponentInParent<CanvasGroup>();
    }

    public void ShowHideSwapUI(bool isShowing, Ability swapableAbility)
    {
        if (swapableAbility != null)
        {
            SwapDragDrop.SetAbility(swapableAbility);
        }

        StartCoroutine(ShowHidePlayerInterface(isShowing));
    }

    private IEnumerator ShowHidePlayerInterface(bool isShowing) {
        if (isShowing) {
            UI.transform.DOMoveY(2.5f, .25f).WaitForCompletion();
            UI.transform.DOScale(Vector3.one, .5f);    
        }
        else {
            UI.transform.DOScale(Vector3.zero, .25f).WaitForCompletion();
            UI.transform.DOMoveY(1.5f, .5f);
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

    public void FlushUI()
    {
        for (int i = 0; i < abilityItems.Count; i++)
        {
            abilityItems[i].SetAbility(null);
        }
    }
}
