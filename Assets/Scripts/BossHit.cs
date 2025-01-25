using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    private HealthSystem healthSystem;
    public Type sensibility;

    void Start()
    {
        healthSystem = gameObject.GetComponent<HealthSystem>();
    }

    public void hit(Type Type, int dommage)
    {
        if(Type.GetTypeAsString() == sensibility.GetTypeAsString())
        {
            healthSystem.TakeDamage(dommage);
        }
    }
}
