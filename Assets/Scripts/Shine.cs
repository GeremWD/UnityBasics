using UnityEngine;

public class Shine : MonoBehaviour
{
    public float maxIntensity, minIntensity;
    public float speed;

    private Light shiningLight;

    // Start is called before the first frame update
    void Start()
    {
        shiningLight = GetComponentInChildren<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        shiningLight.intensity = minIntensity + Mathf.PingPong(speed * Time.time, maxIntensity);
    }
}
