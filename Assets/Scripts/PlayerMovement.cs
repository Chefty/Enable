﻿using System.Collections;
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
    private float timeIdle = 0f;
    private eState currentState;
    private Vector3 targetPosition;
    private Vector3 targetRotation;
    public bool isLerping = false;

    public float timeToMove = 1f;
    public float rotationSmoothFactor = 350f;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        targetPosition = transform.localPosition;
    }

    private void FixedUpdate() {
        switch(currentState) {
            case eState.idle:
                timeIdle += Time.deltaTime;
                if (timeIdle > 8f) {
                    currentState = Random.Range(0f, 1f) > .5f ? eState.idea : eState.unhappy;
                    timeIdle = 0f;
                }
                break;
            case eState.jump:
                //nothing yet
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

    public void WalkAction(Vector3 walkDirection) {
        
        currentState = eState.walk;

        if (!isLerping && !animator.GetCurrentAnimatorStateInfo(0).IsName(eState.walk.ToString())) {
            targetPosition += walkDirection;
            targetRotation = walkDirection;
            StartCoroutine(ActionCO(currentState));
            StartCoroutine(MovePlayerLerpCO(targetPosition, targetRotation, timeToMove));
        }
    }

    private IEnumerator ActionCO(eState state) {
        currentState = state;
        
        if (currentState == eState.walk) { //trigger animation
            animator.SetTrigger(currentState.ToString());
            yield return null;
        } 
        else { //boolean animation
            animator.SetBool(currentState.ToString(), true);

            yield return new WaitForEndOfFrame();

            animator.SetBool(currentState.ToString(), false);
            currentState = eState.idle;
            timeIdle = 0f;
        }
    }

    IEnumerator MovePlayerLerpCO(Vector3 targetPosition, Vector3 targetRotation, float duration) {
        isLerping = true;
        float time = 0;
        Vector3 startPosition = transform.localPosition;

        while (time < duration) {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.LookRotation(targetRotation, Vector3.up), rotationSmoothFactor * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        animator.SetBool(currentState.ToString(), false); //tile reached - end animation
        transform.localPosition = targetPosition;
        isLerping = false;
        timeIdle = 0f;
        currentState = eState.idle;
    }
}