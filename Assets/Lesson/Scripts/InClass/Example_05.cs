//#define EXAMPLE_TYPE_CLASS
#define EXAMPLE_TYPE_METHOD
//#define EXAMPLE_TYPE_PROPERTY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 클래스 / 메서드 / 프로퍼티
/*

▶ C# 언어 클래스

- C# 클래스는 참조 타입이다.
    ㄴ 객체의 완전한 복사가 수행되기 위해서는 반드시 깊은 복사에 해당하는 로직을 구현해야 한다.

- C# 클래스는 대표 생성자를 정의할 수 있다.
    ㄴ 대표 생성자를 통해서 객체의 초기화 로직을 통일화 시키는 것이 가능하다.
    ㄴ Partial을 사용할 때 대표 생성자를 사용하면 Partial 키워드를 하나만 붙여도 된다.

- C# 클래스는 중첩 클래스를 지원한다.
    ㄴ C#의 중첩 클래스는 C++과는 달리 자신을 포함하는 외부 클래스의 private 영역안에 접근하는 것을 허용한다.

- C# 클래스는 소멸자를 구현하지 않는것을 원칙으로 한다.
    ㄴ 구현은 가능하지만 구현시 GC의 메모리 관리를 전혀 받을 수 없다.

- C# 클래스는 부모 클래스를 의미하는 키워드를 지원한다.
    ㄴ Base(기본) - Derived(파생) 클래스가 계승된다.

- C# 클래스는 Sealed 키워드를 통해 상속 여부를 결정할 수 있다.

- C# 클래스는 Partial 키워드를 통해 클래스 분할을 지원한다. (클래스를 파편화시킬 수 있다.)

- C# 클래스는 단일 상속만을 지원한다.
    ㄴ 단, 인터페이스에 한해서 다중 상속을 지원한다.


▶ C# 메서드

- C#의 메서드는 기본적으로 값에 의한 호출이다.
    ㄴ Call By Value

- C# 언어 메서드는 ref 또는 out이라는 키워드를 통해서 참조에 의한 호출을 하는 것이 가능하다.
    ㄴ Call By Reference

- C# 메서드는 params 키워드를 통해서 가변 길이 매개변수를 처리할 수 있다.
    ㄴ 이거는 C / C++ .... 과 비슷한 역할을 한다. (가변 인자)

- C# 메서드는 호출시 값이 넘겨질 매개 변수의 이름을 직접 명시(치환)하는 것이 가능하다.
    ㄴ 이러한 기능을 네임드 매개변수라고 한다.

- C# 메서드는 자식 클래스에서 재정의하기 위해서는 virtual 키워드를 반드시 명시해주어야 한다.
    ㄴ 또한 자식 클래스에서는 override 키워드를 통해서 부모 클래스의 멤버 함수를 재정의하고 있다는 것을 명시해주어야 한다.
    ㄴ C++과 다르게 override 키워드를 명시하지 않으면 컴파일 에러가 발생한다.

- C# 언어의 메서드 또한 sealed 키워드를 통해서 자식 클래스에서 멤버 함수를 오버라이드 하는 것을 막을 수 있다.

※ 부모 클래스의 메서드를 오버라이드 하지 않고 동일한 이름의 새로운 메서드를 자식 클래스에서 정의하기 위해서는...
    ㄴ new를 사용하면 된다!


º ref 키워드와 out 키워드

- out 키워드는 의미적으로 출력을 한다는 뜻
ㄴ 로직을 작성할 때 발생할 수 있는 초기화 실수를 컴파일러 단계에서 예방이 가능하다.

- ref 키워드는 반대로 변수의 초기화 유무를 보장해 주지 않는다.

- C# 같은 경우에는 기본적으로 초기화 되지 않은 지역 변수는 사용할 수 없다.
ㄴ 초기화 되지 않은 변수를 사용할 때 컴파일 에러가 발생한다.

- 위에 특징에 따라 ref 키워드를 이용해서 참조 값을 전달할 경우 반드시 해당 변수는 초기화가 되어 있어야 한다.

- 반면에 out 키워드를 이용할 경우 해당 키워드는 참조값을 전달 받은 메서드에서 반드시 값이 초기화 된다는 보장을 받을 수 있기 때문에
초기화 되지 않은 변수의 참조값을 전달하는 것도 가능하다.



 
*/
#endregion

public class Example_05 : MonoBehaviour
{
    private int m_nValue = 100;

    public void Awake()
    {
#if EXAMPLE_TYPE_CLASS
        var DerivedA = new CDerived("HellFire", this);
        var DerivedB = new CDerived(10, 3.14f, "Hello", this);
        // 깊은 복사
        var DerivedC = (CDerived)DerivedB.Clone();

        // 0 / 0.0f
        // HellFire / 100
        DerivedA.ShowInfo();
        
        // 10 / 3.14f
        // Hello / 100
        DerivedB.ShowInfo();

        // 10 / 3.14f
        // Hello / 100
        DerivedC.ShowInfo();

        SomeClass some1 = new SomeClass("원본");
        SomeClass some2 = (SomeClass)some1.Clone();

        // 원본
        Debug.Log(some1.m_String);
        // 깊은 복사 수행
        Debug.Log(some2.m_String);

#elif EXAMPLE_TYPE_METHOD

        int nLhs = 10;
        int nRhs = 20;

        // 10 20
        SwapByValue(nLhs, nRhs);
        Debug.LogFormat("Lhs : {0}, Rhs : {1}", nLhs, nRhs);

        // 20 10
        SwapByReference(ref nLhs, ref nRhs);
        Debug.LogFormat("Lhs : {0}, Rhs : {1}", nLhs, nRhs);


        int nValueA;
        int nValueB;

        // 10 20
        this.InitValue(out nValueA, out nValueB);
        Debug.LogFormat("Lhs : {0}, Rhs : {1}", nValueA, nValueB);


        CBase oBase = new CLeaf();

        // Base 정보 출력
        // Derived 정보 출력
        // Leaf 정보 출력
        oBase.ShowInfo();


        int nSumValueA = this.GetSumValue(1, 2, 3, 4, 5, 1.0f, 2.0f, 3.0f, 4.0f);
        int nSumValueB = this.GetSumValue(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        // 15, 55
        Debug.LogFormat("SumValueA : {0}, SumValueB : {1}", nSumValueA, nSumValueB);

#else

#endif
    }

#if EXAMPLE_TYPE_CLASS

    /*
    º 얕은 복사 / 깊은 복사
    
    - C# 클래스는 결국 참조 형식
    ㄴ 스택 영역에 있는 참조가 힙 영역에 할당된 객체의 메모리를 가르킨다.
     
    */

    //! 기초 클래스
    class CBase
    {
        protected int m_nValue = 0;
        protected float m_fValue = 0.0f;

        //! 생성자 / 대표 생성자
        public CBase(int nValue, float fValue)
        {
            m_nValue = nValue;
            m_fValue = fValue;
        }

        public void ShowInfo()
        {
            Debug.LogFormat("정수 : {0}, 실수 : {1}", m_nValue, m_fValue);
        }
    }

    // ICloneable을 사용하면 깊은 복사를 수행한다.
    // ICloneable : C# 표준 (깊은 복사를 수행하기 위한 인터페이스)
    // 인터페이스는 상속의 개념이 아니라 따른다는 개념이다.
    class CDerived : CBase, System.ICloneable
    {
        private string m_oString = "";
        private Example_05 m_oExample = null;

        public CDerived(string a_oString, Example_05 a_oExample)
            :
            this(0, 0.0f, a_oString, a_oExample)
        {

        }

        public CDerived(int a_nValue, float a_fValue, string a_oString, Example_05 a_oExample)
            :
            base(a_nValue, a_fValue)
        {
            m_oString = a_oString;
            m_oExample = a_oExample;
        }

        //! 객체 복사 준비
        public object Clone()
        {
            var oDerived = new CDerived(m_nValue, m_fValue, m_oString, m_oExample);

            return oDerived;
        }

        // 메서드에 new를 붙이면 새롭게 정의해서 쓰겠다.
        public new void ShowInfo()
        {
            base.ShowInfo();

            Debug.LogFormat("문자열 : {0}, 외부 클래스 : {1}", m_oString, m_oExample.m_nValue);
        }
    }

    class SomeClass : System.ICloneable
    {
        public string m_String;

        public SomeClass(string str)
        {
            m_String = str;
        }

        public object Clone()
        {
            var oSomeClass = new SomeClass("깊은 복사 수행");

            return oSomeClass;
        }
    }


#elif EXAMPLE_TYPE_METHOD

    class CBase
    {
        public virtual void ShowInfo()
        {
            Debug.Log("Base 정보 출력");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Derived 정보 출력");
        }
    }

    class CLeaf : CDerived
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Leaf 정보 출력");
        }
    }

    // params 키워드를 사용해 가변 인자를 받을 수 있다.
    // params : 메서드에서 배열 형태의 매개변수를 받을 때 사용할 수 있다.
    //  ㄴ params는 모든 변수들을 모아서 배열로 만들어 주는 기능
    // 주의점 : params는 1차원 배열만 가능하며 메서드의 매개변수 마지막에 위치해야 한다.
    // 정수의 합을 반환하는 메서드
    private int GetSumValue(params object[] a_oParams)
    {
        int nSumValue = 0;
        float fSumValue = 0.0f;

        CBase oBase = new CDerived();
        /*
        ▶ as / is

        - is 키워드 + as 키워드는 둘다 특정 데이터 타입으로 형변환이 가능한지 검사하는 역할을 수행한다.


        º 차이점

        - is 키워드는 값 형식 참조 형식에 모두 사용할 수 있으며 결과는 논리형으로 반환이 된다. (T / F)

        - 반면 as 키워드는 참조 형식에만 사용하는것이 가능하며 결과는 null 또는 해당 타입의 참조값으로 반환이 된다.
        ㄴ 이러한 특성때문에 as 키워드는 객체의 안전한 다운 캐스팅을 하는것을 가능하게 한다.
         
        */
        CDerived oDerived = oBase as CDerived;

        if (oDerived != null)
        {
            Debug.Log("다운 캐스팅에 성공");
        }

        for (int i = 0; i < a_oParams.Length; ++i)
        {
            if (a_oParams[i] is int)
            {
                nSumValue += (int)a_oParams[i];
            }

            else
            {
                fSumValue += (float)a_oParams[i];
            }
        }

        return nSumValue;
    }

    private void InitValue(out int a_nValueA, out int a_nValueB)
    {
        a_nValueA = 10;
        a_nValueB = 20;
    }

    // 콜 바이 밸류
    private void SwapByValue(int a_nLhs, int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }

    // 콜 바이 레퍼런스
    private void SwapByReference(ref int a_nLhs, ref int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }
    

#else

#endif
}