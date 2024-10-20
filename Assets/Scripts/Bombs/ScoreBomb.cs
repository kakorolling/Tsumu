using UnityEngine;

public class ScoreBomb : Bomb
{
    public override void ExecuteBomb(Stage stage)
    {
        Debug.Log(GetType().Name);
    }
}
