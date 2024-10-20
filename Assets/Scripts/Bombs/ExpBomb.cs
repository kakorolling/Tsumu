using UnityEngine;

public class ExpBomb : Bomb
{
    public override void ExecuteBomb(Stage stage)
    {
        Debug.Log(GetType().Name);
    }
}
