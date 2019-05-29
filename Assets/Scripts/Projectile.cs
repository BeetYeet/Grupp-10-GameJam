
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 10;
    public float range = 4, randRange = 1;

    private float deractionX, deractionY;

    // Start is called before the first frame update
    void Start()
    {
        float v = transform.localRotation.z * 0.0174533f;
        deractionX = Mathf.Sin(v) * speed;
        deractionY = Mathf.Cos(v) * speed;
        Destroy(gameObject, range + Random.Range(0, randRange));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(deractionX*Time.deltaTime, deractionY * Time.deltaTime));
    }
}
