using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roleUI;

    private void Start()
    {
        PlayerRole myRole = GetComponent<PlayerRole>();
        roleUI.text = myRole.GetRole();

        if(myRole.GetMurderer())
        {
            roleUI.color = Color.red;
        }
        else
        {
            roleUI.color = Color.green;
        }
    }
}
