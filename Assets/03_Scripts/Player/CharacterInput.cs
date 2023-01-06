using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterInput
{
    [SerializeField] public Vector2 move = Vector2.zero;
    [SerializeField] public bool jump = false;
    [SerializeField] public bool attack = false;
    [SerializeField] public bool getHit = false;
    [SerializeField] public List<Damage> damage = new List<Damage>();
    [SerializeField] public bool dash = false;

    public void SetMove(Vector2 _move)
    {
        move = _move;
    }

    public void SetJump(bool _jump)
    {
        jump = _jump;
    }

    public void SetAttack(bool _attack)
    {
        attack = _attack;
    }

    public void SetGetHit(bool _getHit)
    {
        getHit = _getHit;
    }

    public void AddGetHit(Damage _damage)
    {
        damage.Add(_damage);
    }

    public void SetDash(bool _dash)
    {
        dash = _dash;
    }
}