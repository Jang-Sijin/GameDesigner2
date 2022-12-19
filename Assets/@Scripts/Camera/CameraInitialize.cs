using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialize : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        CameraResolution();
    }

    public void CameraResolution()
    {
        Camera camera = GetComponent<Camera>();
        
        Rect rect = camera.rect;
        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9); // (가로 / 세로)
        float scaleWidth = 1f / scaleHeight;

        if (scaleHeight < 1)
        {
            rect.height = scaleHeight;
            rect.y = (1f - scaleHeight) / 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }
        camera.rect = rect;
    }
}
