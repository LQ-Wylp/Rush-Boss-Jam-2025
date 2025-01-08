using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterController : MonoBehaviour
{
    // Variables pour le mouvement
    public float moveSpeed = 5f;          // Vitesse de d�placement

    // R�f�rences
    private CharacterController controller; // Composant CharacterController

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // D�placement horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Appliquer le mouvement
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}