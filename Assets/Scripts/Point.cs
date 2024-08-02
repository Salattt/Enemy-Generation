using UnityEngine;

public class Point : MonoBehaviour
{
    private Transform _transform;

    public Vector3 Position { get { return _transform.position; } }

    private void Awake()
    {
        _transform = transform;
    }
}
