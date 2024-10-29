using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform baseTarget;  // Base ������Ʈ�� ��ġ
    private NavMeshAgent agent;
    public Base baseobject;
    public GameObject blueHitEffect;
    public GameObject redHitEffect;
    public GameObject enemyDisappearEffect; // Base ���� �� ��ƼŬ ȿ��

    void Start()
    {
        // NavMeshAgent ������Ʈ�� ������
        agent = GetComponent<NavMeshAgent>();

        // Base ������Ʈ�� Transform�� ã�Ƽ� Ÿ������ ����
        if (baseTarget == null)
        {
            GameObject baseObject = GameObject.FindWithTag("Base");
            if (baseObject != null)
            {
                baseTarget = baseObject.transform;
            }
        }
    }

    void Update()
    {
        // Base�� �̵�
        if (baseTarget == null)
            return;
        if (!baseTarget.gameObject.activeInHierarchy)
        {
            agent.isStopped = true;
            return;
        }

        agent.SetDestination(baseTarget.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Base�� �����ϸ� ���� ó��
        if (collision.gameObject.CompareTag("Base"))
        {
            Debug.Log("2");
            Instantiate(enemyDisappearEffect, collision.contacts[0].point, Quaternion.identity);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("3");
            Instantiate(redHitEffect, collision.contacts[0].point, Quaternion.identity);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Bullet2"))
        {
            Debug.Log("4");
            // �浹�� ��ü�� Bullet2�� ���
            Instantiate(blueHitEffect, collision.contacts[0].point, Quaternion.identity);
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // �Ѿ��� ���� ������ �������� �о��
                Vector3 knockbackDirection = collision.transform.forward;  // �Ѿ��� Transform.forward ����
                float knockbackForce = 50f;  // �о�� ���� ũ��
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
