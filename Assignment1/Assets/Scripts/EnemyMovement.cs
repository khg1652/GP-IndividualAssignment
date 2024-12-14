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

    public AudioClip catSound;
    public AudioClip deerSound;
    public AudioClip explosionSound;
    Animator anim;

    void Start()
    {
        // NavMeshAgent 컴포넌트를 가져옴
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

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

        float speed = agent.velocity.magnitude;
        if(speed <= 20f)
        {
            anim.SetInteger("Walk", 1);
        }
        else if(speed >= 20f)
        {
            anim.SetInteger("Walk", 0);
            anim.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Base에 도착하면 공격 처리
        if (collision.gameObject.CompareTag("Base"))
        {
            Debug.Log("2");
            Instantiate(enemyDisappearEffect, collision.contacts[0].point, Quaternion.identity);
            PlaySound(explosionSound);
            PlaySound(catSound);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("3");
            Instantiate(redHitEffect, collision.contacts[0].point, Quaternion.identity);
            PlaySound(deerSound);
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
                PlaySound(deerSound);
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        GameObject audioObject = new GameObject("TempAudio");
        AudioSource tempSource = audioObject.AddComponent<AudioSource>();
        if (clip == deerSound)
        {
            tempSource.volume = 0.3f;
        }
        tempSource.clip = clip;
        tempSource.Play();

        Destroy(audioObject, clip.length);
    }
}
