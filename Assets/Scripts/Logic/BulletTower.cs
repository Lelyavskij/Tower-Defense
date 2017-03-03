using UnityEngine;
using System.Collections;

public class BulletTower : MonoBehaviour 
{

    public float Speed;
    public Transform target;
    public Tower twr;

    private void Update() 
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        }
        if (!target)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == target)
        {
            target.GetComponent<EnemyEntity>().Damage(twr.dmg);
            Destroy(gameObject);
        }
	}
}
