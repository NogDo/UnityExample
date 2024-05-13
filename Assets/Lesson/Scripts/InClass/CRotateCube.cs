using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 회전
/*

▶ 트랜스폼 (회전)

- 앞으로 기억해야 할 4가지

1. transform.Rotate
    ㄴ 오브젝트 회전

2. transform.RotateAround
    ㄴ 기준 오브젝트를 보면서 회전

★★★ 면접 질문 ★★★
3. Quaternion
    ㄴ 복소수 / 사원수 -> (짐벌락 현상을 해결하기위해 도입된 수식)
        ㄴ (x, y, z, w)
    ㄴ 3개의 축 이외에도 추가로 스칼라가 있다
    ㄴ 각 축끼리 연결시키지 않고 독립적이다.
    ㄴ 회전을 하기 위해서 모든 축을 돌려야 하기 때문에 연산량이 많다.

★★★ 면접 질문 ★★★
4. EulerAngles
    ㄴ 오일러가 만든 각도기법으로 축끼리 연결이 되어 있다.
    ㄴ 회전을 하다보면 필연적으로 축끼리 겹치는 현상이 발생하는데 축끼리 연결되어 있기 때문에 한 축이 자유도를 상실하게 된다.
    ㄴ Quaternion에 비해 연산량이 압도적으로 적다는 장점이 있다.
    ㄴ 고정 각도 (Roll Pitch Yaw; RPY(XYZ)로 기억하자)
        ㄴ 회전한 축을 기준으로 다음 회전을 한다는 점이 고정 각도와의 차이점을 발생 시킨다.

★ 짐벌락 (Gimbal Lock) : x, y, z 순으로 회전을 한다고 가정을 하면 y축 회전에 의해 이전에 x축으로 회전했던 축과 
z축이 같아지는 현상 -> 각도가 어긋난다.

*/
#endregion


public class CRotateCube : MonoBehaviour
{
    #region 전역변수
    public GameObject target = null;
    #endregion

    void Start()
    {
        //RotateSample_01();
    }

    void Update()
    {
        //RotateSample_02();
        RotateAroundSample();
    }

    void RotateSample_01()
    {
        // 제자리 회전

        // 1. eulerAngles : 축을 기준으로 각도만큼 회전 (기본적으로 각도는 고정되어 있다.)
        this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // 2. 절대 각도를 의미한다.
        // ㄴ 인자로 들어온 벡터의 오일러 값을 쿼터니언으로 변환 -> 파라미터에는 주로 실수 / 벡터 값이 들어온다.
        // Quaternion 프로퍼티 형식으로 동작하기 때문에 단독으로 실행될 수 없다.
        Quaternion target = Quaternion.Euler(45.0f, 45.0f, 45.0f);  
        this.transform.rotation = target;

        // 3. Rotate
        // Rotate vs rotation 차이
        // ㄴ Rotate : 지속성
        // ㄴ rotation : 단발성
        // ㄴ Rotate(회전할 기분 좌표 축 * 델타 타임 * (회전 속도) * (변위량))
        this.transform.Rotate(Vector3.up * 60.0f);
    }

    void RotateSample_02()
    {
        // AngleAxis : 축 주위를 Angle만큼 회전한 로테이션을 생성하고 반환한다.
        // 중심 축이 되는 axis가 y축일 경우 y축에 대한 회전값은 변하지 않고 x, z의 값만 변한다.

        this.transform.rotation *= Quaternion.AngleAxis(1.5f, Vector3.up);
    }

    void RotateAroundSample()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 40 * Time.deltaTime);
    }
}
