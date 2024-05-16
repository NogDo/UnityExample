using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovePlayer : MonoBehaviour
{
    #region 전역 변수
    public float speed = 0;
    #endregion

    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3
            (
                hori * Time.deltaTime * speed,
                0.0f,
                upDown * Time.deltaTime * speed
            );

        transform.Translate(move);
    }
}
