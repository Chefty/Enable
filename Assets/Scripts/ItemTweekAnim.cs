using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemTweekAnim : MonoBehaviour
{
    private void Start() {
        transform.DOLocalRotate(new Vector3(0.0f, 360f, 0.0f), 5.0f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetRelative();transform.DOLocalRotate(new Vector3(0.0f, 360f, 0.0f), 5.0f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetRelative();
        transform.DOLocalMoveY(0.25f, 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetRelative();
    }
}
