using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITaskItem
{
    void Progress();

    void NewTask(Task newTask);
}
