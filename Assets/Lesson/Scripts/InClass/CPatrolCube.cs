using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatrolCube : MonoBehaviour
{
    void Update()
    {
        PatrolCube();
    }

    void PatrolCube()
    {
        transform.position = new Vector3
            (
            // PingPong : �ּ� ���� �ִ� �� ���̸� �ݺ�
            // PingPong(float t, float length)
            // time : ������ �� �������� ī��Ʈ�� �����Ѵ�. (Play �ð� ����)
            Mathf.PingPong(Time.time, 4),
            transform.position.y,
            transform.position.z
            );
    }
}
