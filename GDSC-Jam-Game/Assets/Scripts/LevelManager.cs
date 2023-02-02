using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public List<Transform> castleSpawnPoints = new List<Transform>();
    public List<Transform> soldierSpawnPoints = new List<Transform>();
    public List<Transform> enemyBirdSpawnPoints = new List<Transform>();
    public Transform playerSpawnPoint = null;

    void Awake() 
    {
        foreach(var location in castleSpawnPoints)
        {
            FigureFactory.instance.InstantiateFigure(
                new FigureInfo(location.position, FigureType.Castle, Random.Range(50, 100))
            );
        }

        foreach(var location in soldierSpawnPoints)
        {
            FigureFactory.instance.InstantiateFigure(
                new FigureInfo(location.position, FigureType.Soldier, Random.Range(10, 50))
            );
        }

        foreach(var location in enemyBirdSpawnPoints)
        {
            FigureFactory.instance.InstantiateFigure(
                new FigureInfo(location.position, FigureType.EnemyBird, Random.Range(1, 10))
            );
        }

        FigureFactory.instance.InstantiateFigure(new FigureInfo(playerSpawnPoint.position, FigureType.Player, 8));
    }
}
