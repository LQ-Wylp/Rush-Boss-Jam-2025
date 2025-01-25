using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBulletDommageable : MonoBehaviour
{
    public Type type;
    public int dommage;
    public void Hit()
    {
        GameManager.gameManager.bossHit.hit(type, dommage);
    }
}
