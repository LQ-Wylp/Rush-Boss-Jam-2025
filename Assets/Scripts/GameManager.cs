using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("Player Settings")]
    public PlayerMove playerMove;
    public PlayerNote playerNote;
    public Transform playerTransform;

    [Header("Boss Settings")]
    public Transform bossTransform;
    public BossHit bossHit;

    void Awake()
    {
        if(GameManager.gameManager){
            Destroy(this);
        }
        GameManager.gameManager = this;
    }

}
