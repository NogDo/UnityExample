using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKeyInputControl : MonoBehaviour
{
    private readonly float inputSpeedMove = 5.0f;
    private readonly float inputSpeedRotate = 40.0f;

    #region

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        InputRotate();
        InputRotateMove();
        InputIdentity();
    }

    public void InputRotate()
    {
        float AxisY = Input.GetAxis("Horizontal");

        AxisY = AxisY * inputSpeedRotate * Time.deltaTime;
        this.gameObject.transform.Rotate(new Vector3(0, AxisY, 0));
    }

    public void InputRotateMove()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * inputSpeedRotate * Time.deltaTime;
        move = move * inputSpeedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rotate);
        this.gameObject.transform.Translate(Vector3.forward * move);
    }

    void InputIdentity()
    {
        if (Input.GetMouseButton(1))
        {
            // indentity는 초기화이다.
            this.transform.localRotation = Quaternion.identity;
        }
    }
}

#region 05.10 과제
/*
과제1. 트랜스폼 활용

- 만든 모형에 트랜스폼을 적용한다.

1. 일자형 트랙을 구축하고 트랙의 양끝에서 자동차 2대가 마주보고 달려온다.
    ㄴ 두 객체가 충돌했을 때 튕겨 나가거나 밀리게 만드는 물리 법칙을 적용한다.
    ㄴ 자동차는 움직일 때 바퀴는 회전을 해야 한다.

2. 헬기는 직접 조종이 가능해야 하고 움직일때는 프로펠러가 회전을 하며 계속 움직여야 한다.

3. 탱크도 직접 조종을 할 수 있으며 상부와 하부를 각각 따로 회전 시킨다. (모빌 : 바퀴 회전)
    ㄴ 포신 부분과 차체 부분은 실제 탱크처럼 360도 회전에 신경쓸 것
    ㄴ 포신은 조준이 가능해야 한다.

4. 만든 모형 집 주변을 지키는 가드(도형)의 패턴(직선, 곡선, 랜덤 등등...)을 3종 만들것
*/
#endregion