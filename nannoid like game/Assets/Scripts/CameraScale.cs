using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale
{
    //camera sizes
    private float halfHeight;
    private float halfWidth;
    //

    public CameraScale(Camera game_OrthographicCamera)
    {
        halfHeight = game_OrthographicCamera.orthographicSize;
        halfWidth = game_OrthographicCamera.aspect * halfHeight;
    }

    public float getHalfHeight()
    {
        return halfHeight;
    }

    public float getHalfWidth()
    {
        return halfWidth;
    }
}
