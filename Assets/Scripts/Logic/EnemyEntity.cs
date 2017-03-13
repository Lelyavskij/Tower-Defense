using System;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public event Action<int> HpChanged = delegate { };
    public event Action<EnemyEntity> Destroyed = delegate { };

    [SerializeField] 
    private int _baseHp;
    [SerializeField]
    private int _damage;

    private int _currentHp;

    public int CurrentHp
    {
        get { return _currentHp; }
        set
        {
            _currentHp = value;
            HpChanged(_currentHp);
            if (_currentHp <= 0)
            {
                DestroySelf();
            }
        }
    }

    public int GetDamage
    {
        get { return _damage; }
    }

    public void Damage(int damage)
    {
        CurrentHp -= damage;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        Destroyed(this);
    }

    private void Start()
    {
        CurrentHp = _baseHp;
    }

}
