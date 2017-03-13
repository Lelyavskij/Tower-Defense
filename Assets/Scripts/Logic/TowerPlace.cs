using UnityEngine;
using System.Collections;

public class TowerPlace : MonoBehaviour 
{

    public GameObject Tower;
    public Vector3 offset;

    private GameObject _curTower;

    private void OnMouseDown()
    {
        if (_curTower == null)
        {
            _curTower = Instantiate(Tower, transform.position + offset, Quaternion.identity) as GameObject;
        }
    }
}