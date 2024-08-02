using System;
using UnityEngine;

[RequireComponent(typeof(PointMover))]

public class Enemy : MonoBehaviour
{
    private PointMover _mover;
    private Target _target;

    public event Action<Enemy> Released;

    public Transform Transform {  get; private set; }
    public GameObject GameObject { get; private set; }

    private void Awake()
    {
        Transform = transform;
        GameObject = gameObject;
        _mover = GetComponent<PointMover>();
    }

    public void SetTarget(Target target)
    {
        _mover.SetPoint(target); 
        _target = target;
    }

    public void Release(Target target)
    {
        if(target == _target)
            Released?.Invoke(this);
    }
}
