using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveCube : MonoBehaviour
{
    #region 전역변수
    public GameObject cubeObject = null;
    public float moveSpeed = 5.0f;
    #endregion

    // 타 컴포넌트와는 독립적으로 동작하는 객체
    void Start()
    {
        //MoveSample_01();
    }

    void Update()
    {
        //MoveSample_02();
        MoveSample_03();
        CubeJump();
    }

    void MoveSample_01()
    {
        // 월드 좌표계
        transform.position = new Vector3(0.0f, 5.0f, 0.0f);

        // 로컬 좌표계
        // 로컬 좌표계를 사용하기 떄문에 오브젝트에 회전이 들어가있으면 결과값이 달라질 수 있다.
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
    }

    void MoveSample_02()
    {
        // 월드 좌표계
        float moveDelta = moveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;

        pos.z += moveDelta;
        this.transform.position = pos;


        // 로컬 좌표계
        // Translate에서 t가 소문자면 UI관련 대문자면 로컬
        moveDelta = moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);


        // 유니티에서는 정규화 벡터를 지원한다.
        // 벡터는 크기와 방향을 가진 데이터 타입이다.
        // ㄴ 정규화 벡터들의 특징은 모두 노멀라이즈가 되어 있다 -> 노말라이즈가 되어 있다는 것 -> 이게 바로 벡터의 정규화를 뜻한다. (단위 벡터)
        // ㄴ 단위 벡터 : Vector3(1, 1, 1)
        // 객체의 스케일에 따라 결과값이 달라지기 때문에 정규화된 벡터를 사용해야한다.
        // 단위 벡터의 최대값은 1이다.
        // 정규화된 벡터를 사용해야하는 이유는 벡터의 중첩현상 떄문에 대각선 이동에서 더 많은 값을 이동하기 때문이다.


        /*
        Vector3(1, 0, 0)        ->  Vector3.right
        Vector3(-1, 0, 0)       ->  Vector3.left

        Vector3(0, 1, 0)        ->  Vector3.up
        Vector3(0, -1, 0)       ->  Vector3.down

        Vector3(0, 0, 1)        ->  Vector3.forward
        Vector3(0, 0, -1)       ->  Vector3.back

        Vector3(0, 0, 0)        ->  Vector3.zero (원점으로 이동하지 않겠다)
        Vector3(1, 1, 1)        ->  Vector3.one (세축으로 동시에 이동하겠다)

        관련 클래스 멤버
        Vector3.Dot(A, B)       ->  벡터의 내적값을 구한다. 내적 찾아볼 것
        Vector3.Cross(A, B)     ->  벡터의 외적값을 구한다. 외적 찾아볼 것
        Vector3.Distance        ->  벡터의 거리차이를 구한다. (A와 B)
        Vector3.Angle           ->  벡터의 각도차이를 구한다. (Degree) 삼각함수 찾아볼 것

        인스턴스 멤버
        Vector3.Normalize()     ->  단위벡터 만들겠다.
        Vector3.Magnitude()     ->  벡터의 길이를 알려주는 프로퍼티
        Vector3.SqrMagnitude()  ->  벡터의 길이 제곱을 알려주는 프로퍼티 -> 빠르다.
        */
    }

    void MoveSample_03()
    {
        var cubePosition = cubeObject.transform.position;

        /*
        GetAxis / GetAxisRaw

        - 넘겨받는 매개 변수의 문자열을 통해서 키보드나 조이스틱의 입력 값을 -1 ~ +1 사이의 값으로 반환

        - 둘의 차이는 즉각적인 반응과 부드러운 반응의 차이가 있다.

        GetAxis : 부드러운 반응, 실수의 값을 반환한다.
        GetAxisRaw : 즉각적인 반응, 정수의 값을 반환한다.

        */

        // 1. GetAxis를 쓰는 방법
        float fDeltaX = Input.GetAxisRaw("Horizontal");
        float fDeltaZ = Input.GetAxisRaw("Vertical");

        Debug.LogFormat("DeltaX : {0}", fDeltaX);

        cubePosition.x += fDeltaX * moveSpeed * Time.deltaTime;
        cubePosition.z += fDeltaZ * moveSpeed * Time.deltaTime;

        //cubeObject.transform.Translate(fDeltaX * moveSpeed * Time.deltaTime, 0.0f, fDeltaZ * moveSpeed * Time.deltaTime);


        // 2. GetKey를 쓰는 방법
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cubePosition.x -= moveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cubePosition.x += moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            cubePosition.z += moveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cubePosition.z -= moveSpeed * Time.deltaTime;
        }

        cubeObject.transform.position = cubePosition;
    }

    void CubeJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 0.5f, 0.0f);
            velocity = velocity * power;
            this.GetComponent<Rigidbody>().velocity = velocity;
        }

        if (Input.GetMouseButton(1))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 2.0f, 0.0f);
            velocity = velocity * power;
            // 외부의 힘을 누적시키는 것
            this.GetComponent<Rigidbody>().AddForce(velocity);
        }
    }
}