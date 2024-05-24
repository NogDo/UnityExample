using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 파티클은 메모리 사용량이 많기 때문에 힙을 거쳐가는 것이 좋다.
[System.Serializable]
public class CTargetInfo
{
    public GameObject target;
    public float moveSpeed;
}

public class CRunParticle : MonoBehaviour
{
    #region public 변수
    // 1. 단일 객체 방식
    public GameObject particleObject;

    // 2. 일대 다 방식 (반복문 사용)
    public GameObject[] targets;
    public float[] moveSpeed;

    // 3. 클래스 사용방식
    public CTargetInfo[] targetInfo;

    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject effect = Instantiate(particleObject, this.transform.position, Quaternion.identity);

            Destroy(effect, 3.0f);
        }


        // 파티클이 많을 경우 사용법
        Vector3 moveVec = Vector3.zero;

        for (int i = 0; i < this.targetInfo.Length; i++)
        {
            Vector3 move = moveVec * this.targetInfo[i].moveSpeed * Time.deltaTime;
            this.targetInfo[i].target.transform.Translate(move);
        }
    }
}
