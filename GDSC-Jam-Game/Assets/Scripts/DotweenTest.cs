using UnityEngine;
using DG.Tweening;

public class DotweenTest : MonoBehaviour
{
    public Transform destination;

    private void Start()
    {
        Vector3[] Path = new Vector3[]{destination.position, this.transform.position};
        
        //transform.DOMove(destination.position, 4.0f, false);

        transform.DOPath(Path, 4.0f);
    }
}

