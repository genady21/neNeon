using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField] private Transform[] _waypoints;
   public Transform lookAtDirections;
   private int _currentWaypointIndex = 0;
   [SerializeField] private float _speed = 5f;
   private bool _isMoving = false;

   private  void Update()
   {
      if (_isMoving)
      {
         float step = _speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, step);
         
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
