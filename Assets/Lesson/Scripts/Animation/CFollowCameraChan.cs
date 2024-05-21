using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶�� transform�� rotation�� ���� ���� ������ �˰��� + ���� �����
public class CFollowCameraChan : MonoBehaviour
{
    #region public ����
    public float gravity = 10.0f;
    public float runSpeed = 5.0f;
    public float mouseSensitivity = 0.5f;
    #endregion

    Transform oTransform;
    Transform unityChanModel;
    Transform cameraTransform;
    Transform cameraParentTrasform;
    CharacterController chanController;
    Animator chanAnimator;

    Vector3 move;
    Vector3 mouseMove;

    void Awake()
    {
        oTransform = transform;
        unityChanModel = transform.GetChild(0);
        cameraTransform = Camera.main.transform;
        cameraParentTrasform = cameraTransform.parent;
        chanController = GetComponent<CharacterController>();
        chanAnimator = unityChanModel.GetComponent<Animator>();
    }

    void Update()
    {
        Balance();
        CameraDistanceControl();

        if (chanController.isGrounded)
        {
            GroundChecking();
            MoveUnityChan(1.0f);
        }

        else
        {
            move.y -= gravity * Time.deltaTime;
            MoveUnityChan(0.01f);
        }

        chanController.Move(move * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chanAnimator.SetTrigger("aJump");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            chanAnimator.SetTrigger("aAttack");
        }
    }

    void LateUpdate()
    {
        // Fix
        cameraParentTrasform.position = oTransform.position + Vector3.up * 0.7f;

        // ���콺�� �������� ����
        mouseMove += new Vector3
            (
            -Input.GetAxisRaw("Mouse Y") * mouseSensitivity,
            Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            0
            );

        // ���� ����
        if (mouseMove.x < -5)
        {
            mouseMove.x = -5;
        }

        else if (50 < mouseMove.x)
        {
            mouseMove.x = 50;
        }

        cameraParentTrasform.localEulerAngles = mouseMove;
    }

    // �ܺ� �������� / ���������� ���� ī�޶� �������� �ٷ� ��� ����
    void Balance()
    {
        if (oTransform.eulerAngles.x != 0 || oTransform.eulerAngles.z != 0)
        {
            oTransform.eulerAngles = new Vector3(0, oTransform.eulerAngles.y, 0);
        }
    }

    void CameraDistanceControl()
    {
        // �ٷ� ī�޶��� �Ÿ��� ����
        Camera.main.transform.localPosition += new Vector3(0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * 2.0f);

        // if�� ���ǽĿ� ���� ���׿� ���� ����ӵ� ���̰� �ִ�.
        // �ִ�� ����� ��ġ
        if (-2 < Camera.main.transform.localPosition.z)
        {
            Camera.main.transform.localPosition = new Vector3
                (
                Camera.main.transform.localPosition.x,
                Camera.main.transform.localPosition.y,
                -2
                );
        }

        // �ּҷ� ����� ��ġ
        else if (Camera.main.transform.localPosition.z < -5)
        {
            Camera.main.transform.localPosition = new Vector3
                (
                Camera.main.transform.localPosition.x,
                Camera.main.transform.localPosition.y,
                -5
                );
        }
    }

    void MoveUnityChan(float rate)
    {
        float tempMoveY = move.y;

        // y�� �ʿ���� ������ ��� �����ϰ� ���д�.
        move.y = 0;

        Vector3 inputMoveXZ = new Vector3
            (
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );


        // �밢�� �̵� -> 2���� �ӵ� -> �ӵ��� 1�̻� �ö󰡸� -> �븻������ -> �׻� ������ �ӵ��� ���� �� �ְ� ó��
        float inputMoveXZMagnitude = inputMoveXZ.sqrMagnitude;

        inputMoveXZ = oTransform.TransformDirection(inputMoveXZ);

        if (inputMoveXZMagnitude <= 1)
        {
            inputMoveXZ *= runSpeed;
        }

        else
        {
            inputMoveXZ = inputMoveXZ.normalized * runSpeed;
        }


        // �����߿��� ī�޶��� ���⿡ ��������� ĳ���Ͱ� �����̴� ó���� �ؾ� �Ѵ�.
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Quaternion cameraRotation = cameraParentTrasform.rotation;

            // ī�޶�� ���� �ุ �ʿ��ұ� y�ุ �ʿ�
            cameraRotation.x = cameraRotation.z = 0;

            oTransform.rotation = Quaternion.Slerp
                (
                oTransform.rotation,
                cameraRotation,
                10.0f * Time.deltaTime
                );


            // Quaternion�� 3�� �� ����� ���� 0�̶�� ������ ����.
            // ���� 0, 0, 0�� ���� ����ó���� ���־�� �Ѵ�.
            if (move != Vector3.zero)
            {
                Quaternion characterRotation = Quaternion.LookRotation(move);

                characterRotation.x = characterRotation.z = 0;

                unityChanModel.rotation = Quaternion.Slerp
                    (
                    unityChanModel.rotation,
                    characterRotation,
                    10.0f * Time.deltaTime
                    );
            }

            // �Ķ����(����, ��ǥ, �ӵ�)
            // MoveTowards�� ���� �ֱ� ���� ��, ������ �ִ°��̱� ������ ������ rigidbody�� �־���Ѵ�.
            move = Vector3.MoveTowards(move, inputMoveXZ, rate * runSpeed);
        }

        else
        {
            // ���� ���� ������ �����ϰڴ�. ������ ���ٰ� ����
            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMagnitude) * runSpeed * rate);
        }

        // ���� �ӵ��� �ִϸ����Ϳ� �ݿ�
        float speed = move.sqrMagnitude;
        chanAnimator.SetFloat("aSpeed", speed);

        move.y = tempMoveY;
    }

    void GroundChecking()
    {
        if (Physics.Raycast(oTransform.position, Vector3.down, 0.5f))
        {
            move.y -= 5;
        }

        else
        {
            move.y = -1;
        }
    }
}
