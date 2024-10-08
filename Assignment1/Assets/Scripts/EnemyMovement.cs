using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float delay;
    public float rotationSpeed;

    public float rotationInterval; // 각도를 변경할 시간 간격 (초)
    private float timeSinceLastRotation = 0f; // 마지막 회전 이후 경과 시간
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        // 각도 변경 시간 누적
        timeSinceLastRotation += Time.deltaTime;

        // 일정 시간마다 회전
        if (timeSinceLastRotation >= rotationInterval)
        {
            transform.Rotate(0, rotationSpeed, 0); // 지정된 회전 속도로 회전
            timeSinceLastRotation = 0f; // 타이머 초기화
        }
    }
}
