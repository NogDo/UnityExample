using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectController : MonoBehaviour
{
    #region ��������
    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;
    #endregion

    public void Awake()
    {
        Debug.Log("������ ��... ����Ƽ");

        // 1. GetComponenet<T> Ȱ��
        // var�� auto�� ����� ��, ���� ���� �˻��̴�. ���� ���� �˻�� ������ Ÿ���� ����ϴ°� (int, float)
        // var�� ���� �����θ� ������ �ؾ��ϰ� ����� ���ÿ� �ݵ�� �ʱ�ȭ�� �����ؾ� �Ѵ�.
        var transformObject = cubeObject.GetComponent<Transform>();
        transformObject.position = new Vector3(0.0f, 5.0f, 0.0f);

        var selfTransform = gameObject.GetComponent<Transform>();
        selfTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


        // 2. ������Ƽ Ȱ��
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cubeObject.transform.position = new Vector3(0.0f, 0.0f, 5.0f);

        // 3. Find Ȱ��
        var oCubeObject = GameObject.Find("MoveCube");
        oCubeObject.AddComponent<CMoveForward>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }
}
