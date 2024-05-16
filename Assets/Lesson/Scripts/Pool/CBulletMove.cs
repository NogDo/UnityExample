using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletMove : MonoBehaviour
{
    #region ���� ����
    IEnumerator func;
    UnityEngine.Coroutine BulletCoroutine;
    bool isFlying = true;
    Transform playerPos;
    #endregion

    // ȣ�� ������ ������ �߻��� �� ������ Awake���� ���� ����
    void Awake()
    {
        // transform�� �����ؼ� ������ �� ���� ������ �� ������ �� ������� �ʴ� ���� ��ġ�Ѵ�.
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
