using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class GetMainCameraOnStart : MonoBehaviour
{
    [SerializeField] private bool turnOffAfterGetCamera = true;
    void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        if (turnOffAfterGetCamera)
        {
            gameObject.SetActive(false);
        }
    }
}
