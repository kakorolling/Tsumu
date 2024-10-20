using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tsumu : MonoBehaviour
{
    Stage stage;
    public void Init(Stage stage)
    {
        this.stage = stage;
        stage.addingObjLeft--;
    }
    void OnDestroy()
    {
        stage.tsumuList.Remove(this);
    }

    public abstract string name { get; } //이름=>스프라이트
    public abstract int startScore { get; } //레벨 1일 때 개당 쯔무 한 개당 얻을 수 있는 스코어
    public abstract int deltaScore { get; } //레벨이 오를수록 스코어 오르는 양
    public abstract int requiredlevelTsumu { get; } //레벨을 올리기 위해 필요한 쯔무 양
    public abstract int deltaRequiredlevelTsumu { get; } //
    public abstract List<string> color { get; } //컬러->나중에 리스트로 바꿔야함!!
    public abstract List<string> tag { get; } // 태그
    public abstract int[] deltaSkillTsumuAmount { get; }//스킬을 위해 필요한 쯔무 수

    public abstract int scoreLevel { get; set; } // 스코어 레벨
    public abstract int skillLevel { get; set; } // 스킬


    public TsumuDetector tsumuDetector;
    public abstract void ExecuteSkill(Stage stage);
    public abstract void Update();

    //스킬 설명문도 따로 넣어야함
}

//랜덤한 위치에 쯔무가 폭탄으로 바뀜 
//다른 타입의 쯔무가 메인 쯔무로 바뀌는거 
//한영역에 있는 쯔무들을 전부 제거

