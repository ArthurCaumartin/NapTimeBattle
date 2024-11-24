using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    [SerializeField] float _delayToAllowNewItem;
    private float _allowTime;
    private Item _currentItem;
    private void Update() { _allowTime += Time.deltaTime; }

    public void SpawnItem(Item itemToSpawn) 
    {
        if(_currentItem || _allowTime < _delayToAllowNewItem) return;

        _currentItem = Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        _currentItem.OnGrabEvent.AddListener(() =>
        {
            _allowTime = 0;
            _currentItem = null;
        });
    }
}
