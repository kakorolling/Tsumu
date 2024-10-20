using TMPro;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{

    Account account;

    public TMP_Text levelUITxt;
    public TMP_Text deltaLevelPercentUITxt; //쌓인 경험치를 퍼센트로 나타내야함
    public TMP_Text coinUITxt;
    public TMP_Text jewelUITxt;

    void ViewNav()
    {
        levelUITxt.text = ((int)account.level).ToString();
        coinUITxt.text = ((int)account.coin).ToString();
        jewelUITxt.text = ((int)account.jewel).ToString();
    }

}
