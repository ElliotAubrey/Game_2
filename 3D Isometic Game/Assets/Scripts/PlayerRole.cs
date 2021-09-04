using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRole : MonoBehaviour
{
    [SerializeField] string role;
    [SerializeField] bool murderer;

    public string GetRole()
    {
        return role;
    }

    public bool GetMurderer()
    {
        return murderer;
    }
}
