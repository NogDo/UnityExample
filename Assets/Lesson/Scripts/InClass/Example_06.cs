//#define EXAMPLE_TYPE_STRUCTURE
//#define EXAMPLE_TYPE_ABSTRACT_CLASS
#define EXAMPLE_TYPE_INTERFACE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ����ü / �߻� Ŭ���� / �������̽�
/*

�� C# ��� ����ü�� Ư¡

- C# ����� ����ü�� �� ������ ������ Ÿ�Կ� ���Ѵ�.
    �� ���� ������ �Ҵ�Ǳ� ������ �ý��ۿ� ���� �޸𸮰� �����ȴ�.

- C# ����� ����ü�� �����ڸ� ������ �� ������ �⺻ �����ڸ� �����ϴ� ���� �Ұ����ϴ�.
    �� ����ü�� �����ڸ� �����ϱ� ���ؼ��� �ݵ�� 1�� �̻��� �Ű� ������ �����ؾ� �Ѵ�.

- GC�� ����� �ƴϱ� ������ ũ�Ⱑ ���� Class(Ȯ���� ���ϴ�)�� ����ü�� �����ϴ� ���� ����.


�� �߻� Ŭ������?

- Ŭ���� ���������� ���� ���� �Լ��� �ϳ� �̻� �����ϰ� �ִ� Ŭ������ �߻� Ŭ������� �Ѵ�.

- �׷��⶧���� �̷��� �߻� Ŭ������ �ڱ� �������� ��ü�� ����°��� �Ұ����ϴ�.

- �ݸ鿡 �߻� Ŭ������ ����ϴ� ���� Ŭ������ ��ü�� ����°��� �����ϴ�.
    �� ��, ���� ���� �Լ��� �ڽ� Ŭ�������� �������� ��쿡��

- Ư¡���δ� �߻� Ŭ������ abstract Ű���带 ���ؼ� �߻� Ŭ������� ���� ����� ��� �Ѵ�.
    �� �� ��Ģ�� �߻� �޼��忡�� �����ϰ� ����ȴ�.


�� �������̽�

- Ư�� ��ü���� ��ȣ�ۿ��� ����Ű�� ��Ҹ� �ǹ��Ѵ�.
    �� ��, ���α׷��ֿ��� �������̽��� ��� �Լ� �Ǵ� Ŭ���� �Լ��� �ǹ��Ѵ�.

- ���� Ŭ������ ������ �� �ִ� ����� ������ �������̽���� ��Ī�Ѵ�. (���⿡�� ������ ����)
    �� C# ���� Ŭ������ ��� �޼���� ǥ���ϱ� ������ �޼����� ������ �������̽���� �����ص� �����ϴ�.


�� Ư¡

- C# ����� �������̽��� ��� �Լ��� �������� ǥ���� �ȴ�.
    �� ��� ������ ������ �� ���� �ܼ��� �Լ��� ����� �ǹ��Ѵ�.

- �������̽��� ���� ���� �����ڸ� ����ϴ°��� �Ұ��ϴ�.

- C#�� �⺻������ ���� ��Ӹ��� ���������� �������̽��� Ȱ���ϸ� ���߻���� �����ϴ� ���� �����ϴ�.
    �� �̿� ���� ��ü���������� �������̽��� ����̶�� ��� ��ſ� �����ٴ� �� ����Ѵ�.

- C# ��� �������̽��� ����� �����ڸ� ����ϴ� ���� �Ұ����ϴ�.
    �� �̿� ���� ���� ���� �����ڴ� �������̽��� ������ ���� Ŭ�������� ����ϴ� ���� ��Ģ�̴�.

 
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