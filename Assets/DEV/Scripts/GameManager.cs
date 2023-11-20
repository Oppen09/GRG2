using UnityEngine;
using UnityEngine.SceneManagement;

/* 게임 전체의 동작 및 UI제어
 작성자: 이정훈
 최종 수정일자 : 2023.11.20 */
public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 10;

    public static float globalSpeed;
    public float maxSpeed;

    public GameObject pauseButton;
    public GameObject uiRankingSystem;
    public GameObject uiGameOver;
    public GameObject uiPause;


    void Update() {
        //속도증가
        globalSpeed = ORIGIN_SPEED + ScoreManager.score * 0.1f;

        //속도제한
        if (globalSpeed > maxSpeed) { 
            globalSpeed = maxSpeed; 
        }
    }
   
    //게임 종료 
    public void GameOver() {
        pauseButton.SetActive(false);
        uiGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    //일시정지
    public void PauseGame() {
        Time.timeScale = 0;
        uiPause.SetActive(true);
        pauseButton.SetActive(false);
    }

    //게임 재개
    public void ResumeGame() {
        Time.timeScale = 1.0f;
        uiPause.SetActive(false);
        pauseButton.SetActive(true);
    }

    //게임 시작
    public void StartGame() { 
        SceneManager.LoadScene("inGame");
        ScoreManager.score = 0;
        Time.timeScale = 1.0f;
        
    }

    //게임 재시작
    public void RestartGame() {
        SceneManager.LoadScene("inGame");
        ScoreManager.score = 0; ;
        Time.timeScale = 1.0f;
    }

    //랭킹UI 출력(인게임 씬)
    public void OpenRankingUIInGame() {
        uiRankingSystem.SetActive(true);
        uiGameOver.SetActive(false);
    }

    //랭킹UI 닫기(인게임 씬)
    public void CloseRankingUIInGmae() {
        uiRankingSystem.SetActive(false);
        uiGameOver.SetActive(true);
    }

    //랭킹UI 출력(메인메뉴 씬)
    public void OpenRankingUIMainMenu()
    {
        uiRankingSystem.SetActive(true);
    }

    //랭킹UI 닫기(메인메뉴 씬)
    public void CloseRankingUIMainMenu()
    {
        uiRankingSystem.SetActive(false);
    }

    //메인메뉴 씬 로드
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    //프로그램 종료
    public void Quit() {
        Application.Quit();
    }
}
