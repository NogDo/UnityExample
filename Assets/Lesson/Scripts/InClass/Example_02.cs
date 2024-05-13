// System : 숫자나 텍스트 같은 데이터를 다룰 수 있는 기본적인 데이터 처리 클래스를 비롯하여 C# 코드가 기본적으로 필요로 하는 클래스를 담고 있는 namespace
// Collections : 간단하게 말하자면 자료구조 -> 데이터 모음
// ㄴ 배열 / 스택 / 큐 / 해쉬 테이블 등이 C#에서는 컬렉션이라는 이름으로 제공이 된다.
using System.Collections;
// 일반화된 컬렉션을 사용하겠다. (추가한다)
// STL같이 표준화된 것들이 들어있다. (리스트, 큐, 딕셔너리)
// 기본 컬렉션은 타입이 정해져 있지 않기 때문에 형변환이 빈번하게 발생하고 이는 곧 성능저하로 이어진다.
// ㄴ 이러한 문제점을 보완한게 일반화 컬렉션
using System.Collections.Generic;
// 유니티 엔진에서 제공하는 기능을 사용하겠다.
using UnityEngine;


#region 유니티 스크립트
/*
 
▶ 스크립트 (Script)

- 유니티 엔진에서 커스텀하게 동작하는 별도의 로직을 작성하기 위해 존재하는 컴포넌트,
ㄴ 스크립트를 통해서 엔진에서 제공되지 않는 기능을 구현하는 것이 가능하다.

- 예전에는 자바 스크립트 / Boo 라는 언어를 지원했지만 현재는 C#을 기본적으로 채택하고 있다.

- 스크립트는 전문적인 프로그래밍 언어가 아니라 일종의 간이 언어로 작동된 짧은 명령어들로 보는게 맞다.

- C / C++ / C#에 비해 제한된 능력을 지니고 있지만 프로그램을 쉽고 빠르게 작성할 수 있으며, 언어의 제한적인 기능만 사용하므로
초심자들이 배우기 쉽다는 장점이 존재한다.

- 우리는 스크립트를 게임의 목적에 따라 행위를 설정할 때 사용하며 결국 유니티로 게임을 잘 만들기 위해서는
스크립트를 잘 활용할 줄 알아야 한다. (회사가 우리를 채용하는 이유)


▷ 유니티 스크립트의 특징 (C# 언어)

- 스크립트가 게임 객체에 컴포넌트로 추가되기 위해서는 반드시 MonoBehaviour를 직/간접적으로 상속해야 한다.

- 유니티 스크립트는 StartCoroutine 메서드를 이용해서 협력적으로 동작하는 루틴을 작성하는 것이 가능하다.
ㄴ 코루틴 기능을 제공한다는 얘기

- 또한 에디터 스크립트를 제공하기 때문에 해당 기능을 이용하면 별도의 작업 환경을 구축하는것 또한 가능

- 유니티 스크립트는 메세지 방식으로 구동하기 때문에 SendMessage 함수를 통해서 특정 게임 객체가 지니고 있는 스크립트의 메서드를 호출하는것이 가능한 구조

- 이는 BroadcastMessage를 발생시킬 수 있다는 얘기고 특정 게임 객체의 자식 객체를 포함해서 메세지를 전파하는것이 가능하다.


▷ Co(Coorperate) routine (협력하는 루틴)

- n개 이상의 프로세스를 실행시킬 수 있는 루틴 (n개 이상의 리턴값을 만듦)

- 비동기 / 동기 적으로 작동한다.

- Iterator가 들어가있음

- 함수의 진입점도 정해줄 수 있다.


▷ SendMessage

- 합법적 GOTO문이다.

- 상속관계와 접근제어지시자를 무시하고 작동한다.


▷ BroadcastMessage

- Message가 발생했을 때 다른 스크립트에 전파하겠다는 것

- 속도를 챙길 수 있다. (갱신될 것들만 갱신을 하기 때문)


▷ 유니티 이벤트

- 스크립트 객체 안에 다른 기능은 특정 이벤트라 부르며 가장 많이 사용되는 이벤트는 아래와 같다.
ㄴ Awake : 가장 먼저 시작되는 메서드(함수), 생성자에 이니셜라이즈
ㄴ Start : 생성자 Scope안에 들어오는 것들
ㄴ Update : 계속 갱신하는 메서드
ㄴ FixedUpdate : 물리연산을 할때 호출되는 Update 메서드
ㄴ 코드 외부 함수 : 객체가 로딩될 떄 실행되는 것, 스크립트의 상태를 초기화할 때 사용할 수 있다.
ㄴ 사용자 정의 함수 (메서드) : 프로그래머가 정의하여 사용되는 메서드

 
 
*/

#endregion

// 많이 사용할 것!
/// <summary>
/// 시작 클래스 
/// </summary>
/// <param name="현재 상태">MonoBehaviour를 상속받는 기본 클래스.</param>
public class Example_02 : MonoBehaviour
{
    /*
    
    MonoBehaviour : 유니티의 중요하며 기본적인 함수들을 지원하고 있다.

    MonoBehaviour -> Behaviour -> Component -> Object
    ㄴ 상속 구조

    메서드(C#)? 함수(C++)?
        ㄴ 함수 : 코드 조각 및 모음 / 독립된 기능
        ㄴ 메서드 : 클래스 함수 (클래스 및 객체), 클래스 밖이던 안이던 C#으로 적혀있다면 대부분 메서드

    - 스크립트 컴포넌트에서 다른 객체 또는 자기 자신의 객체에 속해 있는 컴포넌트에 접근하기 위해서는
    일반적으로 gameObeject.GetComponent<T> 함수를 이용한다.

    - 또한 자주 사용되는 컴포넌트는 미리 프로퍼티로 정의가 되어 있기 때문에 해당 프로퍼티를 이용하면 좀더 편하게 접근하는 것이 가능하다.

    - 프로퍼티는 Getter Setter이다.

    */

    // 인스턴스가 만들어질때 한번 실행된다.
    // ㄴ 주로 초기화를 위해 사용되며 한번만 호출된다.
    // ㄴ 스크립트가 비활성화 상태라도 한 번은 호출된다.
    void Awake()
    {
        // print() : 콘솔 뷰에 다양한 Value 확인 가능
        // 독립된 기능이기 때문에 속도면에서 유리하다.
        // 다만 MonoBehaviour의 상속을 받아야 사용
        // Debug.Log를 Wrapping(기본 기능을 사용하기 쉽게 빼놓았다) 한 클래스
        print("Awake Call");
    }

    // 함수 안에 들어 있는 명령어는 게임 시작과 동시에 자동으로 실행이 된다.
    // 스크립트 요소가 비활성화 상태라면 호출이 되지 않음. 활성화 상태일 때 호출
    void Start()
    {
        print("Start Call");

        // Debug 클래스를 사용한다.
        // MonoBegaviour의 상속을 받지 않아도 사용이 가능하다.
        Debug.Log(this.gameObject.name + " 입니다.");
    }

    // 해당 영역에 있는 명령어는 게임이 실행되는 동안 매 프레임마다 자동으로 한번씩 반복 호출
    // 내가 만들 게임에 FPS를 설정하려면 주로 Update에서 처리가 발생한다.
    // ㄴ 불완전 호출 (하드웨어의 영향을 많이 받기 때문)
    void Update()
    {
        print("Update Call");

        /*
        ▶ GetKey 시리즈

        - 유니티에서 지원하는 GetKey(액션 맵핑) / GetAxis(축 맵핑) 시리즈
        ㄴ 그중에 GetKey는 KeyCode를 사용하여 입력을 받는다.

        EX)
        GetKey : 특정 키를 누르고 있는 동안 true를 반환하는 Input 함수
        GetButton : 유니티 내부에 정의된 버튼 이름을 사용하겠다.

        ※ 또한 반환 여부의 차이점 또한 존재


        º 자매품
        - OnMouseXXX 시리즈
        ㄴ 콜라이더가 존재해야 동작 가능
        */


        // Return은 Enter
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(this.gameObject);
        }

        //if (Input.GetButton(KeyCode.Return))
        //{
        //    Destroy(this.gameObject);
        //}
    }

    // 대표적으로 적용되는 케이스는 카메라, 펫이 있다.
    // 캐릭터를 움직이고, 캐릭터의 좌표값에 따라 카메라를 움직이겠다.
    void LateUpdate()
    {
        
    }

    // Update의 불완전 호출을 개선하기 위해 나온 함수
    // 물리 업데이트이다.
    // 정해진 시간값에 기반하여 동작한다.
    void FixedUpdate()
    {
        // 기본 시간 : 0.02 Sec
    }

    // 이 함수를 잘쓰게 되면 boolean이 많이 빠지게 된다.
    void OnDisable()
    {
        
    }

    void OnDestroy()
    {
        // 남발 금지
        // 단. Prefab(뭔가를 돌려쓴다는 뜻)을 사용할때는 예외
    }

    // GameScene에 보이지 않을 때 호출
    // 런게임에서 많이 쓸 것 같다.
    // 메모리 회수할 때 사용
    void OnBecameInvisible()
    {
        
    }

    // GameScene에 나타났을 때 호출
    // 보스전 시작할 때 카메라 무빙에 사용한다.
    // 객체가 생성되면 포커스를 준다
    // 주로 카메라에 들어감
    void OnBecameVisible()
    {
        
    }

    // 기즈모를 그린다.
    // 비어있는 오브젝트를 시각적으로 편하게 보기 위해 사용한다.
    // ㄴ OnDrawGizmosSelected -> 선택됐을때만
    // Scene뷰에서만 동작을한다.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
        //Gizmos.DrawWireSphere(this.transform.position, 1.0f);

        Gizmos.DrawCube(this.transform.position, new Vector3(1, 1, 1));
        Gizmos.DrawSphere(this.transform.position, 1.5f);
    }

    // 코루틴
    // 애니메이션 처리할 때 굉장히 편하다.
    IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);

        yield return new WaitForSeconds(10.0f);
    }
}

#region 05.07 과제
/*
과제 1. 
만들 게임 3가지 후보군을 추려와라... 장르는 겹치지 않게...
가장 잘 설명할 수 있는 유튜브 링크를 같이 가져올 것
리소스 생각하고 골라라, Unpack은 무조건 되니까 Unpack할 생각해라 맵이랑 파티클은 안나옴...
유니티로 만들기 좋은 게임 : FPS, SoulLike도 괜찮지만 Unity 특성상 잘 안나오긴함...
어필이 잘되는 게임 : 턴제 RPG (엔진빨을 못받긴함...)
시뮬레이터, 클릭커 게임 하지마라

과제 2.
매일매일 하라고했던 4신기는 해라
*/
#endregion