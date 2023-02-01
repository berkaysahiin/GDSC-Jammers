using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class FigureFactory : MonoBehaviour
{
    [SerializeField] private GameObject _bird;
    [SerializeField] private GameObject _soldier;
    [SerializeField] private GameObject _castle;
    [SerializeField] private GameObject _player;

    private Dictionary<FigureType, GameObject> _prefabs = new Dictionary<FigureType, GameObject>();
    private FigureFactory() {}
    public static FigureFactory instance = null;

    public void Awake()
    {
        if(instance is null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(this.gameObject);
        }

        _prefabs.Add(FigureType.EnemyBird, _bird);
        _prefabs.Add(FigureType.Castle, _castle);
        _prefabs.Add(FigureType.Soldier, _soldier);
        _prefabs.Add(FigureType.Player, _player);
        _prefabs.Add(FigureType.None, null);
    }
    
    public GameObject InstantiateFigure(FigureInfo info)
    {
        var obj = Instantiate(_prefabs[info.type], info.spawnPosition, Quaternion.identity);
        obj.AddComponent<Figure>().Construct(info);
        obj.AddComponent<BoxCollider2D>().isTrigger = true;
        obj.AddComponent<Encounter>();
        obj.AddComponent<Rigidbody2D>().isKinematic = true;
        return obj;
    }
}