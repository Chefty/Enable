using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eState {
    idle,
    jump,
    walk,
    unhappy,
    idea,
    swim
}

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float timeIdle = 0f;
    public eState currentState;
    public Vector3 targetPosition;
    public Quaternion targetRotation; //Optional of course
    public float smoothFactor = 2f;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        targetPosition = transform.position;
        targetRotation = transform.rotation;
    }

    private void Update() {
        switch(currentState) {
            case eState.idle:
                timeIdle += Time.deltaTime;
                if (timeIdle > 8f) {
                    currentState = Random.Range(0f, 1f) > .5f ? eState.idea : eState.unhappy;
                }
                break;
            case eState.jump:
                //nothing yet
                break;
            case eState.walk:
                StartCoroutine(ActionCO(currentState));
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * smoothFactor);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothFactor);
                Debug.Log("01: " + Vector3.Distance(transform.position, targetPosition));
                if (Vector3.Distance(transform.position, targetPosition) < .1f) {
                    animator.SetBool(currentState.ToString(), false);
                    currentState = eState.idle;
                }
                break;
            case eState.unhappy:
            case eState.idea:
                StartCoroutine(ActionCO(currentState));
                break;
            case eState.swim:
                //nothing yet
                break;
            default:
                break;
        }
    }

    private IEnumerator ActionCO(eState state) {
        currentState = state;
        animator.SetBool(currentState.ToString(), true);

        yield return new WaitForEndOfFrame();
        
        animator.SetBool(currentState.ToString(), false);
        timeIdle = 0f;
    }
}
