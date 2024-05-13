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
            // PingPong : 최소 값과 최대 값 사이를 반복
            // PingPong(float t, float length)
            // time : 선언이 된 시점에서 카운트를 시작한다. (Play 시간 누적)
            Mathf.PingPong(Time.time, 4),
            transform.position.y,
            transform.position.z
            );
    }
}
