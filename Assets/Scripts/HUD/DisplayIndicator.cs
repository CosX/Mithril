using UnityEngine;

namespace Assets.Scripts.HUD
{
    public class DisplayIndicator : MonoBehaviour {

        public Texture Backdrop;
        public Texture Indicator;
        public Texture Icon;

        public float BackdropWidth = 243f;
        public float BackdropHeight = 46f;

        public float BackdropMarginLeft = -5f;
        public float BackdropMarginTop = -8f;
    
        public float IndicatorWidth = 133f;
        public float IndicatorHeight = 10f;

        public float IndicatorMarginLeft = 40f;
        public float IndicatorMarginTop = 13f;

        public float IconWidth = 6f;
        public float IconHeight = 43f;

        public float IconMarginLeft = 11f;
        public float IconMarginTop = -2f;

        void OnGUI()
        {

            GUI.DrawTexture(new Rect(BackdropMarginLeft, BackdropMarginTop, BackdropWidth, BackdropHeight), Backdrop, ScaleMode.ScaleToFit, true, 0);

            GUI.DrawTexture(new Rect(IndicatorMarginLeft, IndicatorMarginTop, IndicatorWidth, IndicatorHeight), Indicator, ScaleMode.ScaleAndCrop, true, 0);

            GUI.DrawTexture(new Rect(IconMarginLeft, IconMarginTop, IconWidth, IconHeight), Icon, ScaleMode.ScaleToFit, true, 0);
        }

        public void AlterIndicatior(float value)
        {
            IndicatorWidth = IndicatorWidth * (value / 100);
        }
    }
}
