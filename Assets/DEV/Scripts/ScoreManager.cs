using UnityEngine;
using TMPro;

/* 게임 점수 및 순위시스템 제어 
 작성자: 이정훈
 최종 수정일자 : 2023.11.14 */
public class ScoreManager : MonoBehaviour
{
    //순위 배열
    string[] arrRankingName = new string[5];
    float[] arrRankingScore = new float[5];
 
    float highScore;
    public static float score;
   
    string tmpName = "";
    float tmpScore = 0f;

    public TextMeshProUGUI textHighScore;
    public TextMeshProUGUI textScore;

    //순위표 내부 텍스트
    public TextMeshProUGUI[] textRankingRank = new TextMeshProUGUI[5];
    public TextMeshProUGUI[] textRankingName = new TextMeshProUGUI[5];
    public TextMeshProUGUI[] textRankingScore = new TextMeshProUGUI[5];

    //이름입력창
    public TMP_InputField nameInputField;
    string playerName;

    void Update() {
        //점수증가
        score += Time.deltaTime * 2;
    }

    void LateUpdate() {
        //게임내 점수정보 출력
        textScore.text = "Score : " + score.ToString("F0");

        highScore = PlayerPrefs.GetFloat(0 + "BestScore");

        if (highScore > score){
            textHighScore.text = "bestScore : " + highScore.ToString("F0");
        }
        else if (highScore < score){
            textHighScore.text = "bestScore : " + score.ToString("F0");
        }
    }


    //순위 추가 및 정렬
    public void AddRankingIndex() {
        playerName = nameInputField.text;
        
        for (int i = 0; i <5; i++){
            while (arrRankingScore[i] < score) {
                tmpScore = arrRankingScore[i];
                tmpName = arrRankingName[i];
                arrRankingScore[i] = score;
                arrRankingName[i] = playerName;

                playerName = tmpName;
                score = tmpScore;
            }
        }
    }

    //순위표 순위 출력
    public void PrintRanking() {
        for (int i = 0; i < 5; i++) {
            textRankingRank[i].text = ((i + 1).ToString());
            textRankingName[i].text = (arrRankingName[i]);
            textRankingScore[i].text = (arrRankingScore[i].ToString("F0"));      
        }
    }

    //순위 정보 저장
    public void SaveRankingData() {
        for (int i = 0; i < 5; i++) {
            PlayerPrefs.SetFloat(i + "BestScore", arrRankingScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", arrRankingName[i]);
        }
    }

    //순위 정보 불러오기
    public void LoadRankingData() {
        for (int i = 0; i < 5; i++){
            arrRankingScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            arrRankingName[i] = PlayerPrefs.GetString(i + "BestName");
        }
    }
}
