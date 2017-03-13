using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour 
{

    public Transform shootElement;

    public Transform LookAtObject;

    public int Damage = 10;

    [SerializeField]
    private float _shootDelay;
    [SerializeField]
    private GameObject _bulletPrefab;

    public Transform target;

    private bool IsShoot;
	
	private void Update () 
    {
        if (target)
        {
            LookAtObject.transform.LookAt(target);
            if (!IsShoot)
            {
                StartCoroutine(shoot());
            }
        }
	}

    private IEnumerator shoot()
    {
        IsShoot = true;
        yield return new WaitForSeconds(_shootDelay);
        var bullet = Instantiate(_bulletPrefab, shootElement.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<BulletTower>().target = target;
         bullet.GetComponent<BulletTower>().twr = this;
        IsShoot = false;

    }
}
