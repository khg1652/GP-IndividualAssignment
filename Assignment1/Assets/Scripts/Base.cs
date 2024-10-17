using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int baseHealth = 100;  // Base�� ü��

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
}
