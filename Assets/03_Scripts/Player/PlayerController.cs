using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Cooldown
{
    public Cooldown(string _name, float _duration)
    {
        name = _name;
        duration = _duration;
    }

    public string name;
    public float duration;
}

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
    [field: SerializeField] public List<Cooldown> Cooldowns { get; set; } = new List<Cooldown>();

    private CharacterController currentForm;
    public CharacterController CurrentForm => currentForm;

    public Checkpoint CurrentCheckpoint { get; private set; } = null;

    private void Awake()
    {
        currentForm = baseForm;
    }

    private void Update()
    {
        UpdateCooldowns();
    }

    public void UpdateCooldowns()
    {
        for (int i = 0; i < Cooldowns.Count; i++)
        {
            Cooldowns[i].duration -= Time.deltaTime;
            if (Cooldowns[i].duration <= 0)
            {
                Cooldowns.RemoveAt(i);
                i--;
            }
        }
    }

    public void SetCheckpoint(Checkpoint _checkpoint)
    {
        if (CurrentCheckpoint == _checkpoint)
        {
            return;
        }

        if (CurrentCheckpoint != null)
        {
            CurrentCheckpoint.Activate(false);
        }

        CurrentCheckpoint = _checkpoint;
        CurrentCheckpoint.Activate();
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
