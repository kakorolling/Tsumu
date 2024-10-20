using UnityEngine;

public class NormalBomb : Bomb
{

    public override void ExecuteBomb(Stage stage)
    {
        Debug.Log(GetType().Name);
    }
}