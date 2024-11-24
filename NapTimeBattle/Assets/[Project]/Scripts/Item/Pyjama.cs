using UnityEngine;

public class Pyjama : Item
{
    public override void Use()
    {
        //! nothing
    }

    public override void AddItem(GameObject target)
    {
        target.AddComponent<Pyjama>();
    }
}
