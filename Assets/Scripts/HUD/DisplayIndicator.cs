using UnityEngine;
using System.Collections;

public class DisplayIndicator : MonoBehaviour {

    public Texture backdrop;
    public Texture indicator;
    public Texture icon;

    public int backdropWidth = 243;
    public int backdropHeight = 46;

    public int backdropMarginLeft = -5;
    public int backdropMarginTop = -8;
    
    public int indicatorWidth = 133;
    public int indicatorHeight = 10;

    public int indicatorMarginLeft = 40;
    public int indicatorMarginTop = 13;

    public int iconWidth = 6;
    public int iconHeight = 43;

    public int iconMarginLeft = 11;
    public int iconMarginTop = -2;

    void OnGUI()
    {

        GUI.DrawTexture(new Rect(backdropMarginLeft, backdropMarginTop, backdropWidth, backdropHeight), backdrop, ScaleMode.ScaleToFit, true, 0);

        GUI.DrawTexture(new Rect(indicatorMarginLeft, indicatorMarginTop, indicatorWidth, indicatorHeight), indicator, ScaleMode.ScaleAndCrop, true, 0);

        GUI.DrawTexture(new Rect(iconMarginLeft, iconMarginTop, iconWidth, iconHeight), icon, ScaleMode.ScaleToFit, true, 0);
    }
}
