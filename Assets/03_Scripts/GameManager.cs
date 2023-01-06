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
    public GameState gameState = GameState.Playing;

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (gameState)
            {
                case GameState.Playing:
                    Time.timeScale = 0f;
                    gameState = GameState.Paused;
                    break;
                case GameState.Paused:
                    Time.timeScale = 1f;
                    gameState = GameState.Playing;
                    break;
            }
        }
    }

    public void OnReloadLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnQuitGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Application.Quit();
        }
    }


}
