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
        // 공식 : End - Start ; 둘 사이의 거리를 구하는 공식
        Vector3 directionToTarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
    }
}
