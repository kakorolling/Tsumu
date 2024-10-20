using System;
using System.Collections.Generic;

public class Stage
{
    public float timer = 60f;
    public int sfcore = 0;
    public int coin = 0;
    public int combo = 0;
    public int feverPoint = 0;
    public int addingObjLeft = 50;
    static int feverTsumu = 25;

    public List<Type> selectedTsumuTypeList; // 게임에 등장할 쯔무 리스트
    public List<(Type bombType, int min, int max)> comboBombList = new()
    {
        (typeof(NormalBomb), 7, 13),
        (typeof(TimeBomb), 9, 16),
        (typeof(ExpBomb), 11, 18),
        (typeof(CoinBomb), 13, 20),
        (typeof(ScoreBomb), 15, 9999)
    };
    public List<Tsumu> tsumuList = new(); //내가 가지고 있는 모든 쯔무리스트
    public List<Bomb> bombList = new();
}