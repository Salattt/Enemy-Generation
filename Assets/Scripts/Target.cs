using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Target : Point
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Release(this);
        }
    }
}
