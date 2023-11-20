using UnityEngine;

/* �Ҹ� ��� ����
 �ۼ���: ������
 ���� �������� : 2023.11.14 */

public class SoundManager : MonoBehaviour
{
    public enum Sfx { Jump, Land, Hit, start }
    public AudioClip[] clips;

    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();   
    }

    //���� ���
    public void PlaySound(Sfx sfx) {
        audioSource.clip = clips[(int)sfx];
        audioSource.Play();
    }
}
