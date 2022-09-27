using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        destroy();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * 0.1f);

        if (transform.position.y >= 2f)
        {
            Destroy(gameObject);
        }

    }
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}