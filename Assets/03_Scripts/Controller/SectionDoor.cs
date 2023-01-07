using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDoor : MonoBehaviour
{
    [SerializeField] private SectionController sectionController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController characterController = other.GetComponent<CharacterController>();
        if (characterController)
        {
            sectionController.OnPlayerEnter(characterController);
        }
    }
}
