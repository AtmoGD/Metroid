using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [field: SerializeField] public List<Transform> ActivateObjects { get; private set; } = new List<Transform>();
    [field: SerializeField] public Transform SpawnPoint { get; private set; } = null;

    public bool IsActivated { get; private set; } = false;
    public SectionController Section { get; private set; } = null;

    private void Awake()
    {
        Section = GetComponentInParent<SectionController>();
    }

    public void Activate(bool activate = true)
    {
        IsActivated = activate;

        foreach (Transform obj in ActivateObjects)
        {
            obj.gameObject.SetActive(activate);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.Player.SetCheckpoint(this);
        }
    }
}
