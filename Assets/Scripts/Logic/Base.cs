using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    public event Action Lose = delegate { }; 

    private int _currentHp;

    public int CurrentHp
    {
        get { return _currentHp; }
        private set
        {
            _currentHp = value;
            if (_currentHp <= 0)
            {
                Lose();
            }
        }
    }

    public void Reset()
    {
        CurrentHp = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyEntity>();
        if (enemy != null)
        {
            CurrentHp -= enemy.GetDamage;
            enemy.DestroySelf();
        }
    }
}
