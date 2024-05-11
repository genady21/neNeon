using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField] private Transform[] _waypoints;
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
/*
 * using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] waypoints; // массив пустых объектов, через которые камера будет перемещаться
    public Vector3[] lookAtDirections; // массив направлений для камеры

    private int currentWaypointIndex = 0; // индекс текущего пункта назначения

    public float speed = 5f; // скорость перемещения камеры

    private bool isMoving = false; // флаг, указывающий, движется ли в данный момент камера

    private void Update()
    {
        // Проверяем, движется ли камера
        if (isMoving)
        {
            // Перемещаем камеру к текущему пункту назначения
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, step);

            // Проверяем, достигла ли камера текущего пункта назначения
            if (transform.position == waypoints[currentWaypointIndex].position)
            {
                // Устанавливаем направление камеры
                transform.LookAt(waypoints[currentWaypointIndex] + lookAtDirections[currentWaypointIndex]);

                // Переходим к следующему пункту назначения
                currentWaypointIndex++;

                // Если достигнут последний пункт, переходим к первому
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }

                // Останавливаем движение камеры
                isMoving = false;
            }
        }
    }

    // Метод для начала движения камеры к следующей точке
    public void MoveToNextWaypoint()
    {
        // Включаем движение камеры
        isMoving = true;
    }
}
 */