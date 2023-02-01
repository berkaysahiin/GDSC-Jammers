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

    public void Path(Vector3 target, float tripTime)
    {
        Debug.Log("Path started");
        _onPath = DOTween.Sequence()
            .Append(this.transform.DOMove(target, tripTime).SetEase(Ease.Unset))
            .AppendInterval(1);
    }

    public FigureType GetFigureType()
    {
        return this._info.type;
    }

    public void PausePath()
    {
        _onPath.Pause();
    }

    public void OnMouseDown() 
    {
        InteractionManager.instance.OnFigureSelected(this);
    }
}
