using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ����Ƽ �ִϸ��̼�
/*
 
�� ����Ƽ �ִϸ��̼�

- ����Ƽ �ִϸ��̼��� ũ�� 2������ ������.
    �� 1. ���Ž�
    �� 2. ��ī��


�� ���Ž�

- ���Žô� ������Ʈ���� ������ �ִ� �ִϸ��̼��� �ܺ� ���� �۾��� �ϰ� �������� ����̴�.

- ���Žô� �ΰ����� �ƴ� ��⿡ ���� ������ �Ǿ� �ִ�.
    �� ������ ���Ž� ��ü�� �̽ļ��� �������� Ȯ�强�� ��ī�Կ� ���� �������� ����

- Ȯ������ �������� ������ ��ī�Ժ��� ���Žð� �����ϴ�.


�� ��ī��

- ��ī���� ����Ƽ ������ ������Ǹ鼭 �߰��� �ִϸ��̼� ���� �ӽ� ���̶�� �� �� �ִ�.

- ���Ž� �ִϸ��̼��� ������ �ִ� �������� �ڿ������� �ִϸ��̼� / Ȯ�强�� �ؼ��� �ִϸ��̼� ����̶�� �� �� �ִ�.


�� ����

- �̽ļ��� ����꼺�� ����.

- ��ü�� �ִϸ��̼� ���� �� ������ ��ġ�Ѵٸ� �ٸ� �ִϸ��̼��̳� ��� �ִϸ��̼��� ������ �� �ִ�.

- �������� �پ��. (�������� ����)


�� ����

- ������Ʈ�� ���������� Ȯ�强�� �������� ���� ���̸� �����ϱ� ���� �ſ� ����������.

- ���� ���谡 ��ٷӰ� ������ �������� ���ϴ�.


�� ���Žô� Animation�̶�� ������Ʈ ��� / ��ī���� Animator�� ����Ѵ�.


�� �ִϸ�����

- ���� ������Ʈ�� �����ϴ� Ư���� ������ �ִϸ��̼� ������Ʈ

- �ִϸ��̼� ��� ���� ������ ��� �ֱ� ������ �ִϸ��̼��� ����Ϸ��� �ִϸ����� ���� ����� �ؾ� �Ѵ�.


�� �ִϸ��̼� Ÿ��

- �޸ӳ��̵�
�� �Ӹ� / �� / �ٸ��� �ִ� ĳ���ʹ� �Ϲ������� �ΰ������� �з��� �ǰ� �ΰ��� ��ü���� ��Ÿ������ ���� �ִϸ��̼��� ������ �� �ִ�.
    �� �̰� ������ ������ �ƹ�Ÿ�� ������ �� �ֱ� ������

- ���׸�
�� �޸ӳ��̵带 ������ ������ ������Ʈ���̶�� �����ϸ� ���� �� ����.
�� �⺻������ ��Ÿ���� ��� ��ü���� �ƴ����� �ִϸ��̼� ������ ����ϰ� ���� �� ���Ǵ� ����
�� ���� ��ü�� ������ ȿ�����̴�. (�޸� ��뷮�� ����)


�ڡڡڡڡ� ���� ���� �ڡڡڡڡ�
�� ����Ƽ ���� ���� ���� �ӽ� (Finite State Machine)

- ���� ���� �ӽ� (FSM)�� ���¿� �ൿ�� ���� �������� Ŭ������ ����dhk ��ü�� �����ϵ��� �ϴ� ������ �ǹ��Ѵ�.

- ������ ���¸� �����ϰ� ó���ϴ� �����̸� �� State�� �ְ� �� State�� ���̽�Ű�� ���� ������ �ִµ� �װ��� ǥ���ϴ� ����̶�� �� �� �ִ�.


�� FSM �ֿ� ����

- State
�� ���ǵ� �ϳ� / ���� ������ �ǹ��Ѵ�.

- Trasition
�� �� ���¿��� �ٸ� ���·� �����ϴ°��� ���Ѵ�.

- Event
�� ���� ���̸� ���� ���� / ������ �����ϸ� ���� ���̰� �߻��Ѵ�.

- Action
�� ���� �ൿ�� ����ȴ�.

�� ���������� �� ���� ������ �ܺ� ���� ���ǿ� ���� ������ �� �� �ִ�.


�� ����Ʈ
�� �ִϸ��̼� Ŭ���� ���ٸ� ���Ž� / ��ī��
�� �ִϸ��̼� Ŭ���� ���ų� ���ų� ��� ��ü�� �޸ӳ��̵��� ������ ��ī��
�� �ִϸ��̼� Ŭ���� ���� ���׸� Ÿ���̶�� ���Ž� / ��ī�� (���� ������ ���ҽ����� �ٸ�)



�� ���̳��� ��

- �Ӹ�ī��, ���� ���� ���� ����.


�� Character Controller

- Slope : ��簪

- Step Offset : ����� ����

- Skin Width : ���� ���� ����, Ư�� ���� �����Ѵ�. (���͸�; ĳ���� �̵� �̺�Ʈ�� Ʈ���ŵǴµ� �������� ���ٸ� ���͸��� ����, ĳ���͸� ���� ��)

- Min Move Distance : ���ӵ��� ������ �����Ѵ�. ĳ���Ͱ� ������ �� ���� �۰� �̵��ϸ� �̵��� �������ϰ� ����, �ٶ��� ������ �ȹް� �ϱ� ���ؼ��� ���


�� Animator

- Apply Root Motion : Root Motion�� �ִϸ��̼ǿ��� ��������, �ڵ忡�� �������� ���� (üũ ������ �ڵ忡�� ����)

- Update Mode
�� Normal (Update�� �ڷ�ƾ �Ѵ� ���)
�� Animate Physics()
�� Unscale Time(Update, �ڷ�ƾ �Ѵ� ���X ���⿡ ���, ������ ���̿� �ð��� �� �� ����)

- Culling Mode (�ſ� �����) : ����ȭ�� ���õ� �ɼ�, ���� ���� ���� ���� �ؽ��ĸ� ���Լ� ����ȭ
 
*/
#endregion

public class CMecanimController : MonoBehaviour
{
    CharacterController chanController;
    Vector3 direction;

    #region public ����
    public float runSpeed = 4.0f;
    public float rotationSpeed = 360f;
    #endregion

    Animator animator;

    void Start()
    {
        chanController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        animator.SetFloat("aSpeed", chanController.velocity.magnitude);

        ChanControl_Slerp();
    }

    private void ChanControl_Slerp()
    {
        Vector3 direction = new Vector3
            (
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp
                (
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );

            transform.LookAt(transform.position + forward);
        }

        else
        {
            // ���� x
        }

        chanController.Move(direction * runSpeed * Time.deltaTime);
    }
}