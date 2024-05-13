using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLooAtTarget : MonoBehaviour
{
    #region
    public GameObject target = null;
    #endregion

    void Update()
    {
        LookAtSample();
    }

    void LookAtSample()
    {
        // ���� : End - Start ; �� ������ �Ÿ��� ���ϴ� ����
        Vector3 directionToTarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
    }
}
