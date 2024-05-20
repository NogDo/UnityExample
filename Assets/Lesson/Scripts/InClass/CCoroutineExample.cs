using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region �ڷ�ƾ
/*

�� �ڷ�ƾ (Coroutine)

- Co + routine (Corporate Routine)

- ���� �ð� ������ �ΰ� �Լ��� ȣ���Ҷ� ����Ѵ�.
�� �ڷ�ƾ�� �����Ӱ� ������� ������ ���� ��ƾ���� ���ϴ� �۾��� ���ϴ� �ð���ŭ �����ϴ°��� �����ϴ�.

- �ڷ�ƾ�� �������� ���� ��ƾ�� �����Ѵٰ� �ؼ� ������� ���ٰ� ������ �ϴµ� �ڷ�ƾ�� "�񵿱�(ȣ�� ��)", ������� "����(���� ��ٸ��� ��)"

- �񵿱�� ���� �� ���� �ϸ鼭 ȣ���ϸ� ���� ��, ����� ���� ���� ��ٸ��� ��

- ������� �ڷ�ƾ�� ���� ū ������
�� �������� ��� lock�� �ɾ� �켱 ����ȭ�� ������� �ϴ� �ݸ鿡 �ڷ�ƾ�� lock�� ���� �ʴ´�.

- ������� Context Switching�� �����Ѵ�. (�����带 ������ ���� �ѹ��� ����)

- ������� ������ ���� ���������� ȣ�� ������ ������ �ֱ� ������ �Ȱ��� �����带 ������ �� �ִ�.
�� ���� ȣ���� �� �Ŀ��� Critical Section�� �Ǿ �ٸ� �������� lock�� �ɷ� ������� �ʴ´�.

- �޸� ��뷮�� ���ٴ� ������ �ִ�.
�� �÷����̱� ������


�� �ڷ�ƾ�� ����ؾ� �ϴ� ����?

- �ڷ�ƾ�� �׻� ����Ǵ� ���� �ƴ϶� Ư�� ��Ȳ���� ȣ���ϰ� �ݺ� �۾��� �ϴ°� ���������� �����ϴ�.

- �̷��� ������ �� ������ ����Ǵ� Update ���� Ư�� ��Ȳ���� ���� ���� + ȿ�����̴�.
�� ���� ����


�� ���������� �ڷ�ƾ...

- ����? �� �ȵȴ�.

- �ڷ�ƾ�� ���� ��Ȳ�� �Ź� ������ üũ�ؾ� �Ҷ�?

- ���ǹ��� ���̰� ������?

- �Լ� + �޼����� ���� ���̰� ������?

- ���� �߿� �ϳ��� �����ϸ� �ڷ�ƾ�� �������


�� ���

- ��� �ð����� ���� �ð��� ���� ��쿡�� �ڷ�ƾ�� ���� ������ �ƴϴ�.

- Ư�� ���ǿ� ���� �Ͻ������� ����Ǵ� ��쳪 �ð��� �帧��� ������ �� �ڷ�ƾ�� ����ϸ� ���� ����.


�� �Լ� ����

IEnumerator Coroutine()
{
    yield return type;
}


�� IEnumerable

- C++ �ݺ��ڿ� ����ϰ� ����ϱ� ���� C#�� �ݺ��� ����

- �÷����� �ϳ��̸� �ݺ������� ��ü�� �Ѱ��� �Ѱ��ִ� ������ �����Ѵ�.
�� C# -> �����̳� -> foreach


�� STL or ������
C++                  C#
Vector / List   ArrayList(��õ) / List(��õ)
Map             Dictionary(��õ) / Hashtable(���迡�� ������ ���̵��� �־� �������� �ʴ´�.)
Pair            KeyValuePair

�� C#������ 5�� �� 3�� ������ �� �� �˾ƾ� �Ѵ�.


�� IEnumerator

- ������ (�÷��� �� �ϳ��̸� �����Ϳ� ����� ������ �Ѵ�.)

- IEnumerator�� �⺻������ Enumerator�� ������ �־�� �� �޼������ ��� �ִ� �������̽�

- Movenext() �޼��尡 ����ǰ�, false�� ��� �����Ѵ�.


�� ����� �غ��ô�....

- IEnumerable�� n+1 / n+2 / n+3 �̶�� ������ �����͸� �Ѱ��ش�.

- �̶� �߿��Ѱ� �Ѱ��ִ� ���� ���° �����͸� �Ѱ������ ����� �ϰ� �־�� �Ѵ�.
�� Request�� ��û�� ���� ���� �����͸� ������� ���ϱ� ������ IEnumerable�� ����ؾ� �Ѵ�.

EX)
����
IEnumerable -> ���� ������ ����. 

����
                ���� ������ ����.
                ���� ������ ����.
                ���� ������ ����.
IEnumerable ->  ���� ������ ����.
                ���� ������ ����.
                ���� ������ ����.
                ���� ������ ����.


                IEnumerator(n+1)  ->  ���� ������ ����.
                IEnumerator(n+2)  ->  ���� ������ ����.
                IEnumerator(n+3)  ->  ���� ������ ����.
IEnumerable ->  IEnumerator(n+4)  ->  ���� ������ ����.
                IEnumerator(n+5)  ->  ���� ������ ����.
                IEnumerator(n+6)  ->  ���� ������ ����.
                IEnumerator(n+7)  ->  ���� ������ ����.


�� �ڷ�ƾ �Ӽ� ��

- yield return�� ������ ������ ���� �����ӿ��� ������ �簳�� ����

IEnumerator Coroutine()
{
    yield return new WaitForSeconds()

    yield return null (�������� ���� ����; �ִϸ��̼� �������)
    �� ���� ������Ʈ���� ��� (������)

    yield return new WaitForFixedUpdate()
    �� ���� ���� ������Ʈ���� ���

    yield return new WaitForEndOfFrame() (���� ����; �ε�, ��� ��ȯ�� ����.)
    �� �������� ���������� ���

    yield return StartCoroutine(String)
    �� �ȿ� ���� �ٸ� �ڷ�ƾ�� ���������� ���

    yield return WWW(String)
    �� �� ��� �۾��� ���������� ���

    yield return new AsyncOperation
    �� �񵿱� �۾��� ���������� ��� (�� �ε�)

    yield break
    �� ������ �Ϸ�Ǳ� ������ ���Ƿ� �ڷ�ƾ�� ����
}

�� yield return�� ��ø�Ǹ�...

- �ڷ�ƾ�� ���� ȣ��ǰ� �ٽ� �ѹ� while���� ����Ǹ� ���� �������� �ִ� ���Ϲ��� �Ͼ�� ��ġ�� ������ ���� ������ �簳�ϴ� ������ ������ �ִ�.

- ������ �簳�Ǹ� } or yield ���� ������������ �ݺ��ؼ� �ڵ带 �о���δ�.

*/
#endregion

public class CCoroutineExample : MonoBehaviour
{
    private IEnumerator coroutine;

    // Invoke : �޼��带 �����ð���ŭ �����Ҷ� ����Ѵ�.
    // �� Repeating / Cancel / Cancel(String)
    private float Delay = 2.0f;

    // Start�� �ڷ�ƾ�� ������ ��쿡�� �⺻������ Invoke ���� ����� �غ��� �Ѵ�.
    void Start()
    {
        coroutine = PrintCount(2.0f);
        StartCoroutine(coroutine);

        InvokeRepeating("InvokeSample", 5.0f, Delay);
    }

    void Update()
    {
        // 1. this�� ������ ���
        CoroutineSample();

        // 2. ������ ������ ���
        if (Input.GetKeyDown("c"))
        {
            // StopCoroutine(IEnumerator) / StopCoroutine(string methodName) / StopAllCoroutine()
            // �ش� IEnumerator�� ���ش�
            StopCoroutine(coroutine);
            // �ش� IEnumerable���� ���ش�.
            StopCoroutine("PrintCount");
            // �ش� ��ũ��Ʈ�� �ڷ�ƾ�� ���ش�.
            StopAllCoroutines();

            Debug.Log("���� : " + Time.time);

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

    // IEnumerator <T>�� �����Ѵ�.
    // ��ü �ϳ��� �ƴ� ���� ��ü�� �ްڴٴ� ��
    // �̸� ����ϱ� ���ؼ��� ���谡 �ʿ��ϴ� (Ȯ�� �޼���)
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



#region 05.17 ����
/*
����1. ������Ʈ�� ���� ��ȹ�� �ۼ�

- ���� : ������ ������ ����������


�ɷ´��� ��

- ���Ϸ� ����

- ����� �� ��Ų��.

- ���� ����(���) : VR 7��_�����÷��� ���� ���α׷���_�̸�

- ÷�� ����
�� VR 7��_�����÷��� ���� ���α׷���_�̸�.zip
    �� 1. ������Ʈ 2. �������� ĸó (���� �÷��� ȭ�� 3��)
                        �� 01 / 02 / 03
�� VR 7��_���Ӹ�_�̸�.ppt

- ���� ���� : Ư�̻��� ����


�� �ɷ´��� �� ����

- �۾� ���ü� ��� ������Ʈ�� �ϼ��ϰ� �����Ͻÿ�.

1. �÷��� ����� ����� ������ ������ ����

2. PC�÷����� ���� ������ ��

3. ���� ���ӿ� ������ �ڷᱸ���� �˰����� ��� �� ��

4. ȿ������ �޸� ���� ����� ������ �� (������Ʈ Ǯ)

5. ���� �� ������ �߻� �� ������� ���� ���� �� ��


*/
#endregion