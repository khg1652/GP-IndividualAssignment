using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float delay;
    public float rotationSpeed;

    public float rotationInterval; // ������ ������ �ð� ���� (��)
    private float timeSinceLastRotation = 0f; // ������ ȸ�� ���� ��� �ð�
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        // ���� ���� �ð� ����
        timeSinceLastRotation += Time.deltaTime;

        // ���� �ð����� ȸ��
        if (timeSinceLastRotation >= rotationInterval)
        {
            transform.Rotate(0, rotationSpeed, 0); // ������ ȸ�� �ӵ��� ȸ��
            timeSinceLastRotation = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }
}
