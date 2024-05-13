using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectController : MonoBehaviour
{
    #region 전역변수
    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;
    #endregion

    public void Awake()
    {
        Debug.Log("너희의 빛... 유니티");

        // 1. GetComponenet<T> 활용
        // var는 auto와 비슷한 것, 약한 형식 검사이다. 강한 형식 검사는 데이터 타입을 명시하는것 (int, float)
        // var는 지역 변수로만 선언을 해야하고 선언과 동시에 반드시 초기화를 수행해야 한다.
        var transformObject = cubeObject.GetComponent<Transform>();
        transformObject.position = new Vector3(0.0f, 5.0f, 0.0f);

        var selfTransform = gameObject.GetComponent<Transform>();
        selfTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


        // 2. 프로퍼티 활용
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cubeObject.transform.position = new Vector3(0.0f, 0.0f, 5.0f);

        // 3. Find 활용
        var oCubeObject = GameObject.Find("MoveCube");
        oCubeObject.AddComponent<CMoveForward>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }
}
