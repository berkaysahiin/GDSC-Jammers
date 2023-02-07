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
                new FigureInfo(location.position, FigureType.Castle, Random.Range(10, 40))
            );
        }

        foreach(var location in soldierSpawnPoints)
        {
            FigureFactory.instance.InstantiateFigure(
                new FigureInfo(location.position, FigureType.Soldier, Random.Range(5, 7))
            );
        }


        FigureFactory.instance.InstantiateFigure(new FigureInfo(playerSpawnPoint.position, FigureType.Player, 8));


        StartCoroutine("SpawnBirds");
    }


    void Start()
    {
        InvokeRepeating("SpawnBirds", 0, 5);
    }
    

    private void SpawnBirds() 
    {
        if(InteractionManager.instance.allowed)
        {
            var len = castleSpawnPoints.Capacity;
            var spawnPoint = castleSpawnPoints[Random.Range(0, len)].position;
            var targetPoint = castleSpawnPoints[Random.Range(0, len)].position;
            var bird = FigureFactory.instance.InstantiateFigure(new FigureInfo(spawnPoint, FigureType.EnemyBird, 5));
            bird.GetComponent<Figure>().Path(targetPoint, 5, true);
        }
    }


    private void Update() {
        print(InteractionManager.instance.allowed);
    }
}
