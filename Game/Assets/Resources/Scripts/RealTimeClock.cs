using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeClock : MonoBehaviour
{
    public Text teksWaktu;
    public Transform sunTransform;
    public Light sun;
    public float time, intensity;
    public int days;
    public Color fogDay = Color.grey, fogNight = Color.black;
    
    // Update is called once per frame
    void Update ()
    {
        string waktu = waktuSekarang();

        string[] tempWaktu = waktu.Split(":"[0]);

        if(Convert.ToInt32(tempWaktu[1]) < 10)
            teksWaktu.text = tempWaktu[0] + ":0" + tempWaktu[1];
        else
            teksWaktu.text = tempWaktu[0] + ":" + tempWaktu[1];

        time = Convert.ToInt32(tempWaktu[0]) * Convert.ToInt32(tempWaktu[1]) * 60;

        Debug.Log("Time : " + time);

        sunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));

        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity = 1 - ((43200 - time) / 43200 * -1);
        }

        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);

        sun.intensity = intensity;
    }
    /*
    TimeSpan getTimeSpan()
    {

    }*/

    string waktuSekarang()
    {
        DateTime sekarang = DateTime.Now;

        return sekarang.Hour + ":" + sekarang.Minute;
    }
}
