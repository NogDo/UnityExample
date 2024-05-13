using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKeyInputControl : MonoBehaviour
{
    private readonly float inputSpeedMove = 5.0f;
    private readonly float inputSpeedRotate = 40.0f;

    #region

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        InputRotate();
        InputRotateMove();
        InputIdentity();
    }

    public void InputRotate()
    {
        float AxisY = Input.GetAxis("Horizontal");

        AxisY = AxisY * inputSpeedRotate * Time.deltaTime;
        this.gameObject.transform.Rotate(new Vector3(0, AxisY, 0));
    }

    public void InputRotateMove()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * inputSpeedRotate * Time.deltaTime;
        move = move * inputSpeedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rotate);
        this.gameObject.transform.Translate(Vector3.forward * move);
    }

    void InputIdentity()
    {
        if (Input.GetMouseButton(1))
        {
            // indentity�� �ʱ�ȭ�̴�.
            this.transform.localRotation = Quaternion.identity;
        }
    }
}

#region 05.10 ����
/*
����1. Ʈ������ Ȱ��

- ���� ������ Ʈ�������� �����Ѵ�.

1. ������ Ʈ���� �����ϰ� Ʈ���� �糡���� �ڵ��� 2�밡 ���ֺ��� �޷��´�.
    �� �� ��ü�� �浹���� �� ƨ�� �����ų� �и��� ����� ���� ��Ģ�� �����Ѵ�.
    �� �ڵ����� ������ �� ������ ȸ���� �ؾ� �Ѵ�.

2. ���� ���� ������ �����ؾ� �ϰ� �����϶��� �����緯�� ȸ���� �ϸ� ��� �������� �Ѵ�.

3. ��ũ�� ���� ������ �� �� ������ ��ο� �Ϻθ� ���� ���� ȸ�� ��Ų��. (��� : ���� ȸ��)
    �� ���� �κа� ��ü �κ��� ���� ��ũó�� 360�� ȸ���� �Ű澵 ��
    �� ������ ������ �����ؾ� �Ѵ�.

4. ���� ���� �� �ֺ��� ��Ű�� ����(����)�� ����(����, �, ���� ���...)�� 3�� �����
*/
#endregion