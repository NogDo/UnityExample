using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 코루틴
/*

▶ 코루틴 (Coroutine)

- Co + routine

- 일정 시간 간격을 두고 함수를 호출할때 사용한다.
ㄴ 코루틴은 프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간만큼 수행하는것이 가능하다.

- 코루틴이 여러개의 서브 루틴을 생성한다고 해서 스레드와 같다고 생각을 하는데 코루틴은 "비동기(호출 벨)", 스레드는 "동기(줄을 기다리는 것)"

- 비동기는 각자 할 일을 하면서 호출하면 오는 것, 동기는 줄을 서서 기다리는 것

- 스레드와 코루틴의 가장 큰 차이점
ㄴ 스레드의 경우 lock을 걸어 우선 동기화를 시켜줘야 하는 반면에 코루틴은 lock을 걸지 않는다.

- 스레드는 Context Switching을 수행한다. (스레드를 번갈아 가며 한번씩 실행)

- 스레드는 번갈아 가며 수행하지만 호출 순서의 문제가 있기 때문에 똑같은 스레드를 실행할 수 있다.
ㄴ 따라서 호출이 된 후에는 Critical Section이 되어서 다른 순번까지 lock이 걸려 실행되지 않는다.


*/
#endregion

public class CCoroutineExample : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}

#region 05.17 과제
/*
과제1. 프로젝트에 대한 기획서 작성

- 제출 : 다음주 월요일 수업전까지


능력단위 평가

- 메일로 제출

- 양식을 꼭 지킨다.

- 메일 제목(양식) : VR 7기_게임플랫폼 응용 프로그래밍_이름

- 첨부 파일
ㄴ VR 7기_게임플랫폼 응용 프로그래밍_이름.zip
    ㄴ 1. 프로젝트 2. 실행파일 캡처 (실제 플레이 화면 3장)
                        ㄴ 01 / 02 / 03
ㄴ VR 7기_게임명_이름.ppt

- 메일 내용 : 특이사항 기입


º 능력단위 평가 지시

- 작업 지시서 기반 프로젝트를 완성하고 제출하시오.

1. 플래피 버드와 비슷한 형태의 게임을 구현

2. PC플랫폼에 맞춰 구현할 것

3. 관련 게임에 적합한 자료구조와 알고리즘을 사용 할 것

4. 효율적인 메모리 관리 방안을 구현할 것 (오브젝트 풀)

5. 에러 및 문제점 발생 시 디버깅을 통해 수정 할 것


*/
#endregion