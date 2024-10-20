using Unity.VisualScripting;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    Stage stage;
    public void Init(Stage stage)
    {
        this.stage = stage;
        stage.addingObjLeft--;
    }
    void OnDestroy()
    {
        stage.bombList.Remove(this);
    }

    public abstract void ExecuteBomb(Stage stage);
}

