using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveForward : MonoBehaviour
{
    public void Update()
    {
        var cubePosition = gameObject.transform.position;
        // deltaTime은 이전 프레임과 다음 프레임의 차이값을 반환
        cubePosition.z += 5.0f * Time.deltaTime;

        gameObject.transform.position = cubePosition;
    }
}
