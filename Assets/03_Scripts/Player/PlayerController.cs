using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerController : MonoBehaviour
{
    public Action<CharacterController> OnChangeForm;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private CharacterController baseForm;
    [SerializeField] private CharacterController fireForm;
    [SerializeField] private CharacterController iceForm;
    [SerializeField] private CharacterController natureForm;
    [SerializeField] private CharacterController airForm;
    [field: SerializeField] public int MaxLifes { get; private set; } = 3;
    [field: SerializeField] public int CurrentLifes { get; private set; } = 3;

    private CharacterController currentForm;

    private void Start()
    {
        currentForm = baseForm;
    }

    public void ChangeForm(CharacterForm form)
    {
        Vector2 position = currentForm.transform.position;

        currentForm.gameObject.SetActive(false);

        switch (form)
        {
            case CharacterForm.Base:
                currentForm = baseForm;
                break;
            case CharacterForm.Fire:
                currentForm = fireForm;
                break;
            case CharacterForm.Ice:
                currentForm = iceForm;
                break;
            case CharacterForm.Nature:
                currentForm = natureForm;
                break;
            case CharacterForm.Air:
                currentForm = airForm;
                break;
        }

        cam.Follow = currentForm.transform;
        cam.LookAt = currentForm.transform;

        currentForm.transform.position = position;

        currentForm.gameObject.SetActive(true);

        OnChangeForm?.Invoke(currentForm);
    }

    public void RemoveLife(int _amount = 1)
    {
        CurrentLifes -= _amount;

        if (CurrentLifes <= 0)
        {
            // Respawn
            ChangeForm(CharacterForm.Base);
            CurrentLifes = MaxLifes;
            currentForm.OnRespawn();
        }
    }
}
