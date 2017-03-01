using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour {

    public Tower twr;

    public bool lockE;

    public GameObject curTargget;


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemyBug") && !lockE)
        {
            twr.target = other.gameObject.transform;
            curTargget = other.gameObject;
            lockE = true;
        }

    }
    void Update()
    {
        if (!curTargget)
        {
            lockE = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("enemyBug")&& other.gameObject == curTargget)
        {
            lockE = false;
        }
    }
}
