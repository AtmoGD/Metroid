using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum GameState
{
    Playing,
    Paused,
    GameOver
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInput characterInput;
    [SerializeField] private UIController uiController;
    [SerializeField] private PlayerInput uiInput;

    public GameState gameState = GameState.Playing;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        uiInput.DeactivateInput();
        characterInput.ActivateInput();
    }

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        if (context.performed && gameState == GameState.Playing)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameState = GameState.Paused;
        uiController.OpenPauseMenu();
        characterInput.DeactivateInput();
        uiInput.ActivateInput();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        gameState = GameState.Playing;
        characterInput.ActivateInput();
        uiInput.DeactivateInput();
    }

    public void OnReloadLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ReloadLevel();
        }
    }

    public void ReloadLevel()
    {
        print("Reloading level");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Application.Quit();
        }
    }


}
