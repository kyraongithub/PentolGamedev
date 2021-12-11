using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public Color red => Color.red;
    public Color white => Color.white;
    void Update()
    {
        gameObject.GetComponent<Text>().color = Lerp(white, red, 4);
    }
    public Color Lerp(Color firstColor, Color secondColor, float speed) => Color.Lerp(firstColor, secondColor, Mathf.Sin(Time.time * speed));
}
