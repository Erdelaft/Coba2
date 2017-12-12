using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Variabel untuk jam realtime
    public float time;
    public TimeSpan currentTime;
    public Transform sunTransform;
    public Light sun;
    public Text timeText;
    public int days;
    LightmapSettings dayNight;

    public float intensity;
    public Color fogDay = Color.grey, fogNight = Color.black;

    public int speed = 75;
    // Variabel untuk jam realtime

    // Variabel untuk icon
    public Image iconCycle;
    float num;
    // Variabel untuk icon

    // Use this for initialization
    void Start ()
    {
        num = speed / 24f * 43200f;
        num /= 43200f;

        iconCycle.fillAmount = time / 43200f;
        Debug.Log("Icon = " + iconCycle.fillAmount + ", Num = " + num + ", Time = " + time);
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeTime();
	}

    public void ChangeTime()
    {
        time += speed * Time.deltaTime;

        if(time > 86400)
        {
            days += 1;
            time = 0;
        }

        currentTime = TimeSpan.FromSeconds(time);

        //Debug.Log( "Current Time : " + currentTime);

        string[] tempTime = currentTime.ToString().Split(":"[0]);
        timeText.text = tempTime[0] + ":" + tempTime[1];

        sunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));

        iconCycle.fillAmount = ((time / 43200f) - 0.5f) / 2f * (1f);

        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity = 1 - ((43200 - time) / 43200 * -1);

            
        }

        if(iconCycle.fillAmount == 1)
        {
            iconCycle.fillAmount = num;
        }

        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);

        sun.intensity = intensity;
    }
}
