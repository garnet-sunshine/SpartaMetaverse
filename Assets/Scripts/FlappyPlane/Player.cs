using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapforce = 6f; // �����ϴ� ��
    public float forwarSpeed = 3f; // �������� �̵��ϴ� ��
    public bool isDead = false;
    float deathCooldown = 0f; // ���� �� ������ 

    bool isFlap = false;

    public bool godMode = false; // ���� �׽�Ʈ��

    GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>(); // ���� ������Ʈ���� ���� ����
        _rigidbody = GetComponent<Rigidbody2D>(); // ������Ʈ�� ����� �޷��ִٸ� ��ȯ���ִ� ���

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
            _rigidbody.linearVelocity = Vector2.zero;
            return;
        }

        if (isDead || gameManager.currentState != GameManager.GameState.Playing)
            return;

        if (isDead) return;

        Vector3 velocity = _rigidbody.linearVelocity; // ���ӵ�
        velocity.x = forwarSpeed;

        if (isFlap)
        {
            velocity.y += flapforce;
            isFlap = false;
        }

        _rigidbody.linearVelocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.linearVelocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle); // ȸ�� (x, y, z)�� ����
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
