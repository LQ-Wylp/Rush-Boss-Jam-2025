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
    [SerializeField] private float coefDash = 0;
    [SerializeField] private float range = 1;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private AnimationCurve dashSpeed;
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 finalPos;

    void Start()
    {
        playerMove = GameManager.gameManager.playerMove;
        playerTransform = GameManager.gameManager.playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing){
            coefDash += Time.deltaTime / duration;
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
            initialPos = playerTransform.position;

            Vector3 directionDash = new Vector3(playerMove.GetDirectionInput().x , 0 , playerMove.GetDirectionInput().y);
            directionDash = directionDash.normalized;

            finalPos = initialPos + (directionDash * range);

            playerMove.StopPhysics();
            coefDash = 0;
            isDashing = true;
        }
    }
}
