using UnityEngine;

/* Ư����ǥ�� �ٽ� ��ġ��Ű�� Ŭ���� 
 Scroller�� ���� ��������ǥ�� �̵� �� ������ǥ�� �̵�
 �ۼ���: ������
 ���� �������� : 2023.11.14 */

public class Repositon : MonoBehaviour
{
    ChangeObject changeObject;
    public int startPositionX; //������ǥ
    public int endPositionX; //��������ǥ

    void Awake() {
        changeObject = GetComponent<ChangeObject>();  
    }

    void LateUpdate() {
        //��ġ �̵�
        if (transform.position.x < endPositionX ) { //localposition - ����� ��ġ
           transform.Translate(startPositionX,0,0, Space.Self); //Space.Self - ����� ��ġ
           changeObject.Change();   
        } 
    }   
}