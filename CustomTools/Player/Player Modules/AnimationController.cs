using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        private Move _move;
        private Animator _anim;
        private CharacterController _cc;

        private void Start()
        {
            _move = GetComponent<Move>();
            _anim = GetComponent<Animator>();
            _cc = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            //_anim.SetFloat("movement", _move.direction.magnitude);
            _anim.SetBool("isGrounded", _cc.isGrounded);
            _anim.SetBool("isJumping", Input.GetButtonDown("Jump"));
        }
    }
}
