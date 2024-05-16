using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPoolManager : MonoBehaviour
{
    #region ���� ����
    // ���� ����� ����ϴ�
    CObjectPooling instancePool;
    CPoolPlayer player;
    bool pressed = false;
    #endregion


    void Start()
    {
        // Find �ø���� �������� ��Ȳ�� ���� ���� �� �ִ�.
        instancePool = FindObjectOfType<CObjectPooling>();
        player = FindObjectOfType<CPoolPlayer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            player.pressed = true;
            pressed = true;
        }

        if (player.pressed)
        {
            StartCoroutine(Shoot());

            player.pressed = false;
        }
    }

    // Enum�̱⶧���� ������
    // C#���� �����Ͱ� ���� ������ Enum�� ���� ���·� ���ڴ�.
    // �ڷ�ƾ�� �ִϸ��̼ǿ� ���� ���ȴ�.
    IEnumerator Shoot()
    {
        // yield : �纸, ��ȯ���� �纸�� �� �ִ�.
        // C++�� tuple�� ����ϴ�.
        // �񵿱� ���±⶧���� Update�ʹ� ������ �۵��Ѵ�.
        // �׷��� ������ �񵿱�� �񵿱�� �޴°� ����.
        // �񵿱�� ���⸦ ȥ���ؼ� �� ��� ������ ��������ִ�. (�����ս� ����)
        while (true)
        {
            instancePool.SpawnObj();
            yield return new WaitForSeconds(.3f);
        }
    }
}
