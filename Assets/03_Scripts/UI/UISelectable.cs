using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UISelectable : MonoBehaviour
{
    protected UIMenu menu;
    protected Button button;

    public UISelectable up;
    public UISelectable down;
    public UISelectable left;
    public UISelectable right;

    private void Start()
    {
        menu = GetComponentInParent<UIMenu>();
        button = GetComponent<Button>();
    }

    public virtual void OnSelect()
    {
        button.onClick.Invoke();
    }

    public virtual void OnHover()
    {
        button.Select();
    }

    public virtual void OnUnHover()
    {
        button.OnDeselect(null);
    }
}
