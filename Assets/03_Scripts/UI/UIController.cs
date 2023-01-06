using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIControllable pauseMenu;
    private List<UIControllable> openControllables = new List<UIControllable>();

    public void OpenMenu(UIControllable menu)
    {
        menu.gameObject.SetActive(true);
        openControllables.Add(menu);
    }

    public void CloseMenu(UIControllable menu)
    {
        menu.gameObject.SetActive(false);
        openControllables.Remove(menu);

        if (openControllables.Count <= 0)
            gameManager.ResumeGame();
    }

    public void OpenPauseMenu()
    {
        OpenMenu(pauseMenu);
    }

    public void ClosePauseMenu()
    {
        CloseMenu(pauseMenu);
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed && openControllables.Count > 0)
        {
            openControllables[openControllables.Count - 1].OnSelect();
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed && openControllables.Count > 0)
        {
            openControllables[openControllables.Count - 1].OnCancel();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && openControllables.Count > 0)
        {
            openControllables[openControllables.Count - 1].OnMove(context.ReadValue<Vector2>());
        }
    }
}
