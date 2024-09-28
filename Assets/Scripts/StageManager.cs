using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    Dictionary<string, TsumuType> tsumuTypeDict = new Dictionary<string, TsumuType>(){
        {"a", new TsumuType("a", 100 ,Color.blue)},
        {"b", new TsumuType("b", 200, Color.green)},
        {"c", new TsumuType("c", 300, Color.gray)},
        {"d", new TsumuType("d", 400, Color.red)},
        {"e", new TsumuType("e", 500, Color.yellow)}
    };

    float timer = 60f;
    int score = 0;
    int coin = 0;
    int combo = 0;
    int feverPoint = 0;
    List<TsumuType> tsumuTypeList;
    const int maxTsumuNum = 50;

    public TsumuGenerator tsumuGenerator;
    public TMP_Text timerUI;

    //test
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tsumuTypeList = tsumuTypeDict.Values.ToList();
        StartCoroutine("RunStage");
    }

    // Update is called once per frame
    IEnumerator RunStage()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < maxTsumuNum / 5; i++)
        {
            for (int j = 0; j < tsumuTypeList.Count; j++)
                tsumuGenerator.GenerateTsumu(tsumuTypeList[j]);
        }

        while (true)
        {
            timer -= Time.deltaTime;
            timerUI.text = ((int)timer).ToString();
            if (timer > 0)
            {
                yield return null;
                continue;
            }

            //스테이지 종료

        }

    }


    //초기설정(아이템을 이용해 바뀔 수 있음)
}
