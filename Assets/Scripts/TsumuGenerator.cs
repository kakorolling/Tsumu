using NUnit.Framework.Constraints;
using Unity.Collections;
using UnityEngine;

public class TsumuGenerator : MonoBehaviour
{
    public GameObject tsumuPrefab;

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateTsumu(TsumuType tsumuType)
    {
        float randomX = Random.Range(-2f, 2f);
        Vector3 randomVec3 = new Vector3(randomX, 0, 0);
        GameObject tsumuObj = Instantiate(tsumuPrefab, transform.position + randomVec3, Quaternion.identity);
        tsumuObj.GetComponent<Tsumu>().type = tsumuType;
    }


}
