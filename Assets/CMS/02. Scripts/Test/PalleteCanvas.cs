using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
using CW.Common;
using PaintCore;
public class PalleteCanvas : MonoBehaviour
{
    public CwPaintSphere pen;

    
    int penStatus = 0;
    public void SetNormalPen()
    {
        penStatus = 0;
        pen.BlendMode = CwBlendMode.AlphaBlend(new Vector4(1, 1, 1, 1));
        pen.Color = new Color(0, 0, 0, 1);
    }
    public void SetOpacityPen()
    {
        penStatus = 1;
        pen.BlendMode = CwBlendMode.AlphaBlend(new Vector4(1, 1, 1, 1));
        pen.Color = new Color(0, 0, 0, 0.2f);
    }
    public void SetErase()
    {
        pen.BlendMode = CwBlendMode.ReplaceOriginal(new Vector4(1,1,1,1));
        pen.Color = new Color(0, 0, 0, 0);
    }
    public void SetRed()
    {
        if(penStatus == 0) pen.Color = Color.red;
        else if(penStatus == 1)
        {
            pen.Color = new Color(1, 0, 0, 0.2f);
        }
    }
    public void SetBlue()
    {
        if (penStatus == 0) pen.Color = Color.blue;
        else if (penStatus == 1)
        {
            pen.Color = new Color(0, 0, 1, 0.2f);
        }
    }
    public void SetYellow()
    {
        if (penStatus == 0) pen.Color = Color.yellow;
        else if (penStatus == 1)
        {
            pen.Color = new Color(1, 1, 0, 0.2f);
        }
    }
    public void SetPink()
    {
        if (penStatus == 0) pen.Color = new Color(1,0,1);
        else if (penStatus == 1)
        {
            pen.Color = new Color(1, 0, 1, 0.2f);
        }
    }
    public void SetWhite()
    {
        if (penStatus == 0) pen.Color = Color.white;
        else if (penStatus == 1)
        {
            pen.Color = new Color(1, 1, 1, 0.2f);
        }
    }
    public void SetBlack()
    {
        if (penStatus == 0) pen.Color = Color.black;
        else if (penStatus == 1)
        {
            pen.Color = new Color(0, 0, 0, 0.2f);
        }
    }

}
