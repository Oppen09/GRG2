using UnityEngine;

/* 소리 출력 제어
 작성자: 이정훈
 최종 수정일자 : 2023.11.14 */

public class SoundManager : MonoBehaviour
{
    public enum Sfx { Jump, Land, Hit, start }
    public AudioClip[] clips;

    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();   
    }

    //사운드 출력
    public void PlaySound(Sfx sfx) {
        audioSource.clip = clips[(int)sfx];
        audioSource.Play();
    }
}
