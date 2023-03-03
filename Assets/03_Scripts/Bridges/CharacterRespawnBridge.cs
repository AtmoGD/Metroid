using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawnBridge : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    public void RespawnCharacterBridge()
    {
        characterController.Respawn();
    }
}
