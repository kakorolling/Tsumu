using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework.Constraints;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    //게이지는 쯔무 20개부터 터뜨리면 타이머 5초 늘어나고 8초동안 피버타임 시작

    // Dictionary<string, TsumuType> tsumuTypeDict = new Dictionary<string, TsumuType>()
    // {
    //     //{"a", new TsumuType("a", 100 ,Color.blue)},
    //     //{"b", new TsumuType("b", 200, Color.green)},
    //     //{"c", new TsumuType("c", 300, Color.gray)},
    //     //{"d", new TsumuType("d", 400, Color.red)},
    //     //{"e", new TsumuType("e", 500, Color.yellow)}
    // };

    // List<Type> tsumuTypeList = new();
    // List<(Type bombType, int min, int max)> comboBombList = new()
    // {
    //     (typeof(NormalBomb), 7, 13),
    //     (typeof(TimeBomb), 9, 16),
    //     (typeof(ExpBomb), 11, 18),
    //     (typeof(CoinBomb), 13, 20),
    //     (typeof(ScoreBomb), 15, 9999)
    // };

    Tsumu selectedTsumu;

    Stage stage;
    Account account;
    List<Tsumu> selectedTsumuList = new List<Tsumu>();
    int combo = 0;


    public TMP_Text timerUITxt;
    public TMP_Text scoreUITxt;
    public TMP_Text coinUITxt;
    public TMP_Text comboUITxt;
    public Image tsumuImg;
    public LineRenderer tsumuLineRenderer;
    public Transform tsumuGenerationPoint;

    // bool RunGame = false;
    // bool plusScore = false;
    // bool plusCoin = false;
    // bool plusExp = false;
    // bool plusTime = false;
    // bool plusbomb = false;
    // bool reducedTsumutype = false;
    // bool incessantCombo = false;


    public GameObject shadow;
    public GameObject bigWindow;

    void Awake()
    {
        shadow.SetActive(false);
        //ChoiceTsumuListForStage(mainTsumu);
    }
    void Start()
    {
        //stage.tsumuTypeList = tsumuTypeDict.Values.ToList();
        StartCoroutine("StartStage");
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) InputTsumu();
        if (Input.GetMouseButtonUp(0)) EvaluateTsumuList();
    }



    //*********게임 시작하기 전에 해야할 거*********//

    void ChoiceTsumuListForStage(Type mainTsumu)
    {
        //stage.selectedTsumuTypeList.Add(Type mainTsumu);


    }
    IEnumerator StartStage()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine("FillTsumu");
        StartCoroutine("RunTimer");
        StartCoroutine("DrawTsumuLine");
    }
    IEnumerator EndStage()
    {
        //레벨에 따른 점수 계산
        //타이머 멈추기
        //점수에 따라 경험치 추가
        //코인 추가
        //각 쯔무의 경험치 추가
        yield return null;
    }
    //쯔무를 클릭하면 입력모드에 들어가야함
    //다시 돌아가려면 이전 쯔무에 접촉하면 됨
    //쯔무를 클릭해->같은 쯔무들이 하얗게 변함->이어지면 위에 숫자(몇개이어졌는지 표시)
    IEnumerator FillTsumu()
    {
        for (int i = 0; i < stage.addingObjLeft / 5; i++)
        {
            //for (int j = 0; j < stage.tsumuTypeList.Count; j++)
            {
                //GenerateTsumu(stage.tsumuTypeList[j]);
            }
        }
        while (true)
        {
            for (int i = 0; i < stage.addingObjLeft; i++)
            {
                //GenerateTsumu(stage.tsumuTypeList[UnityEngine.Random.Range(0, stage.tsumuTypeList.Count)]);
            }
            yield return null;
        }
    }
    IEnumerator RunTimer()
    {
        while (true)
        {
            stage.timer -= Time.deltaTime;
            timerUITxt.text = ((int)stage.timer).ToString();
            if (stage.timer > 0)
            {
                yield return null;
                continue;
            }
            //스테이지 종료
        }
    }




    // IEnumerator ExecuteFeverTime()
    // {
    //     //쯔무 20개 터뜨리면 피버타임 시작
    //     //timer 5초 추가
    //     //FeverTime은 8초 후에 꺼짐
    //     //피버타임동안 점수를 따로 저장하고 끝나면 1.5배해서 점수 추가
    //     yield return null;
    // }
    // //그냥 볼, 타임볼, 경험치볼, 코인볼, 스코어볼, 
    // IEnumerator ExecuteTimeBall()
    // {
    //     //TsumuDetector　안에 감지된 쯔무들 전부 터뜨리고 Timer　2초 추가
    //     yield return null;
    // }
    public void InputTsumu()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("tsumu"));
        if (hit.collider == null) return;
        Tsumu tsumu = hit.collider.GetComponent<Tsumu>();
        if (tsumu == null) return;
        if (selectedTsumuList.Count != 0)
        {
            if (selectedTsumuList.Last() == tsumu) return;
            if (selectedTsumuList[0].GetType() != tsumu.GetType()) return;
            if (selectedTsumuList.Count > 1 && selectedTsumuList[selectedTsumuList.Count - 2] == tsumu)
            {
                DeselectTsumu();
                return;
            }
            if (!selectedTsumuList.Last().tsumuDetector.tsumuList.Contains(tsumu)) return;
        }
        if (selectedTsumuList.Contains(tsumu)) return;
        SelectTsumu(tsumu);
    }
    void SelectTsumu(Tsumu tsumu)
    {
        selectedTsumuList.Add(tsumu);
        Debug.Log("tsumu selected");
    }
    void DeselectTsumu()
    {
        selectedTsumuList.RemoveAt(selectedTsumuList.Count - 1);
        Debug.Log("tsumu deselected");

    }
    IEnumerator DrawTsumuLine()
    {
        while (true)
        {
            tsumuLineRenderer.positionCount = selectedTsumuList.Count;
            tsumuLineRenderer.SetPositions(selectedTsumuList.Select(e => e.transform.position).ToArray());
            yield return null;
        }
    }
    void EvaluateTsumuList()
    {
        if (selectedTsumuList == null) return;
        if (selectedTsumuList.Count < 3)
        {
            //deselect all tsumu
            selectedTsumuList.Clear();
        }
        else
        {
            //점수, 콤보 등등 카운트해서 스테이지매니저에 추가
        }
        combo = (int)selectedTsumuList.Count;
        Vector3 lastTsumuPosition = selectedTsumuList.Last().transform.position;
        if (selectedTsumuList.Count >= 7)
        {
            RunCombo(selectedTsumuList.Count, lastTsumuPosition);
        }

        stage.feverPoint += selectedTsumuList.Count;
        Debug.Log("combo count: " + selectedTsumuList.Count + " fever point: " + stage.feverPoint);
        coinUITxt.SetText(combo.ToString());
        selectedTsumuList.ForEach(e => Destroy(e.gameObject));
        selectedTsumuList = new();//temp
        if (stage.feverPoint >= 20) StartCoroutine("RunFeverTime");
    }

    void GenerateTsumu(Type tsumuType)
    {
        float randomX = UnityEngine.Random.Range(-2f, 2f);
        Vector3 randomPosition = new Vector3(randomX, 0, 0);
        GameObject tsumuObj = new GameObject("", typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(SpriteRenderer), tsumuType);
        tsumuObj.transform.position = randomPosition;
        tsumuObj.GetComponent<SpriteRenderer>().sprite = Array.Find(Resources.LoadAll<Sprite>("tsumu"), e => e.name == tsumuType.Name);
        Tsumu tsumu = tsumuObj.GetComponent<Tsumu>();
        tsumu.Init(stage);
        stage.tsumuList.Add(tsumu);
    }
    void GenerateBomb(Type bombType, Vector3 lastTsumuPosition)
    {
        GameObject bombObj = new GameObject("", typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(SpriteRenderer), bombType);
        bombObj.transform.position = lastTsumuPosition;
        bombObj.GetComponent<SpriteRenderer>().sprite = Array.Find(Resources.LoadAll<Sprite>("bomb"), e => e.name == bombType.Name);
        Bomb bomb = bombObj.GetComponent<Bomb>();
        bomb.Init(stage);
        stage.bombList.Add(bomb);
    }

    IEnumerator RunFeverTime()
    {
        stage.feverPoint = 0;
        stage.timer += 5;

        yield return null;
    }
    void RunCombo(int combo, Vector3 lastTsumuPosition)
    {
        List<Type> availableList = new();
        for (int i = 0; i < stage.comboBombList.Count; i++)
        {
            if (combo < stage.comboBombList[i].min || combo > stage.comboBombList[i].max) continue;
            availableList.Add(stage.comboBombList[i].bombType);
        }
        Type bombType = availableList[UnityEngine.Random.Range(0, availableList.Count)];
        GenerateBomb(bombType, lastTsumuPosition);
    }

    //팬기능
    public void FloatTsumu() => StartCoroutine("CoFloatTsumu");
    IEnumerator CoFloatTsumu()
    {
        float timer = 0.5f;
        while (true)
        {
            timer -= Time.deltaTime;
            if (timer < 0) yield break;
            for (int i = 0; i < stage.tsumuList.Count; i++)
            {
                stage.tsumuList[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5));
            }
            yield return null;
        }
    }

    //puase

    void PauseStage()
    {
        shadow.SetActive(true);
        bigWindow.SetActive(true);

        //브금
        //효과음
        //정지
        //돌아가기
    }
}

