using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveCube : MonoBehaviour
{
    #region ��������
    public GameObject cubeObject = null;
    public float moveSpeed = 5.0f;
    #endregion

    // Ÿ ������Ʈ�ʹ� ���������� �����ϴ� ��ü
    void Start()
    {
        //MoveSample_01();
    }

    void Update()
    {
        //MoveSample_02();
        MoveSample_03();
        CubeJump();
    }

    void MoveSample_01()
    {
        // ���� ��ǥ��
        transform.position = new Vector3(0.0f, 5.0f, 0.0f);

        // ���� ��ǥ��
        // ���� ��ǥ�踦 ����ϱ� ������ ������Ʈ�� ȸ���� �������� ������� �޶��� �� �ִ�.
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
    }

    void MoveSample_02()
    {
        // ���� ��ǥ��
        float moveDelta = moveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;

        pos.z += moveDelta;
        this.transform.position = pos;


        // ���� ��ǥ��
        // Translate���� t�� �ҹ��ڸ� UI���� �빮�ڸ� ����
        moveDelta = moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);


        // ����Ƽ������ ����ȭ ���͸� �����Ѵ�.
        // ���ʹ� ũ��� ������ ���� ������ Ÿ���̴�.
        // �� ����ȭ ���͵��� Ư¡�� ��� ��ֶ���� �Ǿ� �ִ� -> �븻����� �Ǿ� �ִٴ� �� -> �̰� �ٷ� ������ ����ȭ�� ���Ѵ�. (���� ����)
        // �� ���� ���� : Vector3(1, 1, 1)
        // ��ü�� �����Ͽ� ���� ������� �޶����� ������ ����ȭ�� ���͸� ����ؾ��Ѵ�.
        // ���� ������ �ִ밪�� 1�̴�.
        // ����ȭ�� ���͸� ����ؾ��ϴ� ������ ������ ��ø���� ������ �밢�� �̵����� �� ���� ���� �̵��ϱ� �����̴�.


        /*
        Vector3(1, 0, 0)        ->  Vector3.right
        Vector3(-1, 0, 0)       ->  Vector3.left

        Vector3(0, 1, 0)        ->  Vector3.up
        Vector3(0, -1, 0)       ->  Vector3.down

        Vector3(0, 0, 1)        ->  Vector3.forward
        Vector3(0, 0, -1)       ->  Vector3.back

        Vector3(0, 0, 0)        ->  Vector3.zero (�������� �̵����� �ʰڴ�)
        Vector3(1, 1, 1)        ->  Vector3.one (�������� ���ÿ� �̵��ϰڴ�)

        ���� Ŭ���� ���
        Vector3.Dot(A, B)       ->  ������ �������� ���Ѵ�. ���� ã�ƺ� ��
        Vector3.Cross(A, B)     ->  ������ �������� ���Ѵ�. ���� ã�ƺ� ��
        Vector3.Distance        ->  ������ �Ÿ����̸� ���Ѵ�. (A�� B)
        Vector3.Angle           ->  ������ �������̸� ���Ѵ�. (Degree) �ﰢ�Լ� ã�ƺ� ��

        �ν��Ͻ� ���
        Vector3.Normalize()     ->  �������� ����ڴ�.
        Vector3.Magnitude()     ->  ������ ���̸� �˷��ִ� ������Ƽ
        Vector3.SqrMagnitude()  ->  ������ ���� ������ �˷��ִ� ������Ƽ -> ������.
        */
    }

    void MoveSample_03()
    {
        var cubePosition = cubeObject.transform.position;

        /*
        GetAxis / GetAxisRaw

        - �Ѱܹ޴� �Ű� ������ ���ڿ��� ���ؼ� Ű���峪 ���̽�ƽ�� �Է� ���� -1 ~ +1 ������ ������ ��ȯ

        - ���� ���̴� �ﰢ���� ������ �ε巯�� ������ ���̰� �ִ�.

        GetAxis : �ε巯�� ����, �Ǽ��� ���� ��ȯ�Ѵ�.
        GetAxisRaw : �ﰢ���� ����, ������ ���� ��ȯ�Ѵ�.

        */

        // 1. GetAxis�� ���� ���
        float fDeltaX = Input.GetAxisRaw("Horizontal");
        float fDeltaZ = Input.GetAxisRaw("Vertical");

        Debug.LogFormat("DeltaX : {0}", fDeltaX);

        cubePosition.x += fDeltaX * moveSpeed * Time.deltaTime;
        cubePosition.z += fDeltaZ * moveSpeed * Time.deltaTime;

        //cubeObject.transform.Translate(fDeltaX * moveSpeed * Time.deltaTime, 0.0f, fDeltaZ * moveSpeed * Time.deltaTime);


        // 2. GetKey�� ���� ���
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cubePosition.x -= moveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cubePosition.x += moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            cubePosition.z += moveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cubePosition.z -= moveSpeed * Time.deltaTime;
        }

        cubeObject.transform.position = cubePosition;
    }

    void CubeJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 0.5f, 0.0f);
            velocity = velocity * power;
            this.GetComponent<Rigidbody>().velocity = velocity;
        }

        if (Input.GetMouseButton(1))
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 2.0f, 0.0f);
            velocity = velocity * power;
            // �ܺ��� ���� ������Ű�� ��
            this.GetComponent<Rigidbody>().AddForce(velocity);
        }
    }
}