using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStack : MonoBehaviour
{
    public float stackHeight = 1f;

    public GameObject enemyStackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEnemy(GameObject enemy)
{
    GameObject newEnemyStack = Instantiate(enemyStackPrefab);
    newEnemyStack.transform.position = transform.position + new Vector3(0f, stackHeight, 0f);
    newEnemyStack.transform.parent = transform;

    // Desativa o inimigo original para que ele não seja mais exibido
    enemy.SetActive(false);

    // Posiciona a cópia do inimigo na posição correta nas costas do jogador
    enemy.transform.position = transform.position + new Vector3(0f, stackHeight, 0f);
    enemy.transform.parent = transform;

    // Atualiza a altura da pilha de inimigos
    stackHeight += enemy.GetComponent<Renderer>().bounds.size.y;

    // Encontra o objeto do jogador com a tag "Player"
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null)
    {
        // Instancia o prefab do inimigo nas costas do jogador
        GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Man Variant");
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = player.transform.position + new Vector3(0f, stackHeight, 0f);
        newEnemy.transform.parent = player.transform;
    }
}
}
