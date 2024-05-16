using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPoolManager : MonoBehaviour
{
    #region 전역 변수
    // 전방 선언과 비슷하다
    CObjectPooling instancePool;
    CPoolPlayer player;
    bool pressed = false;
    #endregion


    void Start()
    {
        // Find 시리즈는 무겁지만 상황에 따라 사용될 수 있다.
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

    // Enum이기때문에 열거형
    // C#에는 포인터가 없기 때문에 Enum을 참조 형태로 쓰겠다.
    // 코루틴은 애니메이션에 많이 사용된다.
    IEnumerator Shoot()
    {
        // yield : 양보, 반환값을 양보할 수 있다.
        // C++의 tuple과 비슷하다.
        // 비동기 형태기때문에 Update와는 별개로 작동한다.
        // 그렇기 때문에 비동기는 비동기로 받는게 좋다.
        // 비동기와 동기를 혼합해서 쓸 경우 문제가 생길수도있다. (퍼포먼스 저하)
        while (true)
        {
            instancePool.SpawnObj();
            yield return new WaitForSeconds(.3f);
        }
    }
}
