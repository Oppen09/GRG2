using UnityEngine;

/* ������Ʈ�� �����ϴ� Ŭ����
 Scroller�� ���� �̵��� �� rposition�ɶ� �迭�� ������Ʈ�� �ϳ��� ����  
 �ۼ���: ������
 ���� �������� : 2023.11.14 */

public class ChangeObject : MonoBehaviour
{
    public GameObject[] arrObject;

    //������Ʈ ����
    public void Change(){
        int random = Random.Range(0, arrObject.Length);
        for(int index = 0; index < arrObject.Length; index++){
            transform.GetChild(index).gameObject.SetActive(random == index);
        }
    }
}
