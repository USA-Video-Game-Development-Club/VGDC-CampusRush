/* Name: Savannah Hebert
 * Date: 03/20/2023
 *
 * Note:
 *  Used YouTube video at web address https://www.youtube.com/watch?v=HLz_k6DSQvU for help with code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    bool stopWatch_On = false;
    float currentTime;
    public int startMinutes;
    public TextMeshProUGUI currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        startTime();
        currentTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stopWatch_On == true) { 
            currentTime = currentTime + Time.fixedDeltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void startTime() {
        stopWatch_On = true;
    }

    public void stopTime() {
        stopWatch_On = false;
    }

    public float getTime(){
        return currentTime;
    }
}
