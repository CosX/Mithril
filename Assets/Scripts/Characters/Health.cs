using Assets.Scripts.HUD;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class Health : MonoBehaviour {
        public float health = 100f;
        private float _diff;
        private bool _dead;

        private GameObject _healthObject;
        private DisplayIndicator _healthIndicator;

        void Start(){
            _healthObject = GameObject.Find("GUI/Health");
            _healthIndicator = _healthObject.GetComponent<DisplayIndicator>();
            _diff = _healthIndicator.IndicatorWidth/health;
        }

        void Update ()
        {
            if (health <= 0f) {
                if (!_dead)
                    PlayerDying();
                Debug.Log ("Died!");
            }else{
                PlayerDead();
                LevelReset();
            }
        }

        void PlayerDying ()
        {
            _dead = true;
		
            //Her må vi animere noe + lage en lyd
        }

        void PlayerDead(){
            //
        }

        void LevelReset(){

	
        }

        public void TakeDamage (float amount)
        {
            health -= amount;
            _healthIndicator.IndicatorWidth -= amount * _diff;
        }
    }
}
