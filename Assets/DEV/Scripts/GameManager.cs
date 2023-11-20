using UnityEngine;
using UnityEngine.SceneManagement;

/* ���� ��ü�� ���� �� UI����
 �ۼ���: ������
 ���� �������� : 2023.11.20 */
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
        //�ӵ�����
        globalSpeed = ORIGIN_SPEED + ScoreManager.score * 0.1f;

        //�ӵ�����
        if (globalSpeed > maxSpeed) { 
            globalSpeed = maxSpeed; 
        }
    }
   
    //���� ���� 
    public void GameOver() {
        pauseButton.SetActive(false);
        uiGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    //�Ͻ�����
    public void PauseGame() {
        Time.timeScale = 0;
        uiPause.SetActive(true);
        pauseButton.SetActive(false);
    }

    //���� �簳
    public void ResumeGame() {
        Time.timeScale = 1.0f;
        uiPause.SetActive(false);
        pauseButton.SetActive(true);
    }

    //���� ����
    public void StartGame() { 
        SceneManager.LoadScene("inGame");
        ScoreManager.score = 0;
        Time.timeScale = 1.0f;
        
    }

    //���� �����
    public void RestartGame() {
        SceneManager.LoadScene("inGame");
        ScoreManager.score = 0; ;
        Time.timeScale = 1.0f;
    }

    //��ŷUI ���(�ΰ��� ��)
    public void OpenRankingUIInGame() {
        uiRankingSystem.SetActive(true);
        uiGameOver.SetActive(false);
    }

    //��ŷUI �ݱ�(�ΰ��� ��)
    public void CloseRankingUIInGmae() {
        uiRankingSystem.SetActive(false);
        uiGameOver.SetActive(true);
    }

    //��ŷUI ���(���θ޴� ��)
    public void OpenRankingUIMainMenu()
    {
        uiRankingSystem.SetActive(true);
    }

    //��ŷUI �ݱ�(���θ޴� ��)
    public void CloseRankingUIMainMenu()
    {
        uiRankingSystem.SetActive(false);
    }

    //���θ޴� �� �ε�
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    //���α׷� ����
    public void Quit() {
        Application.Quit();
    }
}
