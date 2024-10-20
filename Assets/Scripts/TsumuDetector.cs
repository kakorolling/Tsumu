using System.Collections.Generic;
using UnityEngine;

public class TsumuDetector : MonoBehaviour
{

    //충돌되고 있는 쯔무가 뭐있는지 알고있어야함
    public List<Tsumu> tsumuList;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Tsumu tsumu = collider.gameObject.GetComponent<Tsumu>();
        if (tsumu != null)
        {
            tsumuList.Add(tsumu);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Tsumu tsumu = collider.gameObject.GetComponent<Tsumu>();
        if (tsumu != null)
        {
            tsumuList.Remove(tsumu);
        }
    }
}
