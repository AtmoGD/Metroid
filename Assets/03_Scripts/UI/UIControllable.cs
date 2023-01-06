using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllable : MonoBehaviour
{
    public virtual void OnSelect() { }
    public virtual void OnCancel() { }
    public virtual void OnMove(Vector2 direction) { }
    public virtual void OnUp()
    {
        OnMove(Vector2.up);
    }
    public virtual void OnDown()
    {
        OnMove(Vector2.down);
    }
    public virtual void OnLeft()
    {
        OnMove(Vector2.left);
    }
    public virtual void OnRight()
    {
        OnMove(Vector2.right);
    }
}
