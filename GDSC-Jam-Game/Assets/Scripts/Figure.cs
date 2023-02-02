using UnityEngine;
using DG.Tweening;
using TMPro;

public class Figure : MonoBehaviour
{
    Sequence _onPath;
    [SerializeField] FigureInfo _info;
    private TMP_Text text;
    
    public void Construct(FigureInfo info) 
    {
        this._info = info;
        text = GetComponentInChildren<TextMeshPro>();
    }

    public void Path(Vector3 target, float tripTime, bool destoryOnComplete = false)
    {
        Debug.Log("Path started");
        if(!destoryOnComplete)
        {
            _onPath = DOTween.Sequence()
            .Append(this.transform.DOMove(target, tripTime).SetEase(Ease.Unset))
            .AppendInterval(1);
        }
        else 
        {
            _onPath = DOTween.Sequence()
            .Append(this.transform.DOMove(target, tripTime).SetEase(Ease.Unset))
            .OnComplete( () => Destroy(this.gameObject));
        }
    }

    public FigureType GetFigureType()
    {
        return this._info.type;
    }

    public void PausePath()
    {
        _onPath.Pause();
    }

    public void ContinuePath()
    {
        _onPath.Play();
    }

    public void OnMouseDown() 
    {
        InteractionManager.instance.OnFigureSelected(this);
    }

    public float GetPower()
    {
        return _info.power;
    }

    public void IncreasePower()
    {
        _info.power += 1;
    }

    public void DecreasePower()
    {
        _info.power -= 1;
    }


    private void Update()
    {
        text.text = _info.power.ToString();
    }
}
