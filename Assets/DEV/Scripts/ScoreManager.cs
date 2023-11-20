using UnityEngine;
using TMPro;

/* ���� ���� �� �����ý��� ���� 
 �ۼ���: ������
 ���� �������� : 2023.11.14 */
public class ScoreManager : MonoBehaviour
{
    //���� �迭
    string[] arrRankingName = new string[5];
    float[] arrRankingScore = new float[5];
 
    float highScore;
    public static float score;
   
    string tmpName = "";
    float tmpScore = 0f;

    public TextMeshProUGUI textHighScore;
    public TextMeshProUGUI textScore;

    //����ǥ ���� �ؽ�Ʈ
    public TextMeshProUGUI[] textRankingRank = new TextMeshProUGUI[5];
    public TextMeshProUGUI[] textRankingName = new TextMeshProUGUI[5];
    public TextMeshProUGUI[] textRankingScore = new TextMeshProUGUI[5];

    //�̸��Է�â
    public TMP_InputField nameInputField;
    string playerName;

    void Update() {
        //��������
        score += Time.deltaTime * 2;
    }

    void LateUpdate() {
        //���ӳ� �������� ���
        textScore.text = "Score : " + score.ToString("F0");

        highScore = PlayerPrefs.GetFloat(0 + "BestScore");

        if (highScore > score){
            textHighScore.text = "bestScore : " + highScore.ToString("F0");
        }
        else if (highScore < score){
            textHighScore.text = "bestScore : " + score.ToString("F0");
        }
    }


    //���� �߰� �� ����
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

    //����ǥ ���� ���
    public void PrintRanking() {
        for (int i = 0; i < 5; i++) {
            textRankingRank[i].text = ((i + 1).ToString());
            textRankingName[i].text = (arrRankingName[i]);
            textRankingScore[i].text = (arrRankingScore[i].ToString("F0"));      
        }
    }

    //���� ���� ����
    public void SaveRankingData() {
        for (int i = 0; i < 5; i++) {
            PlayerPrefs.SetFloat(i + "BestScore", arrRankingScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", arrRankingName[i]);
        }
    }

    //���� ���� �ҷ�����
    public void LoadRankingData() {
        for (int i = 0; i < 5; i++){
            arrRankingScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            arrRankingName[i] = PlayerPrefs.GetString(i + "BestName");
        }
    }
}
