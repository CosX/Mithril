using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class PlayerControls : MonoBehaviour {

        public GameObject InventoryGameObject;

        void Update () {
            //InventoryToggle
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryGameObject.SetActive(!InventoryGameObject.activeSelf);
            }
        }
    }
}
