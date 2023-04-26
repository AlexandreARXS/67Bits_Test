using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocoPlayer : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verifica se o botão de ataque foi pressionado
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetBool("Attack", true);
        }
    }

        public void OnAttackButtonClick()
    {
        // Configura o parâmetro Attack para verdadeiro para ativar a animação de soco
        animator.SetBool("Attack", true);
    }
}