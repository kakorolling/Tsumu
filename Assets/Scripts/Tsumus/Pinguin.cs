using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;


//스킬 정리해놓아야함
public class Pinguin : Tsumu
{
    public override string name { get => "Pinguin"; }
    public override int startScore { get => 100; }
    public override int deltaScore { get => 7; }
    public override int requiredlevelTsumu { get => 150; }
    public override int deltaRequiredlevelTsumu { get => 50; }
    public override List<string> color { get => new List<string> { "pink", "white" }; }
    public override List<string> tag { get => new List<string>() { "penguin" }; }
    public override int[] deltaSkillTsumuAmount { get => new int[] { 1, 2, 4, 8, 20 }; }

    int _scoreLevel = 1;
    int _skillLevel = 1;
    public override int scoreLevel { get => _scoreLevel; set => _scoreLevel = value; }
    public override int skillLevel { get => _skillLevel; set => _skillLevel = value; }

    public override void ExecuteSkill(Stage stage)
    {
        List<int> randomNums = new List<int>();
        List<Tsumu> changeTsumuList = new List<Tsumu>();
        for (int i = 0; i < stage.tsumuList.Count; i++) randomNums.Add(i);
        for (int i = 0; i < 3; i++)
        {
            int randNum = UnityEngine.Random.Range(0, randomNums.Count);
            randomNums.RemoveAt(randNum);
            changeTsumuList.Add(stage.tsumuList[randNum]);
        }
        //폭탄으로 만들어야하는데 지금 폭탄이 구현안됨!

        //stage.tsumuList[Random.Range(0, stage.tsumuList.Count)]
        //임의의 쯔무 3(임의)개를 일반 폭탄으로 만드는거 
    }
    public override void Update()
    {

    }
}
