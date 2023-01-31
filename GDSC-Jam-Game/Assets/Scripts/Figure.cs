using UnityEngine;
using DG.Tweening;

public class Figure : MonoBehaviour
{
    Sequence _onPath;
    FigureInfo _info;

    public void Construct(FigureInfo info) 
    {
        this._info = info;
    }

    public void Path()
    {
        Debug.Log("Path started");
        _onPath = DOTween.Sequence()
            .Append(this.transform.DOMove(_info.target, _info.tripTime).SetEase(Ease.Linear))
            .AppendInterval(1);
    }

    public FigureType GetFigureType()
    {
        return this._info.type;
    }

    public void SetTarget(Vector3 target)
    {
        this._info.target = target;
    }

    public void PausePath()
    {
        _onPath.Pause();
    }

    public void ContiniuePath()
    {
        _onPath.Play();
    }

    public void OnMouseDown() 
    {
        InteractionManager.instance.OnFigureSelected(this);
    }
}
