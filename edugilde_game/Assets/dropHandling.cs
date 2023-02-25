using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropHandling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDelayed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}
