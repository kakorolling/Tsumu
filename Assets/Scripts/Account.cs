using System;
using System.Collections.Generic;

public class Account
{
    public int level = 1;
    int exp = 0;
    int deltaexp = 0;
    public int coin = 0;
    public int jewel = 0;
    public int heart = 0;

    public int highscore; //그외에 기록할 것들 전부 기록

    public List<Type> tsumuTypeList; //내가 가지고 있는 모든 쯔무리스트
}