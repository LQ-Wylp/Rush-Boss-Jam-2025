using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour
{
    public enum ElementType
    {
        Glace,
        Eau,
        Feu
    }

    [Header("Type de l'élément")]
    public ElementType currentType;

    public void SetType(ElementType newType)
    {
        currentType = newType;
        Debug.Log($"Type changé en : {currentType}");
    }

    public string GetTypeAsString()
    {
        return currentType.ToString();
    }
}
