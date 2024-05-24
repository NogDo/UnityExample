using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ƼŬ�� �޸� ��뷮�� ���� ������ ���� ���İ��� ���� ����.
[System.Serializable]
public class CTargetInfo
{
    public GameObject target;
    public float moveSpeed;
}

public class CRunParticle : MonoBehaviour
{
    #region public ����
    // 1. ���� ��ü ���
    public GameObject particleObject;

    // 2. �ϴ� �� ��� (�ݺ��� ���)
    public GameObject[] targets;
    public float[] moveSpeed;

    // 3. Ŭ���� �����
    public CTargetInfo[] targetInfo;

    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject effect = Instantiate(particleObject, this.transform.position, Quaternion.identity);

            Destroy(effect, 3.0f);
        }


        // ��ƼŬ�� ���� ��� ����
        Vector3 moveVec = Vector3.zero;

        for (int i = 0; i < this.targetInfo.Length; i++)
        {
            Vector3 move = moveVec * this.targetInfo[i].moveSpeed * Time.deltaTime;
            this.targetInfo[i].target.transform.Translate(move);
        }
    }
}
