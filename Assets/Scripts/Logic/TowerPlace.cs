using UnityEngine;
using System.Collections;

public class TowerPlace : MonoBehaviour 
{

    [SerializeField]
    private Tower _canonTowerPrefab;
    [SerializeField]
    private Tower _laserTowerPrefab;

    public Vector3 offset;

    private Tower _curTower;

    private void OnMouseDown()
    {
        if (_curTower == null)
        {
            var rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                _curTower = Instantiate(_canonTowerPrefab, transform.position + offset, Quaternion.identity) as Tower;
            }
            else
            {
                _curTower = Instantiate(_laserTowerPrefab, transform.position + offset, Quaternion.identity) as Tower;
            }
        }
    }
}