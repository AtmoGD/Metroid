using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterSettings
{
    [SerializeField] public float idleToMoveThreshold = 0.2f;
    [SerializeField] public float moveToIdleThreshold = 0.2f;
    [SerializeField] public float verticalLerpSpeed = 0.2f;
    [SerializeField] public float horizontalLerpSpeed = 0.2f;
    [SerializeField] public float groundCheckRadius = 0.2f;
    [SerializeField] public float minimumJumpTime = 0.2f;
    [SerializeField] public Vector2 groundCheckSize = Vector2.one;
    [SerializeField] public Vector2 wallCheckSize = Vector2.one;
    [SerializeField] public float groundTimeThreshold = 0.2f;
    [SerializeField] public LayerMask groundMask = 0;
    [SerializeField] public LayerMask wallMask = 0;
}
