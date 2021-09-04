using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Door point;
    [SerializeField] GameObject cameraFocus;

    Collider player;

    private void Update()
    {
        if(player != null && Input.GetKeyDown(KeyCode.F))
        {
            Camera.main.GetComponentInParent<CameraPosition>().RepositionCamera(cameraFocus);
            player.gameObject.transform.position = point.transform.position + Vector3.down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }
}
