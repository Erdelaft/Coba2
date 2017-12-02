using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbilSampah : MonoBehaviour
{
    public RectTransform objekRange;
    public Image areaImage;
    public int jumlahSampah;
    public GameObject[] objekSampah;
    public float delayMuncul = 12f;
    float areaSampahX;
    float areaSampahZ;

    // Use this for initialization
    void Start ()
    {
        int num;
        areaSampahX = objekRange.rect.max.x;
        areaSampahZ = objekRange.rect.max.y;

        jumlahSampah = Random.Range(15, 30);
        
        for(int i = 0; i < jumlahSampah; i++)
        {
            num = Random.Range(0, objekSampah.Length);      // Random objek sampah

            Instantiate(objekSampah[num], new Vector3(Random.Range(-areaSampahX, areaSampahX), 3f, Random.Range(-areaSampahZ, areaSampahZ)), Quaternion.identity);
        }

        //Destroy(objekSampah[num], 13f * Time.deltaTime);
        Debug.Log("x = " + Random.Range(4f, areaSampahX) + "/nz = " + Random.Range(4f, areaSampahZ));
    }
	
}
