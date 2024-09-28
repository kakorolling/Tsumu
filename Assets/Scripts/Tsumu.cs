using UnityEngine;

public class Tsumu : MonoBehaviour
{
    TsumuType _type;
    public TsumuType type
    {
        get { return _type; }
        set
        {
            GetComponent<SpriteRenderer>().color = value.color;
            _type = value;
        }
    }

}
