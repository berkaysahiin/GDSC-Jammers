using UnityEngine;
using DG.Tweening;

public class DotweenTest : MonoBehaviour
{
    public Transform destination;

    private void Start() 
    {
        Tween tween = this.transform.DOMove(destination.position, 3, false)
            .SetEase(Ease.Unset);

        tween.OnComplete(delegate()
                {
                    tween.Restart();
                });
    }
}

