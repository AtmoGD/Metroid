using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
    [SerializeField] private List<SectionController> connectedSections = new List<SectionController>();

    bool active = false;

    private CharacterController characterController;

    public void Deactivate()
    {
        if (!active)
            return;

        active = false;

        virtualCamera.gameObject.SetActive(false);
    }

    public void OnPlayerEnter(CharacterController characterController)
    {
        if (active)
            return;

        active = true;

        virtualCamera.gameObject.SetActive(true);

        gameManager.SetCurrentSection(this);

        virtualCamera.gameObject.SetActive(true);

        virtualCamera.Follow = characterController.transform;
        virtualCamera.LookAt = characterController.transform;
    }

    public void ActivateNeighbourSections(bool activate, SectionController excludeSection = null)
    {
        foreach (SectionController section in connectedSections)
        {
            if (section != excludeSection)
            {
                section.gameObject.SetActive(activate);
            }
        }
    }
}
