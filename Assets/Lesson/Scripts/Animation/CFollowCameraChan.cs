using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라는 transform과 rotation을 많이 쓰기 때문에 알고리즘 + 수학 덩어리다
public class CFollowCameraChan : MonoBehaviour
{
    #region public 변수
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

        // 마우스의 움직임을 가감
        mouseMove += new Vector3
            (
            -Input.GetAxisRaw("Mouse Y") * mouseSensitivity,
            Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            0
            );

        // 높이 제한
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

    // 외부 영향으로 / 지형등으로 인해 카메라가 기울어지면 바로 잡는 역할
    void Balance()
    {
        if (oTransform.eulerAngles.x != 0 || oTransform.eulerAngles.z != 0)
        {
            oTransform.eulerAngles = new Vector3(0, oTransform.eulerAngles.y, 0);
        }
    }

    void CameraDistanceControl()
    {
        // 휠로 카메라의 거리를 조절
        Camera.main.transform.localPosition += new Vector3(0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * 2.0f);

        // if문 조건식에 좌항 우항에 따라 연산속도 차이가 있다.
        // 최대로 가까운 수치
        if (-2 < Camera.main.transform.localPosition.z)
        {
            Camera.main.transform.localPosition = new Vector3
                (
                Camera.main.transform.localPosition.x,
                Camera.main.transform.localPosition.y,
                -2
                );
        }

        // 최소로 가까운 수치
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

        // y는 필요없기 때문에 잠시 저장하고 빼둔다.
        move.y = 0;

        Vector3 inputMoveXZ = new Vector3
            (
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );


        // 대각선 이동 -> 2배의 속도 -> 속도가 1이상 올라가면 -> 노말라이즈 -> 항상 일정한 속도를 가질 수 있게 처리
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


        // 조작중에만 카메라의 방향에 상대적으로 캐릭터가 움직이는 처리를 해야 한다.
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Quaternion cameraRotation = cameraParentTrasform.rotation;

            // 카메라는 무슨 축만 필요할까 y축만 필요
            cameraRotation.x = cameraRotation.z = 0;

            oTransform.rotation = Quaternion.Slerp
                (
                oTransform.rotation,
                cameraRotation,
                10.0f * Time.deltaTime
                );


            // Quaternion은 3개 축 모두의 값이 0이라면 오류가 들어간다.
            // 따라서 0, 0, 0에 대한 예외처리를 해주어야 한다.
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

            // 파라미터(현재, 목표, 속도)
            // MoveTowards는 관성 주기 위한 것, 가속을 주는것이기 때문에 쓰려면 rigidbody가 있어야한다.
            move = Vector3.MoveTowards(move, inputMoveXZ, rate * runSpeed);
        }

        else
        {
            // 관성 같은 느낌을 구현하겠다. 서서히 가다가 멈춤
            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMagnitude) * runSpeed * rate);
        }

        // 현재 속도를 애니메이터에 반영
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
