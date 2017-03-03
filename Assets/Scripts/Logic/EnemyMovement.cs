using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform[] _waypoints;

    private int _currentWaypointIndex;

    public void SetPath(Transform[] path)
    {
        _waypoints = path;
    }

	private void Update ()
    {
        if (_currentWaypointIndex < _waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, Time.deltaTime * _speed);
            transform.LookAt(_waypoints[_currentWaypointIndex].position);
            if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < 0.5f)
            {
                _currentWaypointIndex++;
            }
        }
	}
}
