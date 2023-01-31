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

    public void Awake()
    {
        _prefabs.Add(FigureType.EnemyBird, _bird);
        _prefabs.Add(FigureType.Castle, _castle);
        _prefabs.Add(FigureType.Soldier, _soldier);
        _prefabs.Add(FigureType.Player, _player);
        _prefabs.Add(FigureType.None, null);
    }
    
    public GameObject InstantiateFigure(FigureInfo info)
    {
        var obj = Instantiate(_prefabs[info.type], info.spawnPosition, Quaternion.identity);
        obj.AddComponent<Figure>();
        obj.AddComponent<BoxCollider2D>().isTrigger = true;
        obj.AddComponent<EncounterManager>();
        obj.AddComponent<Rigidbody2D>().isKinematic = true;
        obj.SendMessage("Construct", info);
        return obj;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            var info = new FigureInfo(Vector3.zero, new Vector3(8,3,0), 5, FigureType.Castle);
            var clone = InstantiateFigure(info);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            var info = new FigureInfo(Vector3.zero, new Vector3(8,3,0), 5, FigureType.EnemyBird);
            var clone = InstantiateFigure(info);
            clone.SendMessage("Path");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            var info = new FigureInfo(Vector3.zero, new Vector3(8,3,0), 2, FigureType.Player);
            var clone = InstantiateFigure(info);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var info = new FigureInfo(Vector3.zero, new Vector3(8,3,0), 5, FigureType.Soldier);
            var clone = InstantiateFigure(info);
        }

    }

}