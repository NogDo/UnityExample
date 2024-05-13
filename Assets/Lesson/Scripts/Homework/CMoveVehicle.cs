using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveVehicle : MonoBehaviour
{
    #region 전역 변수
    private float fHelicopterSpeedMove;
    private float fHelicopterSpeedRoate;
    private float fHelicopterPowerRise;

    private float fBatmobileSpeedMove;
    private float fBatmobileSpeedRotate;
    private float fWheelAngle;
    private float fGunAngle;
    private bool isBattle;

    private float fCameraDistance;
    private int nVehicleIndex;

    private GameObject objNowVehicle;
    private GameObject objNowCamera;
    private Rigidbody rbNowRigidbody;

    public GameObject objHelicopter = null;
    public GameObject objHelicopterCamera = null;
    public GameObject objHelicopterPropHead = null;
    public GameObject objHelicopterPropTail = null;
    public GameObject objBatmobile = null;
    public GameObject objBatmobileCamera = null;
    public GameObject objBatmobileGun = null;
    public GameObject[] objBatmobileWheel;
    #endregion

    void Start()
    {
        fHelicopterSpeedMove = 10.0f;
        fHelicopterSpeedRoate = 20.0f;
        fHelicopterPowerRise = 5.0f;

        fBatmobileSpeedMove = 30.0f;
        fBatmobileSpeedRotate = 45.0f;
        fWheelAngle = 0.0f;
        isBattle = false;

        nVehicleIndex = 0;

        objNowVehicle = objHelicopter;
        objNowCamera = objHelicopterCamera;
        rbNowRigidbody = objHelicopter.GetComponent<Rigidbody>();

        fCameraDistance = Vector3.Distance(objHelicopter.transform.position, objHelicopterCamera.transform.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeVehicle();
        }


        if (nVehicleIndex == 0)
        {
            MoveHelicopter();
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isBattle = true;
            }

            else if (Input.GetMouseButton(1))
            {
                isBattle = false;
            }


            if (isBattle)
            {
                MoveBatmobileBattle();
            }

            else
            {
                MoveBatmobile();
            }
        }
    }

    void LateUpdate()
    {
        CameraMove();
    }

    void ChangeVehicle()
    {
        objNowCamera.SetActive(false);

        if (nVehicleIndex == 0)
        {
            objNowVehicle = objBatmobile;
            objNowCamera = objBatmobileCamera;
            objNowCamera.SetActive(true);
            rbNowRigidbody = objBatmobile.GetComponent<Rigidbody>();

            fCameraDistance = Vector3.Distance(objBatmobile.transform.position, objBatmobileCamera.transform.position);

            nVehicleIndex = 1;
        }

        else
        {
            objNowVehicle = objHelicopter;
            objNowCamera = objHelicopterCamera;
            objNowCamera.SetActive(true);
            rbNowRigidbody = objHelicopter.GetComponent<Rigidbody>();

            fCameraDistance = Vector3.Distance(objHelicopter.transform.position, objHelicopterCamera.transform.position);

            nVehicleIndex = 0;
        }
    }

    void MoveHelicopter()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        objNowVehicle.transform.Translate(Vector3.forward * fVertical * fHelicopterSpeedMove * Time.deltaTime);
        objNowVehicle.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * fHorizontal * fHelicopterSpeedRoate * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            objNowVehicle.transform.Translate(Vector3.up * fHelicopterPowerRise * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftShift))
        {
            objNowVehicle.transform.Translate(Vector3.down * fHelicopterPowerRise * Time.deltaTime);
        }

        objHelicopterPropHead.transform.Rotate(Vector3.up * 1000.0f * Time.deltaTime);
        objHelicopterPropTail.transform.Rotate(Vector3.right * 900.0f * Time.deltaTime);
    }

    void MoveBatmobile()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        objNowVehicle.transform.Translate(Vector3.forward * fVertical * fBatmobileSpeedMove * Time.deltaTime);

        if (!(fVertical == 0))
        {
            objNowVehicle.transform.Rotate(Vector3.up * fHorizontal * fBatmobileSpeedRotate * Time.deltaTime);

            fWheelAngle += 600.0f * Time.deltaTime;

            if(fWheelAngle >= 360.0f)
            {
                fWheelAngle = 0.0f;
            }
        }

        objBatmobileWheel[0].transform.localRotation = Quaternion.Euler(fVertical * fWheelAngle, fHorizontal * 45.0f, 0.0f);
        objBatmobileWheel[1].transform.localRotation = Quaternion.Euler(fVertical * fWheelAngle, fHorizontal * 45.0f, 0.0f);
    }

    void MoveBatmobileBattle()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");
        float fGunHorizontal = Input.GetAxis("Mouse X");

        objNowVehicle.transform.Translate(Vector3.forward * fVertical * fBatmobileSpeedMove * Time.deltaTime);
        objNowVehicle.transform.Translate(Vector3.right * fHorizontal * fBatmobileSpeedMove * Time.deltaTime);

        if (!(fVertical == 0))
        {
            fWheelAngle += 600.0f * Time.deltaTime;

            if (fWheelAngle >= 360.0f)
            {
                fWheelAngle = 0.0f;
            }
        }

        if (!(fHorizontal == 0))
        {
            fWheelAngle += 600.0f * Time.deltaTime;

            if (fWheelAngle >= 360.0f)
            {
                fWheelAngle = 0.0f;
            }

            for (int i = 0; i < objBatmobileWheel.Length; i++)
            {
                objBatmobileWheel[i].transform.localRotation = Quaternion.Euler(fHorizontal * fWheelAngle, 90.0f, 0.0f);
            }
        }

        else
        {
            for (int i = 0; i < objBatmobileWheel.Length; i++)
            {
                objBatmobileWheel[i].transform.localRotation = Quaternion.Euler(fVertical * fWheelAngle, 0.0f, 0.0f);
            }
        }

        fGunAngle += fGunHorizontal;
        objBatmobileGun.transform.localRotation = Quaternion.Euler(0.0f, fGunAngle, 0.0f);
    }

    void CameraMove()
    {
        float fCameraRotateHorizontal = Input.GetAxis("Mouse X");

        if (isBattle)
        {
            objNowCamera.transform.localRotation = Quaternion.Euler(28.98f, fGunAngle, 0.0f);
            objNowCamera.transform.position = objNowVehicle.transform.position - objNowCamera.transform.forward * fCameraDistance;
        }

        else
        {
            fCameraRotateHorizontal = fCameraRotateHorizontal * 100.0f * Time.deltaTime;

            Vector3 targetPosition = objNowVehicle.transform.position;

            objNowCamera.transform.RotateAround(targetPosition, Vector3.up, fCameraRotateHorizontal);
            objNowCamera.transform.position = targetPosition - objNowCamera.transform.forward * fCameraDistance;
        }
    }
}
