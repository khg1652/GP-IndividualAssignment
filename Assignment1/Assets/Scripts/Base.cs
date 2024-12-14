using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider 사용

public class Base : MonoBehaviour
{
    public int baseHealth = 100;  // Base의 현재 체력
    public int maxHealth = 100;
    public Slider baseHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        baseHealth = maxHealth;
        UpdateHealthUI();
    }

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
        UpdateHealthUI();
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

    void UpdateHealthUI()
    {
        if (baseHealthBar != null)
        {
            baseHealthBar.value = (float)baseHealth / maxHealth; // 슬라이더 비율 조정
        }
    }
}
