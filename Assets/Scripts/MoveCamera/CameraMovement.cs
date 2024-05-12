using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform lookAtDirections;
    [SerializeField] private float _speed = 5f;
    private int _currentWaypointIndex;
    private bool _isMoving;

    private void Update()
    {
        if (_isMoving)
        {
            var step = _speed * Time.deltaTime;
            transform.position =
                Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, step);

            if (transform.position == _waypoints[_currentWaypointIndex].position)
            {
                _isMoving = false;
                transform.LookAt(lookAtDirections.position);
            }
        }
    }

    public void MoveToNextWaypoint()
    {
        if (_currentWaypointIndex < _waypoints.Length - 1)
        {
            _currentWaypointIndex++;
            _isMoving = true;
        }
        else
        {
            _currentWaypointIndex = 0;
            _isMoving = true;
        }
    }
}