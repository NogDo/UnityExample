//#define EXAMPLE_TYPE_CLASS
#define EXAMPLE_TYPE_METHOD
//#define EXAMPLE_TYPE_PROPERTY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ŭ���� / �޼��� / ������Ƽ
/*

�� C# ��� Ŭ����

- C# Ŭ������ ���� Ÿ���̴�.
    �� ��ü�� ������ ���簡 ����Ǳ� ���ؼ��� �ݵ�� ���� ���翡 �ش��ϴ� ������ �����ؾ� �Ѵ�.

- C# Ŭ������ ��ǥ �����ڸ� ������ �� �ִ�.
    �� ��ǥ �����ڸ� ���ؼ� ��ü�� �ʱ�ȭ ������ ����ȭ ��Ű�� ���� �����ϴ�.
    �� Partial�� ����� �� ��ǥ �����ڸ� ����ϸ� Partial Ű���带 �ϳ��� �ٿ��� �ȴ�.

- C# Ŭ������ ��ø Ŭ������ �����Ѵ�.
    �� C#�� ��ø Ŭ������ C++���� �޸� �ڽ��� �����ϴ� �ܺ� Ŭ������ private �����ȿ� �����ϴ� ���� ����Ѵ�.

- C# Ŭ������ �Ҹ��ڸ� �������� �ʴ°��� ��Ģ���� �Ѵ�.
    �� ������ ���������� ������ GC�� �޸� ������ ���� ���� �� ����.

- C# Ŭ������ �θ� Ŭ������ �ǹ��ϴ� Ű���带 �����Ѵ�.
    �� Base(�⺻) - Derived(�Ļ�) Ŭ������ ��µȴ�.

- C# Ŭ������ Sealed Ű���带 ���� ��� ���θ� ������ �� �ִ�.

- C# Ŭ������ Partial Ű���带 ���� Ŭ���� ������ �����Ѵ�. (Ŭ������ ����ȭ��ų �� �ִ�.)

- C# Ŭ������ ���� ��Ӹ��� �����Ѵ�.
    �� ��, �������̽��� ���ؼ� ���� ����� �����Ѵ�.


�� C# �޼���

- C#�� �޼���� �⺻������ ���� ���� ȣ���̴�.
    �� Call By Value

- C# ��� �޼���� ref �Ǵ� out�̶�� Ű���带 ���ؼ� ������ ���� ȣ���� �ϴ� ���� �����ϴ�.
    �� Call By Reference

- C# �޼���� params Ű���带 ���ؼ� ���� ���� �Ű������� ó���� �� �ִ�.
    �� �̰Ŵ� C / C++ .... �� ����� ������ �Ѵ�. (���� ����)

- C# �޼���� ȣ��� ���� �Ѱ��� �Ű� ������ �̸��� ���� ���(ġȯ)�ϴ� ���� �����ϴ�.
    �� �̷��� ����� ���ӵ� �Ű�������� �Ѵ�.

- C# �޼���� �ڽ� Ŭ�������� �������ϱ� ���ؼ��� virtual Ű���带 �ݵ�� ������־�� �Ѵ�.
    �� ���� �ڽ� Ŭ���������� override Ű���带 ���ؼ� �θ� Ŭ������ ��� �Լ��� �������ϰ� �ִٴ� ���� ������־�� �Ѵ�.
    �� C++�� �ٸ��� override Ű���带 ������� ������ ������ ������ �߻��Ѵ�.

- C# ����� �޼��� ���� sealed Ű���带 ���ؼ� �ڽ� Ŭ�������� ��� �Լ��� �������̵� �ϴ� ���� ���� �� �ִ�.

�� �θ� Ŭ������ �޼��带 �������̵� ���� �ʰ� ������ �̸��� ���ο� �޼��带 �ڽ� Ŭ�������� �����ϱ� ���ؼ���...
    �� new�� ����ϸ� �ȴ�!


�� ref Ű����� out Ű����

- out Ű����� �ǹ������� ����� �Ѵٴ� ��
�� ������ �ۼ��� �� �߻��� �� �ִ� �ʱ�ȭ �Ǽ��� �����Ϸ� �ܰ迡�� ������ �����ϴ�.

- ref Ű����� �ݴ�� ������ �ʱ�ȭ ������ ������ ���� �ʴ´�.

- C# ���� ��쿡�� �⺻������ �ʱ�ȭ ���� ���� ���� ������ ����� �� ����.
�� �ʱ�ȭ ���� ���� ������ ����� �� ������ ������ �߻��Ѵ�.

- ���� Ư¡�� ���� ref Ű���带 �̿��ؼ� ���� ���� ������ ��� �ݵ�� �ش� ������ �ʱ�ȭ�� �Ǿ� �־�� �Ѵ�.

- �ݸ鿡 out Ű���带 �̿��� ��� �ش� Ű����� �������� ���� ���� �޼��忡�� �ݵ�� ���� �ʱ�ȭ �ȴٴ� ������ ���� �� �ֱ� ������
�ʱ�ȭ ���� ���� ������ �������� �����ϴ� �͵� �����ϴ�.



 
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
        // ���� ����
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

        SomeClass some1 = new SomeClass("����");
        SomeClass some2 = (SomeClass)some1.Clone();

        // ����
        Debug.Log(some1.m_String);
        // ���� ���� ����
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

        // Base ���� ���
        // Derived ���� ���
        // Leaf ���� ���
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
    �� ���� ���� / ���� ����
    
    - C# Ŭ������ �ᱹ ���� ����
    �� ���� ������ �ִ� ������ �� ������ �Ҵ�� ��ü�� �޸𸮸� ����Ų��.
     
    */

    //! ���� Ŭ����
    class CBase
    {
        protected int m_nValue = 0;
        protected float m_fValue = 0.0f;

        //! ������ / ��ǥ ������
        public CBase(int nValue, float fValue)
        {
            m_nValue = nValue;
            m_fValue = fValue;
        }

        public void ShowInfo()
        {
            Debug.LogFormat("���� : {0}, �Ǽ� : {1}", m_nValue, m_fValue);
        }
    }

    // ICloneable�� ����ϸ� ���� ���縦 �����Ѵ�.
    // ICloneable : C# ǥ�� (���� ���縦 �����ϱ� ���� �������̽�)
    // �������̽��� ����� ������ �ƴ϶� �����ٴ� �����̴�.
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

        //! ��ü ���� �غ�
        public object Clone()
        {
            var oDerived = new CDerived(m_nValue, m_fValue, m_oString, m_oExample);

            return oDerived;
        }

        // �޼��忡 new�� ���̸� ���Ӱ� �����ؼ� ���ڴ�.
        public new void ShowInfo()
        {
            base.ShowInfo();

            Debug.LogFormat("���ڿ� : {0}, �ܺ� Ŭ���� : {1}", m_oString, m_oExample.m_nValue);
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
            var oSomeClass = new SomeClass("���� ���� ����");

            return oSomeClass;
        }
    }


#elif EXAMPLE_TYPE_METHOD

    class CBase
    {
        public virtual void ShowInfo()
        {
            Debug.Log("Base ���� ���");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Derived ���� ���");
        }
    }

    class CLeaf : CDerived
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Leaf ���� ���");
        }
    }

    // params Ű���带 ����� ���� ���ڸ� ���� �� �ִ�.
    // params : �޼��忡�� �迭 ������ �Ű������� ���� �� ����� �� �ִ�.
    //  �� params�� ��� �������� ��Ƽ� �迭�� ����� �ִ� ���
    // ������ : params�� 1���� �迭�� �����ϸ� �޼����� �Ű����� �������� ��ġ�ؾ� �Ѵ�.
    // ������ ���� ��ȯ�ϴ� �޼���
    private int GetSumValue(params object[] a_oParams)
    {
        int nSumValue = 0;
        float fSumValue = 0.0f;

        CBase oBase = new CDerived();
        /*
        �� as / is

        - is Ű���� + as Ű����� �Ѵ� Ư�� ������ Ÿ������ ����ȯ�� �������� �˻��ϴ� ������ �����Ѵ�.


        �� ������

        - is Ű����� �� ���� ���� ���Ŀ� ��� ����� �� ������ ����� �������� ��ȯ�� �ȴ�. (T / F)

        - �ݸ� as Ű����� ���� ���Ŀ��� ����ϴ°��� �����ϸ� ����� null �Ǵ� �ش� Ÿ���� ���������� ��ȯ�� �ȴ�.
        �� �̷��� Ư�������� as Ű����� ��ü�� ������ �ٿ� ĳ������ �ϴ°��� �����ϰ� �Ѵ�.
         
        */
        CDerived oDerived = oBase as CDerived;

        if (oDerived != null)
        {
            Debug.Log("�ٿ� ĳ���ÿ� ����");
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

    // �� ���� ���
    private void SwapByValue(int a_nLhs, int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }

    // �� ���� ���۷���
    private void SwapByReference(ref int a_nLhs, ref int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }
    

#else

#endif
}