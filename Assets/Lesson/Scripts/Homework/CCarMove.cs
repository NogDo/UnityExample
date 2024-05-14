using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarMove : MonoBehaviour
{

    #region 전역변수
    private float fMovePower = 1500.0f;
    private float fCollisionPower = 300.0f;
    private float fRotaeSpeed = 600.0f;
    private bool isMove = true;
    private Rigidbody rb;

    public GameObject[] gameObject_Wheel;
    #endregion

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isMove)
        {
            // AddRelativeForce를 쓰는 것이 유지보수와 성능면에서 더 좋다!
            rb.AddRelativeForce(Vector3.forward * fMovePower);
            //rb.AddForce(transform.forward * fMovePower);

            for (int i = 0; i < gameObject_Wheel.Length; i++)
            {
                gameObject_Wheel[i].transform.Rotate(Vector3.right * fRotaeSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") && isMove)
        {
            isMove = false;

            rb.AddRelativeForce(Vector3.back * fCollisionPower);
            rb.AddForce(Vector3.up * fCollisionPower * 100.0f);
        }
    }
}
