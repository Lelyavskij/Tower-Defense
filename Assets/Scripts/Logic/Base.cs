using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour 
{
    private int _currentHp = 100;

    public int CurrentHp { get { return _currentHp; } }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyEntity>();
        if (enemy != null)
        {
            _currentHp -= 10;
            enemy.DestroySelf();
        }
    }
}
