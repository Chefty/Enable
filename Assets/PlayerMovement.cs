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
    public Vector3 direction;
    public float smoothFactor = 1f;
    private Quaternion currentRotation; 
    private float timeCount = 0.0f;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        direction = transform.position;
    }

    private void FixedUpdate() {
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
                //StartCoroutine(ActionCO(currentState));
                timeCount = timeCount + Time.deltaTime;
                if (direction != Vector3.zero) {
                    transform.position = Vector3.Lerp(transform.position, direction, smoothFactor * timeCount);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), smoothFactor * timeCount);
                }
                //if (Vector3.Distance(transform.position, direction) < .1f) {
                //    animator.SetBool(currentState.ToString(), false);
                //}
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

    public void WalkAction(Vector3 newPosition, Quaternion newRotation) {
        currentState = eState.walk;

        //if (Vector3.Distance(transform.position, direction) < .1f)
        currentRotation = transform.rotation;
        direction += newPosition;
    }

    private IEnumerator ActionCO(eState state) {
        currentState = state;
        animator.SetBool(currentState.ToString(), true);

        yield return new WaitForEndOfFrame();
        
        animator.SetBool(currentState.ToString(), false);
        timeIdle = 0f;
    }
}
