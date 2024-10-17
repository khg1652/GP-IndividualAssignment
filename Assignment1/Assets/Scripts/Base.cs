using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int baseHealth = 100;  // Base의 체력

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // 적이 Base에 도착했을 때
        {
            TakeDamage(10);  // 데미지를 받음
        }
    }

    void TakeDamage(int damage)
    {
        baseHealth -= damage;
        if (baseHealth <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.LoseGame();  // Base가 파괴되면 게임 패배
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
