using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

     [Header("Collision Settings")]
    public LayerMask collisionLayer; // Les couches à considérer pour les collisions
    public float collisionRadius = 0.5f; // Rayon de détection des collisions

    void Update()
    {
        quaternion initialRotatePlayer = movingObject.transform.rotation;
        
        rotatingObject.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);

        if(affectePlayer)
        {
            Vector3 previousPosition = movingObject.position;
            Quaternion previousQuarternion = movingObject.rotation;
            movingObject.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);
            Vector3 newPosition = movingObject.position;
            if (!Physics.CheckSphere(newPosition, collisionRadius, collisionLayer))
            {
                movingObject.position = newPosition;
            }
            else
            {
                movingObject.position = previousPosition;
                movingObject.rotation = previousQuarternion;
            } 
        }

        movingObject.transform.rotation = initialRotatePlayer;
    }
}
