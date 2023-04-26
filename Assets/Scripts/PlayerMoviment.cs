using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoviment : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Animator animator;
    private bool isFacingRight = false;

    private EnemyStack enemyStack;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Flip();

        enemyStack = GetComponent<EnemyStack>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;

        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;
        animator.SetBool("isMoving", isMoving);
    }

    private void Flip()
    {
        if (rb.velocity.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.Rotate(Vector3.up, 180f);
        }
        else if (rb.velocity.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.Rotate(Vector3.up, 180f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Collider myCollider = GetComponent<Collider>();
            myCollider.isTrigger = true; // Habilita o trigger
            // Destroi o inimigo
            Destroy(collision.gameObject);

            // Cria uma cópia do inimigo
            GameObject newEnemy = Instantiate(collision.gameObject);

            // Desativa o collider da cópia do inimigo para que ele não colida com nada
            newEnemy.GetComponent<Collider>().enabled = false;

            // Adiciona a cópia do inimigo à pilha de inimigos no objeto EnemyStack
            //enemyStack.AddEnemy(newEnemy);
        }
    }
}