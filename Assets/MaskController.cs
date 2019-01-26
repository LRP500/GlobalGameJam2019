﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class MaskController : MonoBehaviour
    {

        public float _repulsion = 6f;
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.enableRepulsion();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
