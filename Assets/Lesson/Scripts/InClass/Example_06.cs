//#define EXAMPLE_TYPE_STRUCTURE
//#define EXAMPLE_TYPE_ABSTRACT_CLASS
#define EXAMPLE_TYPE_INTERFACE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 구조체 / 추상 클래스 / 인터페이스
/*

▶ C# 언어 구조체의 특징

- C# 언어의 구조체는 값 형식의 데이터 타입에 속한다.
    ㄴ 스택 영역에 할당되기 때문에 시스템에 의해 메모리가 관리된다.

- C# 언어의 구조체는 생성자를 정의할 수 있지만 기본 생성자를 정의하는 것은 불가능하다.
    ㄴ 구조체에 생성자를 정의하기 위해서는 반드시 1개 이상의 매개 변수가 존재해야 한다.

- GC의 대상이 아니기 때문에 크기가 작은 Class(확장을 안하는)는 구조체로 정의하는 것이 좋다.


▶ 추상 클래스란?

- 클래스 내부적으로 순수 가상 함수를 하나 이상 포함하고 있는 클래스를 추상 클래스라고 한다.

- 그렇기때문에 이러한 추상 클래스는 자기 스스로의 객체를 만드는것이 불가능하다.

- 반면에 추상 클래스를 상속하는 하위 클래스는 객체로 만드는것이 가능하다.
    ㄴ 단, 순수 가상 함수를 자식 클래스에서 구현했을 경우에만

- 특징으로는 추상 클래스는 abstract 키워드를 통해서 추상 클래스라는 것을 명시해 줘야 한다.
    ㄴ 이 규칙은 추상 메서드에도 동일하게 적용된다.


▶ 인터페이스

- 특정 물체와의 상호작용을 일으키는 요소를 의미한다.
    ㄴ 즉, 프로그래밍에서 인터페이스는 멤버 함수 또는 클래스 함수를 의미한다.

- 또한 클래스가 수행할 수 있는 기능의 집합을 인터페이스라고 지칭한다. (여기에는 행위도 포함)
    ㄴ C# 언어는 클래스의 기능 메서드로 표현하기 때문에 메서드의 집합을 인터페이스라고 생각해도 무방하다.


º 특징

- C# 언어의 인터페이스는 멤버 함수의 집합으로 표현이 된다.
    ㄴ 멤버 변수를 정의할 수 없는 단순한 함수의 목록을 의미한다.

- 인터페이스는 접근 제어 지시자를 사용하는것이 불가하다.

- C#은 기본적으로 단일 상속만을 지원하지만 인터페이스를 활용하면 다중상속을 구현하는 것이 가능하다.
    ㄴ 이에 따라 객체지향적으로 인터페이스는 상속이라는 용어 대신에 따른다는 용어를 사용한다.

- C# 언어 인터페이스는 선언시 한정자를 명시하는 것이 불가능하다.
    ㄴ 이에 따라 범위 제어 지시자는 인터페이스를 따르는 하위 클래스에서 명시하는 것이 규칙이다.

 
*/
#endregion

[System.Serializable]
public class AClass
{
    public GameObject target;
    public float moveSpeed;
}

public class Example_06 : MonoBehaviour
{

    void Awake()
    {
#if EXAMPLE_TYPE_STRUCTURE
        STData stDataA;
        stDataA.m_nValue = 100;
        stDataA.m_oString = "Hell Fire";

        STData stDataB = new STData()
        {
            m_nValue = 10,
            m_oString = "Help Me"
        };

        Debug.LogFormat("Value : {0}, String : {1}", stDataA.m_nValue, stDataA.m_oString);
        Debug.LogFormat("Value : {0}, String : {1}", stDataB.m_nValue, stDataB.m_oString);

#elif EXAMPLE_TYPE_ABSTRACT_CLASS
        CBase oObject = new CDerived();

        oObject.ShowInfo();

#else
        CWidget oWidget = new CWidget();

        oWidget.UpdateState();
        oWidget.RenderState();

#endif
    }

    void Start()
    {

    }


    void Update()
    {

    }

#if EXAMPLE_TYPE_STRUCTURE
    struct STData
    {
        public int m_nValue;
        public string m_oString;
    }

#elif EXAMPLE_TYPE_ABSTRACT_CLASS

    abstract class CBase
    {
        public int Value
        {
            get; set;
        }

        public string String { get; set; }

        public abstract void ShowInfo();

        protected void ShowDefaultInfo()
        {
            Debug.Log("Called ShowDefaultInfo");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowDefaultInfo();
            Debug.Log("Called ShowInfo");
        }
    }

#else
    interface IUpdateable
    {
        void UpdateState();
    }

    interface IRenderable
    {
        void RenderState();
    }

    class CWidget : IUpdateable, 
                    IRenderable
    {
        public void UpdateState()
        {
            Debug.Log("Called UpdateState");
        }

        public void RenderState()
        {
            Debug.Log("Called RenderState");
        }
    }

#endif
}