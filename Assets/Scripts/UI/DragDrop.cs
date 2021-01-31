using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] Canvas canvas = null;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;
    private RectTransform parentRectTransform;
    public Image abilityIcon;
    private Vector2 mousePos;
    public Ability ability;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = transform.localPosition;
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        abilityIcon = GetComponent<Image>();
    }

    private void OnEnable() {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData) {
        if (gameObject.CompareTag("TileAbility")) { //World Space UI
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
            transform.position = canvas.transform.TransformPoint(mousePos);
        }
        else { //Screenspace UI
            transform.position = Input.mousePosition;
        }
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
        GetComponent<RectTransform>().localPosition = initialPosition;
    }

    public void SetAbility(Ability newability) {

        if (newability != null)
        {
            if (this.ability != null)
            {
                print("[GONAME][SetAbility][before][after]" + gameObject.name + " " + this.ability.name + " " + newability.name);
            }
            print("[GONAME][SetAbility][before][after] NULL " + gameObject.name + " " + newability.name);
        }

        this.ability = newability;

        if (newability == null)
        {
            abilityIcon.sprite = null;
        }
        else
        {
            abilityIcon.sprite = newability.AbilityIcon;
        }

        abilityIcon.enabled = true;
        GetComponent<RectTransform>().localPosition = initialPosition;
    }
}
