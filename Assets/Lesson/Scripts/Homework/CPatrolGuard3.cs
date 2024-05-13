using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatrolGuard3 : MonoBehaviour
{
    #region 전역 변수
    public GameObject objTarget;

    private float nMinX;
    private float nMaxX;
    private float nMinZ;
    private float nMaxZ;
    #endregion

    void Start()
    {
        nMinX = -15.0f;
        nMaxX = 0.0f;
        nMinZ = -24.0f;
        nMaxZ = 24.0f;

        objTarget.transform.localPosition = new Vector3(Random.Range(nMinX, nMaxX), 1.06694f, Random.Range(nMinZ, nMaxZ));
    }

    void Update()
    {
        Petrol();
    }

    void Petrol()
    {
        Vector3 direction = objTarget.transform.localPosition - this.transform.localPosition;

        this.transform.Translate(direction.normalized * 5.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            objTarget.transform.localPosition = new Vector3(Random.Range(nMinX, nMaxX), 1.06694f, Random.Range(nMinZ, nMaxZ));
        }
    }
}
