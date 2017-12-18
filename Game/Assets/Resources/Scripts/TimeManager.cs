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
    public Material daySky1, nightSky1, daySky2, nightSky2;

    public float intensity;
    public Color fogDay = Color.grey, fogNight = Color.black;
    
    public int speed = 75;
    public int days = 0;
    float num;
    GameObject[] lampuJalan;

    // Use this for initialization
    void Start ()
    {
        num = speed / 24f * 43200f;
        num /= 43200f;
        lampuJalan = GameObject.FindGameObjectsWithTag("LampuJalan");
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeTime();
	}

    public void ChangeTime()
    {
        time += speed * Time.deltaTime;

        if(time > 86400)        // Berganti Hari
        {
            days += 1;
            time = 0;
        }

        currentTime = TimeSpan.FromSeconds(time);

        //Debug.Log( "Current Time : " + currentTime);

        string[] tempTime = currentTime.ToString().Split(":"[0]);
        timeText.text = tempTime[0] + ":" + tempTime[1];

        sunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));      // Rotasi Matahari

        if (time > 21600 && time < 64800)
        {
            intensity = 0.75f - (43200 - time) / 43200;
            lampuJalan[0].SetActive(false);
            lampuJalan[1].SetActive(false);
            lampuJalan[2].SetActive(false);
            lampuJalan[3].SetActive(false);
            RenderSettings.skybox = daySky1;                 // Berganti material ketika siang hari


        }
        if(time < 21600 || time > 64800)
        {
            intensity = 1 - ((43200 - time) / 43200 * -1);
            lampuJalan[0].SetActive(true);
            lampuJalan[1].SetActive(true);
            lampuJalan[2].SetActive(true);
            lampuJalan[3].SetActive(true);
            RenderSettings.skybox = nightSky2;               // Berganti material ketika malam hari
        }
        
        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);          // Perubahan warna matahari diantara 2 warna
        sun.intensity = intensity;
    }
}
