using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Vector2 checkPoint = Vector2.zero;
    [SerializeField] private float checkSize = 1f;

    public CharacterController Controller;
    private int attackCount = 0;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    public void Attack()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 pos = (Vector3)checkPoint;
        if (Controller != null && Controller.MoveDir > 0)
        {
            pos.x *= Controller.InputData.move > 0 ? 1 : -1;
        }
        Gizmos.DrawWireSphere(transform.position + pos, checkSize);
    }
}
