using UnityEngine;

public class Telecomande : Item
{
    [SerializeField, Range(0, 1)] private float _ratioDaronageToSet = .9f;
    public override void Use()
    {
        Daroned.instance.SetDarnedRatio(_ratioDaronageToSet);
        base.Use();
    }

    public override void AddItem(GameObject target)
    {
        Telecomande t = target.AddComponent<Telecomande>();
        t.Use();
    }
}