using UnityEngine;

/* 특정좌표로 다시 위치시키는 클래스 
 Scroller를 통해 마지막좌표로 이동 후 시작좌표로 이동
 작성자: 이정훈
 최종 수정일자 : 2023.11.14 */

public class Repositon : MonoBehaviour
{
    ChangeObject changeObject;
    public int startPositionX; //시작좌표
    public int endPositionX; //마지막좌표

    void Awake() {
        changeObject = GetComponent<ChangeObject>();  
    }

    void LateUpdate() {
        //위치 이동
        if (transform.position.x < endPositionX ) { //localposition - 상대적 위치
           transform.Translate(startPositionX,0,0, Space.Self); //Space.Self - 상대적 위치
           changeObject.Change();   
        } 
    }   
}