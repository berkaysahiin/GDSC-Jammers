using UnityEngine;

[System.Serializable]
public struct FigureInfo
{
    public Vector3 spawnPosition;
    public Vector3 target;
    public float tripTime;
    public FigureType type;

    public FigureInfo(Vector3 spawn, Vector3 target, float tripTime, FigureType type) 
    {
        this.spawnPosition = spawn;
        this.target = target;
        this.tripTime = tripTime;
        this.type = type;
    }
}

public enum FigureType
{
    Player,
    EnemyBird,
    Soldier,
    Castle,
    None,
}

