using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUIFaceCamera : MonoBehaviour
{
    private void Update() {
        Vector3 relativePos = Camera.main.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
    }
}
