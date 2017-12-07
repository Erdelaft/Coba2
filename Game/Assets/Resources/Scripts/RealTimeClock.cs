using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeClock : MonoBehaviour
{
    public Text teksWaktu;
    public Transform sunTransform;
    public Light sun;   // 1
    public float speedTime = 1f;

    [SerializeField]
    [Range(0, 1)]
    public float time = 0;
    float currentTime = 1f, intensity, fullday = 120f;         // 4, 5, 2
    //int days;
    Color fogDay = Color.grey, fogNight = Color.black;
    
    void Start()
    {
        intensity = sun.intensity;
    }

    // Update is called once per frame
    void Update ()
    {
        
        string waktu = waktuSekarang();

        string[] tempWaktu = waktu.Split(":"[0]);

        if(Convert.ToInt32(tempWaktu[1]) < 10)
            teksWaktu.text = tempWaktu[0] + ":0" + tempWaktu[1];
        else
            teksWaktu.text = tempWaktu[0] + ":" + tempWaktu[1];

        time = ((Convert.ToInt32(tempWaktu[0]) * 3600f) + (Convert.ToInt32(tempWaktu[1]) * 60f)) / speedTime;

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
        

        // Version 2
        /*
        UpdateSun();

        time += (Time.deltaTime / fullday) * currentTime;

        if(time >= 1)
        {
            time = 0;
        }
        */

    }
/*
    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((time * 360f) -90, 170, 0);

        float intensityMultiplier = 1f;

        if(time <= 0.23f || time >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if(time <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((time - 0.23f) * (1 / 0.02f));
        }
        else if (time >= 0.75f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - (time - 0.73f) * (1 / 0.02f));
        }

        sun.intensity = intensityMultiplier * intensity;
    }
*/
    string waktuSekarang()
    {
        DateTime sekarang = DateTime.Now;

        return sekarang.Hour + ":" + sekarang.Minute;
    }
}
