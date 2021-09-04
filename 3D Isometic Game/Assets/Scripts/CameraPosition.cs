using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] GameObject focus;

    Vector3 offset;

    private void Start()
    {
        offset = Camera.main.transform.position - focus.transform.position;
    }

    public void RepositionCamera(GameObject newFocus)
    {
        Camera.main.transform.position = newFocus.transform.position + offset;
        focus = newFocus;
    }
}
