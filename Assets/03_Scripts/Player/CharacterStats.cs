using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DirectionType
{
    Vertical,
    Horizontal,
    Four,
    Eight
}

public enum Direction
{
    Up,
    UpRight,
    Right,
    RightDown,
    Down,
    DownLeft,
    Left,
    LeftUp,
    None
}

[Serializable]
public class CharacterStats
{
    public AnimationCurve accelerationCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve decelerationCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve jumpCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float jumpTime = 0.2f;
    public float jumpHeight = 1f;
    public int maxJumps = 3;
    public AnimationCurve wallJumpHorizontalCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float wallJumpHorizontalSpeed = 2f;
    public AnimationCurve fallCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public bool canMoveWhileJumping = true;
    public bool canMoveWhileFalling = true;
    public float attackTime = 0.2f;
    public AnimationCurve attackXCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve attackYCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve dashCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float immuneTime = 1.5f;
    public float getHitTime = 0.2f;
    public float dashTime = 0.2f;
    public float dashSpeed = 1f;
    public int maxDashes = 2;
    public bool continiousDashing = true;
    public DirectionType directionType = DirectionType.Four;
    public float dirThreshold = 0.25f;
    public float chargeSpeed = 1f;
    public float chargeScaleMin = 0.2f;
    public float chargeScaleMax = 1f;
    public float chargeTime = 1f;
}