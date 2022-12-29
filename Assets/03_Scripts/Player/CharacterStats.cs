using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterStats
{
    public AnimationCurve accelerationCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve decelerationCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve jumpCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float jumpTime = 0.2f;
    public float jumpHeight = 1f;
    public int maxJumps = 3;
    public AnimationCurve fallCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float attackTime = 0.2f;
    public AnimationCurve attackXCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve attackYCurve = AnimationCurve.Linear(0, 0, 1, 1);
}