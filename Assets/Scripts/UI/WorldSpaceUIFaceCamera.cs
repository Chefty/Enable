using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUIFaceCamera : MonoBehaviour
{
    public float smoothFactor = 10f;

    private void Update() {
        Vector3 relativePos = Camera.main.transform.position - transform.position;

        relativePos.x = 90f;
        relativePos.z = 90f;

        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, smoothFactor * Time.deltaTime);
    }
}
