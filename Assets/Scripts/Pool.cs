using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _quantity;

    private List<Enemy> _enemys = new List<Enemy>();

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        Fill();
    }

    public bool TryGetEnemy(out Enemy enemy)
    {
        enemy = null;

        if(_enemys.Count > 0)
        {
            enemy = _enemys[0];

            _enemys.Remove(enemy);
            enemy.GameObject.SetActive(true);

            enemy.Released += OnEnemyReleased;

            return true;
        }

        return false;
    }

    private void Fill()
    {
        Enemy newEnemy;

        for (int i = 0; i < _quantity; i++)
        {
            newEnemy = Instantiate(_prefab, _transform.position, Quaternion.identity);

            _enemys.Add(newEnemy);
            newEnemy.GameObject.SetActive(false);
        }
    }

    private void OnEnemyReleased(Enemy enemy)
    {
        enemy.Released -= OnEnemyReleased;

        enemy.Transform.position = _transform.position;

        _enemys.Add(enemy);
        enemy.GameObject.SetActive(false);
    }
}
