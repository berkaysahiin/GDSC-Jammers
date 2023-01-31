using UnityEngine;
using DG.Tweening;

public class EncounterManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        var other_figure = other.GetComponent<Figure>();
        if(other is null) return;

        var this_figure = this.GetComponent<Figure>();

        Sequence sequence = DOTween.Sequence();

        switch(this_figure.GetFigureType())
        {
            case FigureType.Player:
            {
                switch(other_figure.GetFigureType()) 
                {
                    case FigureType.EnemyBird:
                    {
                        this_figure.PausePath();
                        other_figure.PausePath();
                        print("player + enemy bird");
                        break;
                    }
                    case FigureType.Soldier:
                    {
                        this_figure.PausePath();
                        other_figure.PausePath();
                        print("player + soldier");
                        break;
                    }
                    case FigureType.Castle:
                    {
                        this_figure.PausePath();
                        other_figure.PausePath();
                        print("player + castle");
                        break;
                    }

                }
                break;
            }
            case FigureType.EnemyBird:
            {
                switch(other_figure.GetFigureType())
                {
                    case FigureType.Castle:
                    {
                        this_figure.PausePath();
                        other_figure.PausePath();
                        print("Enemy bird + castle");
                        break;
                    }
                }
                break;
            }
        }

        sequence.Play();
    }
}
