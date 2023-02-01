using UnityEngine;

[System.Serializable]
public struct FigureInfo
{
    public Vector3 spawnPosition;
    public float power;
    public FigureType type;

    public FigureInfo(Vector3 spawn, FigureType type, float power) 
    {
        this.spawnPosition = spawn;
        this.power = power;
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

