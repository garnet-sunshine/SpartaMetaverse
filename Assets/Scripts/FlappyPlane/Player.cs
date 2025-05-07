using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapforce = 6f; // 점프하는 힘
    public float forwarSpeed = 3f; // 정면으로 이동하는 힘
    public bool isDead = false;
    float deathCooldown = 0f; // 죽은 뒤 딜레이 

    bool isFlap = false;

    public bool godMode = false; // 게임 테스트용

    GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>(); // 하위 오브젝트에도 적용 가능
        _rigidbody = GetComponent<Rigidbody2D>(); // 오브젝트에 기능이 달려있다면 반환해주는 기능

        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentState == GameManager.GameState.WaitingToStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameManager.currentState = GameManager.GameState.Playing;
            }
            return;
        }

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        gameManager.RestartGame();
                    }
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else if (gameManager.currentState == GameManager.GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameManager.currentState = GameManager.GameState.Playing;
                isFlap = true;
            }
        }
    }
        

    private void FixedUpdate()
    {
        if (gameManager.currentState == GameManager.GameState.WaitingToStart)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        if (isDead || gameManager.currentState != GameManager.GameState.Playing)
            return;

        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity; // 가속도
        velocity.x = forwarSpeed;

        if (isFlap)
        {
            velocity.y += flapforce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle); // 회전 (x, y, z)축 기준
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();
    }
}
