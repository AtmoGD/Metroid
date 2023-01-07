using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjectOnAwake : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
