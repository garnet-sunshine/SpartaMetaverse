using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : BaseController
{
    public float speed = 5f;
    private Camera maincamera; // 마우스 위치 월드 좌표 변환을 위해 카메라 참조

    protected override void Start()
    {
        base.Start();
        maincamera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // 좌우
        float vertical = Input.GetAxisRaw("Vertical"); // 상하
        movementDirection = new Vector2(horizontal, vertical).normalized; // 대각선 이동 보정

        // 마우스 위치 월드 좌표로 변환
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = maincamera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        // 마우스 위치까지의 방향 계산
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
