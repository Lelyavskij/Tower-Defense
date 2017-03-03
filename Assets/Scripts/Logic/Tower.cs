using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    public Transform shootElement;

    public Transform LookAtObject;

    public int dmg = 10;
    
    public GameObject bullet;

    public Transform target;

    public float shootDelay;

    bool IsShoot;

	void Start () {

	
	}
	
	
	void Update () {
        if (target)
        {
            LookAtObject.transform.LookAt(target);
            if (!IsShoot)
            {
                StartCoroutine(shoot());
            }

        }
       
	
	}
    IEnumerator shoot()
    {
        IsShoot = true;
        yield return new WaitForSeconds(shootDelay);
        GameObject b = GameObject.Instantiate(bullet, shootElement.position,Quaternion.identity) as GameObject;
        b.GetComponent<BulletTower>().target = target;
         b.GetComponent<BulletTower>().twr = this;
        IsShoot = false;

    }
}
