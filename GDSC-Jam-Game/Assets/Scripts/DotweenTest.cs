using UnityEngine;
using DG.Tweening;

public class DotweenTest : MonoBehaviour
{
    public Transform destination;

    private void Start() 
    {
        Tween tween = this.transform.DOPath(new Vector3[] {destination.position, transform.position}, 5)
            .SetEase(Ease.Unset);

        tween.OnComplete(() => tween.Restart());
    }
}

