using UnityEngine;

/* 오브젝트를 변경하는 클래스
 Scroller를 통해 이동된 후 rposition될때 배열의 오브젝트중 하나로 변경  
 작성자: 이정훈
 최종 수정일자 : 2023.11.14 */

public class ChangeObject : MonoBehaviour
{
    public GameObject[] arrObject;

    //오브젝트 변경
    public void Change(){
        int random = Random.Range(0, arrObject.Length);
        for(int index = 0; index < arrObject.Length; index++){
            transform.GetChild(index).gameObject.SetActive(random == index);
        }
    }
}
