using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float rotationSpeed = 1f;

    // Update est appelé à chaque frame
    void Update()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationAxis, rotationStep, Space.Self);
    }
}
