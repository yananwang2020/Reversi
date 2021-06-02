using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum ActionName
{
    GameStartAsCat,
    GameStartAsDog,
    GameStart,
    GamePause,
    GameEnd,
}

public class GlobalEventManager : MonoBehaviour
{
    public static GlobalEventManager Instance;

    Dictionary<ActionName, Action> actions;

    private void Awake()
    {
        Instance = this;
        actions = new Dictionary<ActionName, Action>();
    }

    public void RegisterAction(ActionName actionname, Action action)
    {
        if (actions.ContainsKey(actionname))
        {
            actions[actionname] += action;
        }
        else
        {
            actions[actionname] = action;
        }
        Debug.Log("Register action");
    }

    public void CallAction(ActionName actionname)
    {
        Debug.Log("CallAction");
        actions[actionname]();
    }
}
