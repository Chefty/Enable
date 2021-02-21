using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMoveY : MonoBehaviour
{
    //Had a glitch with DOtween when spamming the call it was bugged
    public void Move(float amount) {
        GetComponent<RectTransform>().transform.localPosition = new Vector3(0, transform.localPosition.y + amount, 0);
    }
}