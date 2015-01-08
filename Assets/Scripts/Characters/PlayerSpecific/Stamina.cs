using Assets.Scripts.HUD;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class Stamina : MonoBehaviour {
        public float PlayerStamina = 100f;
        private float _initalStamina;
        private float _initalIndicatorWidth;
        private const float RegenerateValue = 0.05f;
        private float _diff;
        private GameObject _staminaObject;
        private DisplayIndicator _staminaIndicator;

        void Start()
        {
            _initalStamina = PlayerStamina;
            _staminaObject = GameObject.Find("GUI/Stamina");
            _staminaIndicator = _staminaObject.GetComponent<DisplayIndicator>();
            _initalIndicatorWidth = _staminaIndicator.IndicatorWidth;
            _diff = _initalIndicatorWidth / _initalStamina;
        }

        void Update()
        {
            if (PlayerStamina < _initalStamina)
            {
                PlayerStamina += RegenerateValue;
                _staminaIndicator.IndicatorWidth += RegenerateValue * _diff;
            }
        }

        public void DrainStamina(float value)
        {
            if (PlayerStamina - value <= 0)
            {
                PlayerStamina = 0;
                _staminaIndicator.IndicatorWidth = 0;
            }
            else
            {
                PlayerStamina -= value;
                _staminaIndicator.IndicatorWidth -= value * _diff;
            }
           
        }
    }
}
