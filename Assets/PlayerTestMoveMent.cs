using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMoveMent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * x * 10 * Time.deltaTime);
    }
}
