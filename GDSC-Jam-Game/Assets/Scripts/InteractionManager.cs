using UnityEngine;
using DG.Tweening;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;

    private InteractionManager() {}
    private Figure selectedFigure = null;
    private Figure player = null;

    private void Awake() 
    {
        if(instance is null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }
    }

    private void Start() 
    {
        player = FindObjectOfType<Player>().GetComponent<Figure>();
    }

    public void OnFigureSelected(Figure figure) 
    {
        selectedFigure = figure;
        StartCoroutine("Follow");
    }

    IEnumerator Follow()
    {
        while(player.transform.position != selectedFigure.transform.position) {
            player.Path(selectedFigure.transform.position, 2);
            yield return new WaitForSeconds(2);
        }
    }

    public void SignalPlayerStop()
    {
        StopCoroutine("Follow");
        player.PausePath();
    }
}
