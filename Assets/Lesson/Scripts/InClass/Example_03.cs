using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Material
/*
▶ Material(재질)

- 재질은 3D모델의 외형을 설정하기 위한 수단

- SurFace에 적용할 수 있는 미리 빌드된 비주얼 이펙트

- 머티리얼은 색상 설정부터 이미지 기반의 반사적 표현에 이르기까지 모든것을 다루며 셰이더 또한 재질에서 처리되는 경우가 많다.

- 머티리얼은 텍스쳐, 색상, 거침, 빛 등 모든 서피스 디테일을 감싸는 구조를 가지고 있다.

- 또한 스태틱 메시에 텍스쳐를 적용하거나 여러장의 텍스쳐를 포함할 수도 있다.


▶ UV (U는 X V는 Y라고 생각)

- 머티리얼이 3D 오브젝트에 적용될 때 어떻게 적용 될지에 대한 좌표계이다.

- 텍스쳐 매핑 좌표이다.

- 백분율을 가지고 있어 0.0 ~ 1.0까지 표현이 가능

- 축소시에 적용할 수 있는 다양한 렌더링 속성이 존재한다.
Warp(반복) / Clamp(비반복, 남은 부분에 대한 처리를 무조건 해줘야한다.) / Mirror(거울, 뒤집어서 다시 그리겠다.)

- 3D 좌표계로 틀어놓은 것을 큐브맵이라고 한다.

- 이미 완성된 2D 텍스쳐를 3D로 바꿔 입히겠다. 유니티의 최적화 기법


Material Insperctor

- 렌더링 모드
Opaque : 불투명 개체
Cutout : 불투명, 투명 혼합
Fade : Fade in Fade out 표현
Transparent : 투명 개체 표현

- Albedo : 컬러와 투명도를 준다

- 노말맵 : 굴곡 표현

- Height Map : 텍스쳐의 높낮이 Terrain을 표현할 때 쓴다

- Occlusion : 음영을 주는 것

- Detail Mask : 추가 텍스쳐, 여러장의 텍스쳐를 사용할 때 씀

- Emission : 빛을 방출할지 말지, 디테일 마스크가 들어가야 사용 가능

- Secondary Maps : 초고해상도 표현 4k 8k 수준

- Tiling : UV를 의미한다.

- UV Set : UV 채널을 의미한다.
 
*/
#endregion

#region 유니티 충돌체
/*

▶ 유니티 엔진의 충돌체

º 특징

- 유니티 엔진은 내부적으로 충돌 판정을 검사할때 충돌체를 기반으로 연산을 수행한다.
ㄴ 게임 오브젝트에 충돌체가 없으면 충돌 판정 검사가 불가능하다.

- 충돌체의 모양은 실제 렌더링 되는 물체의 모양과 일치하지 않아도 된다.
ㄴ 이는 일부분만 충돌 영역으로 설정하는 것을 허용한다는 뜻

- 유니티 엔진은 복합 충돌체를 지원한다.
ㄴ 자동차의 바퀴가 충돌할 경우 차 전체에 영향이 가는 것을 복합 충돌체라고함

- 그리고 대표적으로 사용되는 리지드 바디를 통해 간단한 물리 연산을 지원한다.


º 리지드바디 (강체)

- 유니티는 물리 연산이 필요할 경우 리지드 바디 컴포넌트를 포함시켜야 한다.
ㄴ 리지드 바디가 없을 경우 물리 엔진의 도움을 받을 수 없다. -> 직접 구현을 해야 한다는 얘기

- 유니티는 게임 객체에 리지드바디 컴포넌트가 포함되어 있을 경우 충돌 여부를 이벤트 형식으로 알려준다.
ㄴ 이때 콜백(컴파일러가 아닌 OS에 다이렉트로 쏘는 것) 함수 호출이 발생한다.
ㄴ void 포인터, 콜백, 델리게이트(C#), 펑셔널(C++) 등등...

- 유니티 엔진은 충돌체에 Is Trigger 옵션이 활성화 되어 있을 경우 충돌 여부가 아닌 접촉 여부를 이벤트 형식으로 알려준다.

- 마지막으로 충돌 또는 접촉 여부의 이벤트 함수를 상호작용이 발생한 객체에 리지드바디 컴포넌트가 포함되어 있을 경우에만 호출된다.


º 유니티 충돌과 트리거 관련 함수

- On 시리즈를 잘 기억하도록...

- Collider와 Collision의 차이는 물리연산은 수행하냐 마느냐의 차이이다.

OnTriggerEnter(Collider other)
OnTriggerStay(Collider other)
OnTriggerExit(Collider other)

OnCollisionEnter(Collision other)
OnCollisionStay(Collision other)
OnCollisionExit(Collision other)


▷ 충돌 여부와 접촉 여부

- 충돌 여부란 물리 엔진에 의해서 물리 상호작용을 동반하는것으로 OnCollision 계열 함수가 이벤트 형식으로 호출되며
접촉 여부는 물리 현상 배제한 단순한 접촉의 결과에 대한 판정여부만을 OnTrigger 계열 함수의 이벤트 함수로 호출이 된다.


º 주의점

- 유니티 엔진은 게임 객체에 충돌체만 포함되어 있을 경우 해당 객체를 정적 객체로 분류한다.
ㄴ 유니티에서 정적 객체는 내부적으로 퍼포먼스 향상을 위해 상태를 갱신하기 위해서는 반드시 별도의 로직이 필요하다.
ㄴ 이때 해당 정적 객체를 수동으로 트랜스폼등을 이용해서 상태를 변경했을 경우 내부적으로 이를 처리하기 위한 부하가 발생한다.

- 유니티는 게임 객체에 리지드바디 컴포넌트가 포함되어 있을 경우 해당 객체는 물리 엔진에 의해서 상태가 변경되는 것을 원칙으로 한다.
직접적으로 객체의 상태를 변경하면 내부적으로 부하가 발생한다.

- 하지만 직접적으로 상태를 변경하고 싶을 경우가 상당수 되기 때문에 이때는 Is Kinematic 옵션을 활성화해서 내부적으로 발생하는 부하를 없앨 수 있다.
단, 이 옵션이 활성화 될 경우 물리 엔진에 의한 연산 처리는 비활성화 된다.


º 보간 (Lerp)

- 두 점 사이의 중간 값에 대한 값을 예측하는 패턴 혹은 기법이라고 할 수 있다.

a. 선형 보간 (트랜스폼에 많이 사용) [공부할것]
- 시작점에서 끝 점의 거리에 대한 추정치를 구하겠다.

b. 이중 보간

c. 다항식 보간

d. 포물선 (곡선처리)

e-1. 스플라인 (곡선처리) [공부할것]

e-2. 베지어 (곡선처리)

f. 구면 보간 (애니메이션에 많이 사용) [공부할것]
- x와 y가 동일한 위치에 있을 때 사용한다.

*/
#endregion

#region 리지드바디, 피직스 머티리얼
/*
º 리지드바디 Inspector

- Mass : 질량

- Drag : 공기 질량, 저항 (안개, 탄도학에 설정한다)

- Angular Drag : 회전 공기 저항

- Use Gravity : 중력 사용 여부

- Is Kinematic : 유니티에서 제공하는 물리 연산을 사용할지 말지

- Interpolate : 움직임이 부자연스러울 때 쓰는 옵션 즉 보간이다, 사용하려면 보통 Is Kinematic이 활성화 되어 있어야함
None : 설정안함
Interpolate : 이전 움직임을 통해 보간(예측)하겠다.
Extrapolate : 다음 움직임을 통해 보간(예측)하겠다.

- Collision Detection
Discrete : 불연속 충돌 검사 (일반적)
Continuous : 동적, 정적 콜라이더를 나눠 검사, Static Mesh가 많다면 이걸 사용
Continuous Dynamic : Discrete와 Continuous의 혼합, Mesh 콜라이더의 충돌에 사용 예측을 하지 않음, 예측을 하지 않기 때문에 충돌판정 X
Continuous Speculative : Discrete와 Continuous의 혼합, Mesh 콜라이더의 충돌에 사용 예측을 한다. 예측이기 때문에 실제 충돌하지 않아도 충돌판정


º Physic Material
Dynamic Friction : 운동 마찰력
Static Friction : 정지 마찰력(버티는 힘)
Bounciness : 반동
Friction Combine : 마찰이 생겼을 때 물리에 대한 옵션
Bounce Combine : 반동이 생겼을 때 반동에 대한 옵션

*/
#endregion

public class Example_03 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}