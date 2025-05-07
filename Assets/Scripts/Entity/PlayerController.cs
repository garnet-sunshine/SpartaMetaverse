using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : BaseController
{
    public float speed = 5f;
    private Camera camera; // ���콺 ��ġ ���� ��ǥ ��ȯ�� ���� ī�޶� ����

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // �¿�
        float vertical = Input.GetAxisRaw("Vertical"); // ����
        movementDirection = new Vector2(horizontal, vertical).normalized; // �밢�� �̵� ����

        // ���콺 ��ġ ���� ��ǥ�� ��ȯ
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        // ���콺 ��ġ������ ���� ���
        if (lookDirection.magnitude <0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else 
        { 
            lookDirection = lookDirection.normalized;
        }
    }
}
