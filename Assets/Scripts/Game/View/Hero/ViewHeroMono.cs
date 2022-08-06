using System;
using UnityEngine;

namespace Game.View.Hero
{
    public class ViewHeroMono:MonoBehaviour
    {
        public Rigidbody2D RB2D;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public GameObject hpPart;
        public GameObject collidePart;

        // private Rigidbody2D _rigidbody2D;
        // private void Awake()
        // {
        //     _rigidbody2D = GetComponent<Rigidbody2D>();
        // }
        //
        // private void FixedUpdate()
        // {
        //     _rigidbody2D.velocity = Vector2.zero;
        // }
    }
}