using System;
using UnityEngine;
using static Define;

public class BaseScene : MonoBehaviour
{
    public SceneType SceneType = SceneType.Unknown;
    protected bool _init = false;
    
    private const int _framerate = 120;

    public void Awake()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;

        SetFrameRate();
        
        Managers.Init();

        return true;
    }
    
    public virtual void Clear()  
    {

    }
    
    
    public void SetFrameRate()
    {
        Application.targetFrameRate = _framerate;
    }
}
