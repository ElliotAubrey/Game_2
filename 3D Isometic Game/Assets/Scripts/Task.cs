using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tasks", menuName = "ScriptableObjects/Tasks", order = 1)]
public class Task : ScriptableObject
{
    [SerializeField] string requiredRole;
    public string description;

    public string GetRequiredRole()
    {
        return requiredRole;
    }
}
