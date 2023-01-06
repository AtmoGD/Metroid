using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    [SerializeField] private GameObject hearthContainer;
    [SerializeField] private GameObject hearthPrefab;

    private List<GameObject> hearths = new List<GameObject>();

    private void Start()
    {
        CreateHearts();
    }

    private void Update()
    {
        UpdateHearts();
    }

    public void CreateHearts()
    {
        for (int i = 0; i < healthController.MaxHealth; i++)
        {
            GameObject hearth = Instantiate(hearthPrefab, hearthContainer.transform);
            hearths.Add(hearth);
        }
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearths.Count; i++)
        {
            if (i < healthController.CurrentHealth)
            {
                hearths[i].SetActive(true);
            }
            else
            {
                hearths[i].SetActive(false);
            }
        }
    }
}
