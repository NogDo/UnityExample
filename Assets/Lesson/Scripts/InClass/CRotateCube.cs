using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ȸ��
/*

�� Ʈ������ (ȸ��)

- ������ ����ؾ� �� 4����

1. transform.Rotate
    �� ������Ʈ ȸ��

2. transform.RotateAround
    �� ���� ������Ʈ�� ���鼭 ȸ��

�ڡڡ� ���� ���� �ڡڡ�
3. Quaternion
    �� ���Ҽ� / ����� -> (������ ������ �ذ��ϱ����� ���Ե� ����)
        �� (x, y, z, w)
    �� 3���� �� �̿ܿ��� �߰��� ��Į�� �ִ�
    �� �� �ೢ�� �����Ű�� �ʰ� �������̴�.
    �� ȸ���� �ϱ� ���ؼ� ��� ���� ������ �ϱ� ������ ���귮�� ����.

�ڡڡ� ���� ���� �ڡڡ�
4. EulerAngles
    �� ���Ϸ��� ���� ����������� �ೢ�� ������ �Ǿ� �ִ�.
    �� ȸ���� �ϴٺ��� �ʿ������� �ೢ�� ��ġ�� ������ �߻��ϴµ� �ೢ�� ����Ǿ� �ֱ� ������ �� ���� �������� ����ϰ� �ȴ�.
    �� Quaternion�� ���� ���귮�� �е������� ���ٴ� ������ �ִ�.
    �� ���� ���� (Roll Pitch Yaw; RPY(XYZ)�� �������)
        �� ȸ���� ���� �������� ���� ȸ���� �Ѵٴ� ���� ���� �������� �������� �߻� ��Ų��.

�� ������ (Gimbal Lock) : x, y, z ������ ȸ���� �Ѵٰ� ������ �ϸ� y�� ȸ���� ���� ������ x������ ȸ���ߴ� ��� 
z���� �������� ���� -> ������ ��߳���.

*/
#endregion


public class CRotateCube : MonoBehaviour
{
    #region ��������
    public GameObject target = null;
    #endregion

    void Start()
    {
        //RotateSample_01();
    }

    void Update()
    {
        //RotateSample_02();
        RotateAroundSample();
    }

    void RotateSample_01()
    {
        // ���ڸ� ȸ��

        // 1. eulerAngles : ���� �������� ������ŭ ȸ�� (�⺻������ ������ �����Ǿ� �ִ�.)
        this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // 2. ���� ������ �ǹ��Ѵ�.
        // �� ���ڷ� ���� ������ ���Ϸ� ���� ���ʹϾ����� ��ȯ -> �Ķ���Ϳ��� �ַ� �Ǽ� / ���� ���� ���´�.
        // Quaternion ������Ƽ �������� �����ϱ� ������ �ܵ����� ����� �� ����.
        Quaternion target = Quaternion.Euler(45.0f, 45.0f, 45.0f);  
        this.transform.rotation = target;

        // 3. Rotate
        // Rotate vs rotation ����
        // �� Rotate : ���Ӽ�
        // �� rotation : �ܹ߼�
        // �� Rotate(ȸ���� ��� ��ǥ �� * ��Ÿ Ÿ�� * (ȸ�� �ӵ�) * (������))
        this.transform.Rotate(Vector3.up * 60.0f);
    }

    void RotateSample_02()
    {
        // AngleAxis : �� ������ Angle��ŭ ȸ���� �����̼��� �����ϰ� ��ȯ�Ѵ�.
        // �߽� ���� �Ǵ� axis�� y���� ��� y�࿡ ���� ȸ������ ������ �ʰ� x, z�� ���� ���Ѵ�.

        this.transform.rotation *= Quaternion.AngleAxis(1.5f, Vector3.up);
    }

    void RotateAroundSample()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 40 * Time.deltaTime);
    }
}
