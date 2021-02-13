using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInverter : MonoBehaviour
{
    [ContextMenu("InvertSymetricaly")]
    public void InvertSymetricaly()
    {
        Transform[] transforms = FindObjectsOfType<Transform>();

        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].localPosition *= -1f;
        }
    }
}
