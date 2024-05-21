using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 유니티 애니메이션
/*
 
▶ 유니티 애니메이션

- 유니티 애니메이션은 크게 2가지로 나뉜다.
    ㄴ 1. 레거시
    ㄴ 2. 메카님


▶ 레거시

- 레거시는 오브젝트마다 가지고 있는 애니메이션을 외붙 툴로 작업을 하고 가져오는 방식이다.

- 레거시는 인간형이 아닌 모듈에 자주 적용이 되어 있다.
    ㄴ 이유는 레거시 자체가 이식성이 떨어지고 확장성이 메카님에 비해 떨어지기 때문

- 확정성을 고려하지 않으면 메카님보다 레거시가 유리하다.


▶ 메카님

- 메카님은 유니티 버전이 릴리즈되면서 추가된 애니메이션 상태 머신 툴이라고 할 수 있다.

- 레거시 애니메이션이 가지고 있는 단점으로 자연스러운 애니메이션 / 확장성을 해소한 애니메이션 기법이라고 할 수 있다.


º 장점

- 이식성과 재생산성이 좋다.

- 인체형 애니메이션 모델의 본 구조만 일치한다면 다른 애니메이션이나 모션 애니메이션을 적용할 수 있다.

- 직관성이 뛰어나다. (장점이자 단점)


º 단점

- 스테이트가 많아질수록 확장성이 떨어지며 상태 전이를 관리하기 위해 매우 복잡해진다.

- 최초 설계가 까다롭고 수정이 용이하지 못하다.


※ 레거시는 Animation이라는 컴포넌트 사용 / 메카님은 Animator를 사용한다.


º 애니메이터

- 게임 오브젝트에 장착하는 특별한 유형의 애니메이션 컴포넌트

- 애니메이션 제어를 위한 정보가 들어 있기 때문에 애니메이션을 사용하려면 애니메이터 또한 사용을 해야 한다.


▷ 애니메이션 타입

- 휴머노이드
ㄴ 머리 / 팔 / 다리가 있는 캐릭터는 일반적으로 인간형으로 분류가 되고 인간형 객체들은 리타겟팅을 통해 애니메이션을 공유할 수 있다.
    ㄴ 이게 가능한 이유는 아바타를 공유할 수 있기 때문에

- 제네릭
ㄴ 휴머노이드를 제외한 나머지 오브젝트들이라고 생각하면 좋을 것 같다.
ㄴ 기본적으로 리타겟팅 대상 객체들은 아니지만 애니메이션 구조를 사용하고 싶을 때 사용되는 형태
ㄴ 단일 객체기 때문에 효율적이다. (메모리 사용량이 적음)


★★★★★ 면접 질문 ★★★★★
▶ 유니티 엔진 유한 상태 머신 (Finite State Machine)

- 유한 상태 머신 (FSM)은 상태와 행동에 따라 독립적인 클래스로 제어dhk 교체가 가능하도록 하는 패턴을 의미한다.

- 유한한 상태를 정의하고 처리하는 구조이며 각 State가 있고 그 State를 전이시키기 위한 조건이 있는데 그것을 표현하는 기법이라고 할 수 있다.


º FSM 주요 개념

- State
ㄴ 정의된 하나 / 여러 동작을 의미한다.

- Trasition
ㄴ 한 상태에서 다른 상태로 전이하는것을 말한다.

- Event
ㄴ 상태 전이를 위한 조건 / 조건이 만족하면 상태 전이가 발생한다.

- Action
ㄴ 실제 행동이 실행된다.

※ 공통적으로 각 상태 로직은 외부 전이 조건에 따라 변경이 될 수 있다.


º 포인트
ㄴ 애니메이션 클립이 적다면 레거시 / 메카님
ㄴ 애니메이션 클립이 많거나 적거나 대상 객체가 휴머노이드라면 무조건 메카님
ㄴ 애니메이션 클립이 적고 제네릭 타입이라면 레거시 / 메카님 (선택 기준은 리소스마다 다름)



º 다이나믹 본

- 머리카락, 망토 같은 곳에 들어간다.


▶ Character Controller

- Slope : 경사값

- Step Offset : 계단의 높이

- Skin Width : 끼는 현상 방지, 특정 값을 무시한다. (지터링; 캐릭터 이동 이벤트가 트리거되는데 움직임이 없다면 지터링을 실행, 캐릭터를 위로 쏨)

- Min Move Distance : 가속도와 관성에 관여한다. 캐릭터가 지정한 값 보다 작게 이동하면 이동을 하지못하게 막음, 바람에 영향을 안받게 하기 위해서도 사용


▶ Animator

- Apply Root Motion : Root Motion을 애니메이션에서 제어할지, 코드에서 제어할지 선택 (체크 해제가 코드에서 제어)

- Update Mode
ㄴ Normal (Update와 코루틴 둘다 사용)
ㄴ Animate Physics()
ㄴ Unscale Time(Update, 코루틴 둘다 사용X 연출에 사용, 프레임 사이에 시간을 줄 수 있음)

- Culling Mode (매우 어려움) : 최적화에 관련된 옵션, 현재 보고 있지 않은 텍스쳐를 뭉게서 최적화
 
*/
#endregion

public class CMecanimController : MonoBehaviour
{
    CharacterController chanController;
    Vector3 direction;

    #region public 변수
    public float runSpeed = 4.0f;
    public float rotationSpeed = 360f;
    #endregion

    Animator animator;

    void Start()
    {
        chanController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        animator.SetFloat("aSpeed", chanController.velocity.magnitude);

        ChanControl_Slerp();
    }

    private void ChanControl_Slerp()
    {
        Vector3 direction = new Vector3
            (
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp
                (
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );

            transform.LookAt(transform.position + forward);
        }

        else
        {
            // 설정 x
        }

        chanController.Move(direction * runSpeed * Time.deltaTime);
    }
}
