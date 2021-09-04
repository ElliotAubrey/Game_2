using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooker : MonoBehaviour, IUseable, ITaskItem
{
    [SerializeField] string context = "Cooker";
    [SerializeField] float progress = 0f;
    [SerializeField] bool useable = false;
    [SerializeField] Task currentTask;
    [SerializeField] float progressPercentPerSecond;
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Outline outline;

    bool progressTask = false;
    bool complete = false;

    void Start()
    {
        progressBar.gameObject.SetActive(false);
        progressPercentPerSecond /= 50;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerRole>().GetRole() == currentTask.GetRequiredRole())
        {
            Debug.Log("Correct Role");
            progressTask = true;
            if(!complete)
            {
                outline.enabled = true;
            }
        }
        else
        {
            Debug.Log("Incorrect Role");
            progressTask = false;
            outline.enabled = false;
        }
    }

    void OnTriggerExit()
    {
        progressTask = false;
        progressBar.gameObject.SetActive(false);
        outline.enabled = false;
    }

    void FixedUpdate()
    {
        Debug.Log("progressTask : " + progressTask);
        Debug.Log("F down : " + Input.GetKey(KeyCode.F));
        Debug.Log("Task incomplete : " + !complete);

        if (progressTask && Input.GetKey(KeyCode.F) && !complete)
        {
            Progress();
            progressBar.gameObject.SetActive(true);
        }

        if(progressTask && !Input.GetKey(KeyCode.F) && !complete)
        {
            progressBar.gameObject.SetActive(false);
        }

        if(complete && progressBar.IsActive())
        {
            progressBar.gameObject.SetActive(false);
            outline.enabled = false;
        }
    }

    //Interface Methods
    //IUseable

    public string GetContext()
    {
        return context;
    }

    public float GetProgress()
    {
        return progress;
    }

    public bool CheckUseable()
    {
        return useable;
    }

    //ITaskItem

    public void Progress()
    {
        description.text = currentTask.description;
        progress += progressPercentPerSecond;
        progressBar.value = progress;
        if(progress >= 100)
        {
            progressBar.gameObject.SetActive(false);
            complete = true;
            outline.enabled = false;
        }
    }

    public void NewTask(Task newTask)
    {
        currentTask = newTask;
        if(!complete)
        {
           //REPRECUSSION CODE HERE
        }
        complete = false;
        progress = 0f;
    }

}
