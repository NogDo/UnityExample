using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletMove : MonoBehaviour
{
    #region 전역 변수
    IEnumerator func;
    UnityEngine.Coroutine BulletCoroutine;
    bool isFlying = true;
    Transform playerPos;
    #endregion

    // 호출 순서로 문제가 발생할 수 있으니 Awake쓰는 것이 안전
    void Awake()
    {
        // transform을 분해해서 가져올 수 없기 때문에 다 가져온 후 사용하지 않는 것을 방치한다.
        playerPos = FindObjectOfType<CPoolPlayer>().gameObject.transform;
        transform.position = playerPos.position;
    }

    void OnEnable()
    {
        func = Move();
        BulletCoroutine = StartCoroutine(func);
        transform.position = playerPos.position;
    }

    void OnDisable()
    {
        StopCoroutine(func);
    }

    IEnumerator Move()
    {
        StartCoroutine(Stop());

        while (isFlying)
        {
            transform.Translate(transform.forward * 10f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
        isFlying = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2f);
        isFlying = false;
    }
}
