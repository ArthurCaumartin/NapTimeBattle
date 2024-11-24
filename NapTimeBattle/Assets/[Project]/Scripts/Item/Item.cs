using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5;
    private float _currentTime;
    public UnityEvent OnGrabEvent;

    void Start()
    {
        if(tag == "Player") Use();
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _lifeTime)
        {
            Destroy(tag == "Player" ? this : gameObject);
        }
    }

    public virtual void Use()
    {
        Destroy(this);
    }

    public virtual void AddItem(GameObject target)
    {
        
    }

    public void OnUse(InputValue value)
    {
        if (value.Get<float>() > .5f)
            Use();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        Item otherItem = other.GetComponent<Item>();
        if (otherItem) Destroy(otherItem);
        AddItem(other.gameObject);
        OnGrabEvent.Invoke();
        Destroy(gameObject);
    }
}
