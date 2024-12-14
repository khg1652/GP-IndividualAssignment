using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider ���

public class Base : MonoBehaviour
{
    public int baseHealth = 100;  // Base�� ���� ü��
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
        if (collision.gameObject.CompareTag("Enemy"))  // ���� Base�� �������� ��
        {
            TakeDamage(10);  // �������� ����
        }
    }

    void TakeDamage(int damage)
    {
        baseHealth -= damage;
        UpdateHealthUI();
        if (baseHealth <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.LoseGame();  // Base�� �ı��Ǹ� ���� �й�
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
            baseHealthBar.value = (float)baseHealth / maxHealth; // �����̴� ���� ����
        }
    }
}
