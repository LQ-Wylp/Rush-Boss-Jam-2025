using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private Vector2 velocity = new Vector2(0, 0);
    public float speed = 1;
    [Range(0, 1)]
    [SerializeField] private float coefFriction = 0.8f;

    [Header("Player Inputs")]
    private Vector2 moveInput = new Vector2(0, 0);

    [Header("Physic Settings")]
    private CharacterController characterController;
    private bool calculPhysic = true;
    

    private int wallLayer;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(calculPhysic)
        {
            velocity += moveInput * speed * Time.deltaTime;
            velocity *= coefFriction;

            if (velocity.magnitude < 0.001f)
            {
                velocity = Vector2.zero;
            }

            characterController.Move(new Vector3(velocity.x , 0 , velocity.y));
        }
       
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void AddVelocity(Vector2 valueAdded)
    {
        velocity += valueAdded;
    }

    public Vector2 GetDirectionInput(){
        return moveInput;
    }

    public void StopPhysics(){
        calculPhysic = false;
        velocity = Vector2.zero;
    }

    public void ActifPhysics(){
        velocity = Vector2.zero;
        calculPhysic = true;
    }

}
