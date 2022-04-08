using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField] GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float rnd = Random.Range(-0.15f, 0.8f);
            GameObject newPipe = Instantiate(pipe, new Vector3(1, 1 * rnd, 0), Quaternion.identity);
            yield return new WaitForSecondsRealtime(1.0f);
            Destroy(newPipe, 5.0f);
        }
    }
}
