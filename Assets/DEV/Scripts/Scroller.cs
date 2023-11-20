using UnityEngine;

/* 오브젝트를 좌측으로 이동시키는 클래스  
 작성자: 이정훈
 최종 수정일자 : 2023.11.14 */
public class Scroller : MonoBehaviour
{
    public float speedRate;

    //좌측으로 이동
    void Update() {
        float totalSpeed = GameManager.globalSpeed * speedRate * Time.deltaTime * -1.0f;
        transform.Translate( totalSpeed, 0, 0 );
    }
}