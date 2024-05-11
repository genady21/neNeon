using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]private CameraMovement _CameraMovement;

    public void MoveToNextWaypoint()
    {
        _CameraMovement.MoveToNextWaypoint();
    }
}
