using UnityEngine;
using DG.Tweening;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
    private InteractionManager() {}
    public static InteractionManager instance = null;
    
    private Figure selectedFigure = null;

    private void Awake() 
    {
        if(instance is null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }
    }

    public void OnFigureSelected(Figure figure) 
    {
        selectedFigure = figure;
        var player = GameObject.FindObjectOfType<Player>().GetComponent<Figure>();
        if(player is null) return;
        StartCoroutine("Follow", player);
    }

    IEnumerator Follow(Figure player)
    {
        while(player.transform.position != selectedFigure.transform.position) {
            player.transform.DOMove(selectedFigure.transform.position, 0.4f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(.05f);
        }
    }
}
