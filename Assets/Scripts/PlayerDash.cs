using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Player Settings")]
    private PlayerMove playerMove;
    private Transform playerTransform;

    [Header("Dash Settings")]

    private bool isDashing = false;
    private float coefDash = 0;
    [SerializeField] private float range = 1;
    [SerializeField] private float duration = 0.5f;
    private float durationDash = 0;
    [SerializeField] private AnimationCurve dashSpeed;
    private Vector3 initialPos;
    private Vector3 finalPos;

    [Header("Raycast Settings")]
    [SerializeField] private LayerMask wallLayer;

    void Start()
    {
        playerMove = GameManager.gameManager.playerMove;
        playerTransform = GameManager.gameManager.playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing){
            coefDash += Time.deltaTime / durationDash;
            if(coefDash >= 1){
                coefDash = 1;
                isDashing = false;
                playerMove.ActifPhysics();
            }

            transform.position = Vector3.Lerp(initialPos, finalPos, dashSpeed.Evaluate(coefDash));

        }
    }

    void OnDash()
    {
        if(!isDashing)
        {
            Vector3 directionDash = new Vector3(playerMove.GetDirectionInput().x , 0 , playerMove.GetDirectionInput().y);

            if(directionDash != Vector3.zero)
            {
                initialPos = playerTransform.position;
                directionDash = directionDash.normalized;

                RaycastHit hit;
                if (Physics.Raycast(initialPos, directionDash, out hit, range, wallLayer))
                {
                    finalPos = hit.point;
                    durationDash = duration * (Vector3.Distance(initialPos,finalPos) / Vector3.Distance(initialPos, (initialPos + (directionDash * range))));
                    Debug.Log(durationDash);
                }
                else
                {
                    finalPos = initialPos + (directionDash * range);
                    durationDash = duration;
                }

                playerMove.StopPhysics();
                coefDash = 0;
                isDashing = true;
            }
        }
    }
}
