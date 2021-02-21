using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilitySlot : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData) {

        if (eventData.pointerDrag == null)
            return;
        else if (eventData.pointerDrag.gameObject.CompareTag("TileAbility")) {
            var tileUI = eventData.pointerDrag.GetComponent<DragDrop>();
            Ability tmpAbility = tileUI.ability;
            var PlayerUI = GetComponentInChildren<DragDrop>();

            if (PlayerUI.ability == null)
                GameManager.Instance.AddAbility(tileUI.ability);
            else
                GameManager.Instance.SwapAbility(PlayerUI.ability);
            PlayerUI.SetAbility(tmpAbility);
        }
    }
}
