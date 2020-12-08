using UnityEngine;

public class Shine : MonoBehaviour
{
    public float maxIntensity, minIntensity;
    public float speed;

    private new Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        light.intensity = minIntensity + Mathf.PingPong(speed * Time.time, maxIntensity);
    }
}
