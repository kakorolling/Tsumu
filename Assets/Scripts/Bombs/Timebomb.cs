using UnityEngine;

public class TimeBomb : Bomb
{
    public override void ExecuteBomb(Stage stage)
    {
        stage.timer += 2;
        Debug.Log(GetType().Name);
    }
}