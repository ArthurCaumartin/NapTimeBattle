using UnityEngine;

public class Pyjama : Item
{
    public override void Use()
    {
        //! nothing
    }

    public override void AddItem(GameObject target)
    {
        Pyjama p = target.AddComponent<Pyjama>();
        p.Use();
    }
}
