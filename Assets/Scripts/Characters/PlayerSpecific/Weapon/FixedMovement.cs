﻿using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific.Weapon
{
    public class FixedMovement : MonoBehaviour {

        public Vector2 Speed = new Vector2(10, 10);

        public Vector2 Direction = new Vector2(-1, 0);

        private Vector2 _movement;

        void Update()
        {
            _movement = new Vector2(
              Speed.x * Direction.x,
              Speed.y * Direction.y);
        }

        void FixedUpdate()
        {
            GetComponent<Rigidbody2D>().velocity = _movement;
        }
    }
}
