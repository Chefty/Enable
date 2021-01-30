using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;
    private RectTransform parentRectTransform;
    public Image abilityIcon;
    private Vector2 mousePos;
    public Ability ability;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = transform.position;
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        abilityIcon = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
        transform.position = canvas.transform.TransformPoint(mousePos);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (canvasGroup) {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (canvasGroup) {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        
        if (eventData.pointerDrag.gameObject.CompareTag("InventoryAbility") &&
            !RectTransformUtility.RectangleContainsScreenPoint(parentRectTransform, transform.position)) {
            abilityIcon.sprite = null;
            abilityIcon.enabled = false;
            
            //Drop ability
            GameManager.Instance.DumpAbility(ability);
            ability = null;
        }
        transform.position = initialPosition;
    }

    public void SetAbility(Ability ability) {
        this.ability = ability;
        abilityIcon.sprite = ability.AbilityIcon;
        abilityIcon.enabled = true;
    }
}
