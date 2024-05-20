using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 코루틴
/*

▶ 코루틴 (Coroutine)

- Co + routine (Corporate Routine)

- 일정 시간 간격을 두고 함수를 호출할때 사용한다.
ㄴ 코루틴은 프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간만큼 수행하는것이 가능하다.

- 코루틴이 여러개의 서브 루틴을 생성한다고 해서 스레드와 같다고 생각을 하는데 코루틴은 "비동기(호출 벨)", 스레드는 "동기(줄을 기다리는 것)"

- 비동기는 각자 할 일을 하면서 호출하면 오는 것, 동기는 줄을 서서 기다리는 것

- 스레드와 코루틴의 가장 큰 차이점
ㄴ 스레드의 경우 lock을 걸어 우선 동기화를 시켜줘야 하는 반면에 코루틴은 lock을 걸지 않는다.

- 스레드는 Context Switching을 수행한다. (스레드를 번갈아 가며 한번씩 실행)

- 스레드는 번갈아 가며 수행하지만 호출 순서의 문제가 있기 때문에 똑같은 스레드를 실행할 수 있다.
ㄴ 따라서 호출이 된 후에는 Critical Section이 되어서 다른 순번까지 lock이 걸려 실행되지 않는다.

- 메모리 사용량이 많다는 단점이 있다.
ㄴ 컬렉션이기 때문에


▶ 코루틴을 사용해야 하는 이유?

- 코루틴은 항상 실행되는 것이 아니라 특정 상황에서 호출하고 반복 작업을 하는게 안정적으로 가능하다.

- 이러한 점에서 매 프레임 실행되는 Update 보다 특정 상황에서 아주 강력 + 효율적이다.
ㄴ 신입 기준


※ 포폴에서의 코루틴...

- 남발? 은 안된다.

- 코루틴이 들어가는 상황은 매번 뭔가를 체크해야 할때?

- 조건문을 줄이고 싶을때?

- 함수 + 메서드의 양을 줄이고 싶을때?

- 세개 중에 하나라도 부합하면 코루틴을 사용하자


º 결론

- 대기 시간보다 실행 시간이 많은 경우에는 코루틴은 좋은 선택이 아니다.

- 특정 조건에 의해 일시적으로 실행되는 경우나 시간의 흐름대로 실행할 때 코루틴을 사용하면 아주 좋다.


º 함수 원형

IEnumerator Coroutine()
{
    yield return type;
}


▶ IEnumerable

- C++ 반복자와 비슷하게 사용하기 위한 C#의 반복자 패턴

- 컬렉션중 하나이며 반복문에서 객체를 한개씩 넘겨주는 역할을 수행한다.
ㄴ C# -> 컨테이너 -> foreach


º STL or 유사기능
C++                  C#
Vector / List   ArrayList(추천) / List(추천)
Map             Dictionary(추천) / Hashtable(업계에서 쓰지만 난이도가 있어 권장하지 않는다.)
Pair            KeyValuePair

※ C#에서는 5개 중 3개 정도는 쓸 줄 알아야 한다.


▶ IEnumerator

- 열거자 (컬렉션 중 하나이며 포인터와 비슷한 역할을 한다.)

- IEnumerator는 기본적으로 Enumerator가 가지고 있어야 할 메서드들을 들고 있는 인터페이스

- Movenext() 메서드가 실행되고, false일 경우 종료한다.


▶ 고민을 해봅시다....

- IEnumerable는 n+1 / n+2 / n+3 이라는 식으로 데이터를 넘겨준다.

- 이때 중요한건 넘겨주는 쪽이 몇번째 데이터를 넘겨줬는지 기억을 하고 있어야 한다.
ㄴ Request를 요청한 곳은 이전 데이터를 기억하지 못하기 때문에 IEnumerable이 기억해야 한다.

EX)
단일
IEnumerable -> 다음 데이터 내놔. 

다중
                다음 데이터 내놔.
                다음 데이터 내놔.
                다음 데이터 내놔.
IEnumerable ->  다음 데이터 내놔.
                다음 데이터 내놔.
                다음 데이터 내놔.
                다음 데이터 내놔.


                IEnumerator(n+1)  ->  다음 데이터 내놔.
                IEnumerator(n+2)  ->  다음 데이터 내놔.
                IEnumerator(n+3)  ->  다음 데이터 내놔.
IEnumerable ->  IEnumerator(n+4)  ->  다음 데이터 내놔.
                IEnumerator(n+5)  ->  다음 데이터 내놔.
                IEnumerator(n+6)  ->  다음 데이터 내놔.
                IEnumerator(n+7)  ->  다음 데이터 내놔.


▶ 코루틴 속성 값

- yield return은 실행을 끝내고 다음 프레임에서 실행을 재개할 시점

IEnumerator Coroutine()
{
    yield return new WaitForSeconds()

    yield return null (생각보다 많이 쓴다; 애니메이션 멈춰놓기)
    ㄴ 다음 업데이트까지 대기 (프레임)

    yield return new WaitForFixedUpdate()
    ㄴ 다음 물리 업데이트까지 대기

    yield return new WaitForEndOfFrame() (많이 쓴다; 로딩, 장면 전환에 쓴다.)
    ㄴ 렌더링이 끝날때까지 대기

    yield return StartCoroutine(String)
    ㄴ 안에 들어온 다른 코루틴이 끝날때까지 대기

    yield return WWW(String)
    ㄴ 웹 통신 작업이 끝날때까지 대기

    yield return new AsyncOperation
    ㄴ 비동기 작업이 끝날때까지 대기 (씬 로딩)

    yield break
    ㄴ 실행이 완료되기 이전에 임의로 코루틴을 종료
}

※ yield return이 중첩되면...

- 코루틴이 먼저 호출되고 다시 한번 while문이 실행되면 가장 마지막에 있는 리턴문이 일어났던 위치의 다음줄 부터 실행을 재개하는 구조를 가지고 있다.

- 실행이 재개되면 } or yield 문을 만나기전까지 반복해서 코드를 읽어들인다.

*/
#endregion

public class CCoroutineExample : MonoBehaviour
{
    private IEnumerator coroutine;

    // Invoke : 메서드를 일정시간만큼 지연할때 사용한다.
    // ㄴ Repeating / Cancel / Cancel(String)
    private float Delay = 2.0f;

    // Start에 코루틴이 물리는 경우에는 기본적으로 Invoke 요놈과 고민을 해봐야 한다.
    void Start()
    {
        coroutine = PrintCount(2.0f);
        StartCoroutine(coroutine);

        InvokeRepeating("InvokeSample", 5.0f, Delay);
    }

    void Update()
    {
        // 1. this를 전제한 방식
        CoroutineSample();

        // 2. 참조를 전제한 방식
        if (Input.GetKeyDown("c"))
        {
            // StopCoroutine(IEnumerator) / StopCoroutine(string methodName) / StopAllCoroutine()
            // 해당 IEnumerator만 빼준다
            StopCoroutine(coroutine);
            // 해당 IEnumerable까지 빼준다.
            StopCoroutine("PrintCount");
            // 해당 스크립트의 코루틴을 빼준다.
            StopAllCoroutines();

            Debug.Log("정지 : " + Time.time);

            CancelInvoke();
        }
    }

    private void CoroutineSample()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("MoveToCoroutine");
        }
    }

    // IEnumerator <T>도 존재한다.
    // 객체 하나가 아닌 여러 객체를 받겠다는 뜻
    // 이를 사용하기 위해서는 설계가 필요하다 (확장 메서드)
    IEnumerator MoveToCoroutine()
    {
        float delayTime = 1.0f;

        yield return new WaitForSeconds(delayTime);

        this.transform.Translate(0, 0, 1.0f);
    }

    public IEnumerator PrintCount(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("PrintCount : " + Time.time);
        }
    }

    void InvokeSample()
    {
        print("Invoke Call");
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