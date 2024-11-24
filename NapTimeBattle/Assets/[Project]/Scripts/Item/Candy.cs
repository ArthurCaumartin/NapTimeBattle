using UnityEngine;

public class Candy : Item
{
    [SerializeField] private float _healValue;

    public override void Use()
    {
        PlayerLife pl = GetComponent<PlayerLife>();
        pl?.Heal(_healValue);
        base.Use();
    }

    public override void AddItem(GameObject target)
    {
        target.AddComponent<Candy>();
    }
}