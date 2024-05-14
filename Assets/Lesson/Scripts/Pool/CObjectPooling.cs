using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오브젝트 폴링
/*

★★★★★ 면접 문제 ★★★★★
▶ 오브젝트 풀링

- 유니티 최적화를 언급할때 나오는 사골


º 동작 방식

- 오브젝트를 미리 저장할 오브젝트 풀을 만들고 이곳에 빌려줄 오브젝트를 생성한다.
ㄴ 동적 / 정적

- 생성된 오브젝트는 오브젝트 풀에서 보관하고 외부에서 이 오브젝트의 콜 요청이 들어오면
오브젝트 풀에서 빌려주는 개념이라고 이해하면 좋다. (빌려준 오브젝트 사용이 끝나면 다시 오브젝트 풀에 반납)

- 예외적으로 외부에서 오브젝트 풀 안에 있는 모든 오브젝트를 다 빌려쓰고 있으면 오브젝트 풀 입장에서는
더 이상 대여해 줄 수 있는 오브젝트가 없으므로 그때서야 새로운 오브젝트를 생성한다.

- 이때 생성된 오브젝트는 사용이 끝나면 돌려 받지만 파괴되지 않고 오브젝트 풀 안에 보관이 된다.

- 이러한 사용 루틴으로 인해 오브젝트 풀링은 단순하게 오브젝트를 활성화 / 비활성화 하는 개념이다.

- Destroy()를 호출하지 않기 때문에 가비지 컬렉션을 호출하지 않아 유리하다.

- 설계를 잘못할 경우 오히려 퍼포먼스 저하를 일으킨다.

- 오브젝트 풀링은 크게 단일 / 다중으로 나눠서 관리할 수 있다.
 
*/
#endregion

#region 인스펙터 속성
/*

▶ 속성

- 스크립트에서 클래스와 속성, 또는 함수, 또는 메서드와 변수 위에 추가하여 속성에 기반한 동작을 할때 사용하는 키워드


◈ SerializeField
ㄴ 직렬화 수행 (에디터 접근 범위 설정)
ㄴ public이 아닌 비공개 멤버를 유니티가 직렬화하도록 강제하는 명령어
ㄴ 인스펙터에 노출시키는 용도

- 마샬링
ㄴ 데이터 구조 / 오브젝트 상태등을 유니티 에디터가 저장하고 나중에 제공할 수 있는 포멧으로 자동으로 변환하는 프로세스

※ 유니티에서는 저장 및 로딩 / 인스펙터 / 인스턴스 / 프리팹과 같은 일부 내장 기능에 한해 직렬화가 사용이 된다.

1. Serializable
ㄴ 유니티는 기본적으로 인스펙터에는 클래스나 구조체를 표시할 수 없다.
ㄴ 이러한 구조체나 클래스를 인스펙터로 노출시키는 속성

2. SerializeField
ㄴ private 필드를 인스펙터 창에 노출
ㄴ 다른 클래스에서 참조하진 않지만 변수를 노출시키고 싶을 때 사용 (참고)

★ 많이쓴다.
3. HideInInspector
ㄴ public 필드를 인스펙터 창에 노출시키지 않겠다.
ㄴ 다른 클래스에서 참조를 하지만 인스펙터 창에서 노출시키고 값을 변경시키지 않겠다는 것

★ 많이쓴다. (유니티의 꽃)
4. RequireComponent (typeof (Component))
ㄴ 자식 오브젝트에 컴포넌트를 붙이는 것

5. Header ("string")
ㄴ 타이틀
ㄴ 규모가 커질수록 정리는 필수

6. Multiline (int)
ㄴ 장문
ㄴ 다른 개발자들에게 경고할때 사용

7. Range (int, int) // Range (float, float)
ㄴ 인스펙터창의 슬라이드로 값을 편하게 바꿀 수 있게끔한다.
ㄴ 스크립트에서 최소값 미만 최대값 초과의 값을 가지게되면 자동으로 최소, 최대값으로 설정

8. Space (int / float)
ㄴ 인스펙터 정리용, 여백(간격)을 준다.

9. Tooltip ("string")
ㄴ 인스펙터 정리용, 마우스를 올려놨을 때 보여지는 메세지
 
*/
#endregion

public class CObjectPooling : MonoBehaviour
{
    #region 전역 변수
    int pointer;
    // List<T> Value = new List<>();
    // ㄴ 가변 배열(추가 및 삭제가 용이하다.)
    // ㄴ 같은 데이터 타입만 저장 가능하니 이는 곧 박싱과 언박싱을 수행하지 않는다는 얘기
    // 안에 까보면 C++의 스마트포인터로 작동한다.
    List<GameObject> pool;

    // 인스펙터에서 보여주고 있지만 참조는 불가능하게 만든 오브젝트
    [SerializeField]
    private GameObject pooledObejct;

    //[SerializeField, Range(0, 10)]
    //public int size = 10;
    #endregion

    void Start()
    {
        // Range(Min, Max) : 랜덤값 설정 -> 시작값은 포함 / 마지막 포함 X
        int size = Random.Range(10, 15);
        pointer = 0;
        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(pooledObejct, Vector3.zero, pooledObejct.transform.rotation);
            obj.SetActive(false);
            obj.transform.parent = transform;

            pool.Add(obj);
        }
    }

    public void SpawnObj()
    {
        if (pointer != pool.Count)
        {
            pool[pointer].SetActive(true);
            pointer++;
        }

        else
        {
            pointer = 0;
            pool[pointer].SetActive(true);
            pointer++;
        }
    }
}