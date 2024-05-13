using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatrolGuard1 : MonoBehaviour
{
    #region 전역 변수
    public GameObject[] objTarget;

    private int sNowTargetNum;
    #endregion

    void Start()
    {
        sNowTargetNum = 0;
    }

    void Update()
    {
        Petrol();
    }

    void Petrol()
    {
        Vector3 direction = objTarget[sNowTargetNum].transform.localPosition - this.transform.localPosition;

        this.transform.Translate(direction.normalized * 5.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            sNowTargetNum++;
            sNowTargetNum %= objTarget.Length;
        }
    }
}
