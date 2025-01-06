using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotation : MonoBehaviour
{

    [Header("Rotation Settings")]
    [SerializeField] private bool turnRight = true;
    [SerializeField] private float speedRotation = 1;
    [SerializeField] private Transform axeRotation;

    [Header("Move Settings")]
    private PlayerMove playerMove;
    [SerializeField] private bool affectPlayer = true;
    
    void Start(){
        playerMove = GameManager.gameManager.playerMove;
    }
    
    void Update()
    {
        if(affectPlayer)
        {
            playerMove.AddVelocity(AddOrbitVelocity(playerMove.transform));
        }
    }

    public Vector2 AddOrbitVelocity(Transform ObjectTransform)
    {
        Vector3 directionToCenter = axeRotation.position - ObjectTransform.position;
        directionToCenter.y = 0;
        Vector3 tangent = Vector3.Cross(directionToCenter.normalized, Vector3.up); 
        Vector3 orbitVelocity = tangent * speedRotation * Time.deltaTime;
        if(!turnRight){
            return new Vector2(orbitVelocity.x, orbitVelocity.z) * -1;
        }
        return new Vector2(orbitVelocity.x, orbitVelocity.z);
    }
}
