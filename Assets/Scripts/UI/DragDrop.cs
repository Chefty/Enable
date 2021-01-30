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
    private Image abilityIcon;
    private Vector2 mousePos;

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
            !RectTransformUtility.RectangleContainsScreenPoint(parentRectTransform, canvas.transform.TransformPoint(mousePos))) {
            abilityIcon.enabled = false;
            Debug.Log("OUT! -- " + parentRectTransform.gameObject.name);
        }
        transform.position = initialPosition;
    }
}
