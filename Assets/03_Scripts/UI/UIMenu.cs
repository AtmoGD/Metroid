using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : UIControllable
{
    [SerializeField] private UIController uiController;

    [SerializeField] UISelectable currentSelection;

    private void Start()
    {
        currentSelection?.OnHover();
    }

    public override void OnMove(Vector2 direction)
    {
        if (direction == Vector2.up && currentSelection.up)
        {
            ChangeSelection(currentSelection.up);
        }
        else if (direction == Vector2.down && currentSelection.down)
        {
            ChangeSelection(currentSelection.down);
        }
        else if (direction == Vector2.left && currentSelection.left)
        {
            ChangeSelection(currentSelection.left);
        }
        else if (direction == Vector2.right && currentSelection.right)
        {
            ChangeSelection(currentSelection.right);
        }
    }

    public void ChangeSelection(UISelectable newSelection)
    {
        currentSelection.OnUnHover();
        currentSelection = newSelection;
        currentSelection.OnHover();
    }

    public override void OnSelect()
    {
        currentSelection?.OnSelect();
    }

    public override void OnCancel()
    {
        uiController.ClosePauseMenu();
    }
}
