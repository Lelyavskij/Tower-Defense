using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour
{
    [SerializeField]
    private Tower _tower;

    private bool _targetFound;
    private GameObject _currentTarget;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyEntity>();
        if (enemy != null && !_targetFound)
        {
            _tower.target = other.gameObject.transform;
            _currentTarget = other.gameObject;
            _targetFound = true;
        }
    }

    private void Update()//TODO change this
    {
        if (!_currentTarget)
        {
            _targetFound = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.GetComponent<EnemyEntity>();
        if (enemy != null && other.gameObject == _currentTarget)
        {
            _targetFound = false;
        }
    }
}
