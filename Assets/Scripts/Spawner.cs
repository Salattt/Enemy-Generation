using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Target _target;
    [SerializeField] private float _spawnTime;

    private float _time = 0;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time > _spawnTime)
        {
            _time = 0;
            
            if(_pool.TryGetEnemy(out Enemy enemy))
            {
                enemy.Transform.position = _transform.position;
                enemy.SetTarget(_target);
            }
        }
    }
}
