using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilitySlot : MonoBehaviour, IDropHandler {
    private Image abilityIcon;
    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        if (transform.GetChild(0))
            abilityIcon = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData) {
        Sprite tmpAbilityIcon = abilityIcon.sprite;

        if (eventData.pointerDrag == null)
            return;
        else if (eventData.pointerDrag.gameObject.CompareTag("TileAbility")) {
            var tileUI = eventData.pointerDrag.GetComponent<DragDrop>();
            Ability tmpAbility = tileUI.ability;
            var PlayerUI = GetComponentInChildren<DragDrop>();

            print("[OnDrop]->[tileUI][PlayerUI]" + tileUI.name + " " + PlayerUI.name);
            //var ContainedAbility = PlayerUI.ability;
            if (PlayerUI.ability == null)
                GameManager.Instance.AddAbility(tileUI.ability);
            else
                GameManager.Instance.SwapAbility(PlayerUI.ability);
            PlayerUI.SetAbility(tmpAbility);
        }
    }
}
