using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterInput
{
    [SerializeField] public float move = 0f;
    [SerializeField] public bool jump = false;

    public void SetMove(float _move)
    {
        move = _move;
    }

    public void SetJump(bool _jump)
    {
        jump = _jump;
    }
}