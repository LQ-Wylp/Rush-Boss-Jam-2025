using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotation : MonoBehaviour
{

    [Header("Rotation Settings")]
    public Transform rotatingObject;
    public Transform movingObject;
    public Transform pivotPoint;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 30f;
    public bool affectePlayer = true;

    [Header("Offset Settings")]
    public Vector3 offset = new Vector3(0, 1, 0);

    void Update()
    {
        rotatingObject.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);

        if(affectePlayer)
        {
            movingObject.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);
        }
        
    }
}
