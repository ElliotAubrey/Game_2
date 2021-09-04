using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseable
{
    public string GetContext();
    public float GetProgress();
    public bool CheckUseable();
}
