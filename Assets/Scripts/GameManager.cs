using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("Player Settings")]
    public PlayerMove playerMove;
    public Transform playerTransform;

    void Awake()
    {
        if(GameManager.gameManager){
            Destroy(this);
        }
        GameManager.gameManager = this;
    }

}
