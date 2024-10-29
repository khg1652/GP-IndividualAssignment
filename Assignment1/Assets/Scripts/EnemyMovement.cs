using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform baseTarget;  // Base 오브젝트의 위치
    private NavMeshAgent agent;
    public Base baseobject;
    public GameObject blueHitEffect;
    public GameObject redHitEffect;
    public GameObject enemyDisappearEffect; // Base 도달 시 파티클 효과

    void Start()
    {
        // NavMeshAgent 컴포넌트를 가져옴
        agent = GetComponent<NavMeshAgent>();

        // Base 오브젝트의 Transform을 찾아서 타겟으로 설정
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
        // Base로 이동
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
        // Base에 도착하면 공격 처리
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
            // 충돌한 객체가 Bullet2인 경우
            Instantiate(blueHitEffect, collision.contacts[0].point, Quaternion.identity);
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 총알의 전방 방향을 기준으로 밀어내기
                Vector3 knockbackDirection = collision.transform.forward;  // 총알의 Transform.forward 방향
                float knockbackForce = 50f;  // 밀어내는 힘의 크기
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
