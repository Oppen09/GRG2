using UnityEngine;

/* ������Ʈ�� �������� �̵���Ű�� Ŭ����  
 �ۼ���: ������
 ���� �������� : 2023.11.14 */
public class Scroller : MonoBehaviour
{
    public float speedRate;

    //�������� �̵�
    void Update() {
        float totalSpeed = GameManager.globalSpeed * speedRate * Time.deltaTime * -1.0f;
        transform.Translate( totalSpeed, 0, 0 );
    }
}