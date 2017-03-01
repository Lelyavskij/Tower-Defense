using UnityEngine;
using System.Collections;

public class TowerPlace : MonoBehaviour {

    public GameObject Tower;

    public bool empty=true;

    public Vector3 offset;

    public GameObject curTower;


    void OnMouseDown()
    {
        if (empty)
        {
            curTower = GameObject.Instantiate(Tower, transform.position + offset, Quaternion.identity) as GameObject;
            empty = false;
        }
    }
    }