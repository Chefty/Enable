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
            abilityIcon.enabled = true;
            abilityIcon.sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            if (tmpAbilityIcon)
                eventData.pointerDrag.GetComponent<Image>().sprite = tmpAbilityIcon;
            else
                eventData.pointerDrag.GetComponent<Image>().enabled = false;
        }
    }
}
