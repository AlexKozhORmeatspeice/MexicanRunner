using Assets.Scripts;
using UnityEngine;

public class Partition : Obstacle
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (Data.characterCrouched) return;
        base.OnTriggerEnter2D(collision);
    }
}
