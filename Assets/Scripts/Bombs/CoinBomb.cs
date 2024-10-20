using UnityEngine;

public class CoinBomb : Bomb
{
    public override void ExecuteBomb(Stage stage)
    {
        Debug.Log(GetType().Name);
    }
}
