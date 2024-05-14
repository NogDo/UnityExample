using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 프리팹 (Prefab)
/*

▶ 프리팹

- 다양한 컴포넌트와 설정 값을 가진 게임 오브젝트를 다시 사용할 수 있도록 에셋으로 저장한것

- 컴포넌트를 포함하고 있는 게임 객체의 원본을 미리 제작함으로서 특정 객체를 구성하기 위한 컴포넌트의 추가 및 변경을
손쉽게 관리할 수 있는 기능을 의미한다.

※ 유니티는 기본적으로 하이어라키에 있는 게임 오브젝트가 전부 현재 씬에 종속된다는 특징을 가지고 있다.


▷ 특징

- 유니티 엔진은 프리팹을 이용해서 객체의 조합을 미리 보관하는 것이 가능
ㄴ 프리팹을 사용하면 매번 객체의 조합을 구성하는 작업의 효율성을 높이는 것이 가능하다.

- 프리팹 원본에 변경 사항이 발생했을 경우 해당 변경 사항을 모두 사본 객체에 적용하는것이 가능
ㄴ 작업 능률 / 편하다


º 언제 사용하는가?

1. 다양한 컴포넌트를 추가하고 옵션 값을 변경한 오브젝트를 재활용하고 싶을 때

2. 내가 만드는 게임에 따라 오브젝트의 속성이 다른데 지속적으로 활용하고 싶을 때


º 프리팹을 안 쓴다면?

- 효율성이 바닥을 찍는다...

- 씬을 변경하거나 새로운 오브젝트를 만들때 계속해서 컴포넌트를 추가하고 옵션 값을 설정해야 하기 때문에...


º 깊은 복사와 얕은 복사

- 참조 형태만 가져오는 것을 얕은 복사라한다.

- 힙 영역에 새로운 객체를 새롭게 만드는 것을 깊은 복사라 한다.


*/
#endregion

public class CPrefabExample : MonoBehaviour
{
    #region 전역 변수
    public GameObject BulletObject = null;
    #endregion

    void Update()
    {
        //FireSample_01(); 
        //FireSample_02();
        FireSample_03();
    }

    void FireSample_01()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate() : 오브젝트를 복사한다 (객체 동적으로 생성)
            // ㄴ 원본 오브젝트를 복사해 클론을 반환해주는 메서드
            // ㄴ 인수 : 대상 오브젝트, 오브젝트 위치값, 오브젝트 회전값
            //Instantiate(BulletObject, transform.position, transform.rotation);
            //Destroy(BulletObject);

            // 리지드 바디

            GameObject bullet = Instantiate(BulletObject, transform.position, transform.rotation);

            float bulletPower = 1000.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
        }
    }

    void FireSample_02()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletObject, transform.position + transform.forward * 0.7f, transform.rotation);

            float bulletPower = 1500.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
            bullet.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Destroy(bullet, 3.0f);
        }
    }

    void FireSample_03()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletObject, transform.position + transform.forward * 0.8f, transform.rotation);

            float bulletPower = 4000.0f;

            // TransformDirection() : 오브젝트가 어떤 방향을 바라 보는지를 각도를 얻고자 할때 사용한다.
            Vector3 shootForward = bullet.transform.TransformDirection(Vector3.forward);

            bullet.GetComponent<Rigidbody>().AddForce(bulletPower * shootForward);
            bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            Destroy(bullet, 3.0f);
        }
    }
}
