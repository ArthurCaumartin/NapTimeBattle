using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 5;
    [SerializeField] private List<ItemSpawnPoint> _pointList;
    [SerializeField] private List<Item> _itemList;
    private float _spawnTime;

    private void Update()
    {
        _spawnTime += Time.deltaTime;
        if(_spawnTime >= _spawnDelay)
        {
            _spawnTime = 0;
            _pointList[Random.Range(0, _pointList.Count)].SpawnItem(_itemList[Random.Range(0, _itemList.Count)]);
        }
    }
}
