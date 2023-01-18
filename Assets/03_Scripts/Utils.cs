using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector2 GetDirectionClamped(Vector2 _dir, DirectionType _type, float _threshold = 0.5f)
    {
        if (_type == DirectionType.Four)
        {

            if (Mathf.Abs(_dir.x) > Mathf.Abs(_dir.y))
            {
                return _dir.x > 0f ? Vector2.right : Vector2.left;
            }
            else
            {
                return _dir.y > 0f ? Vector2.up : Vector2.down;
            }
        }
        else if (_type == DirectionType.Eight)
        {
            Vector2 dir8 = Vector2.zero;
            dir8.x = Mathf.Abs(_dir.x) > _threshold ? _dir.x > 0f ? 1 : -1 : 0f;
            dir8.y = Mathf.Abs(_dir.y) > _threshold ? _dir.y > 0f ? 1 : -1 : 0f;
            return dir8;
        }
        else if (_type == DirectionType.Vertical)
        {
            float dirY = Mathf.Abs(_dir.y) > _threshold ? _dir.y > 0f ? 1 : -1 : 0f;
            return new Vector2(0f, dirY);
        }
        else if (_type == DirectionType.Horizontal)
        {
            float dirX = Mathf.Abs(_dir.x) > _threshold ? _dir.x > 0f ? 1 : -1 : 0f;
            return new Vector2(dirX, 0f);
        }
        else
        {
            return Vector2.zero;
        }
    }

    public static Direction GetDirectionFrom(Vector2 _dir)
    {
        if (_dir == Vector2.up) return Direction.Up;
        else if (_dir.y == 1 && _dir.x == 1) return Direction.UpRight;
        else if (_dir == Vector2.right) return Direction.Right;
        else if (_dir.y == -1 && _dir.x == 1) return Direction.RightDown;
        else if (_dir == Vector2.down) return Direction.Down;
        else if (_dir.y == -1 && _dir.x == -1) return Direction.DownLeft;
        else if (_dir == Vector2.left) return Direction.Left;
        else if (_dir.y == 1 && _dir.x == -1) return Direction.LeftUp;
        else return Direction.None;
    }
}
