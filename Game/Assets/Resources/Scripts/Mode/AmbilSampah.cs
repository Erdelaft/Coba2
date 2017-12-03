using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbilSampah : MonoBehaviour
{
    public RectTransform objekRange;
    public Image areaImage;
    public GameObject[] objekSampah;
    public float delayMuncul = 12f, lokasiSampah = 1.5f;
    public int[] rangeJumlahSampah;
    float areaSampahX;
    float areaSampahZ;
    int jumlahSampah;
    int n;

    // Use this for initialization
    void Start ()
    {
        int num;
        areaSampahX = objekRange.rect.max.x;
        areaSampahZ = objekRange.rect.max.y;

        jumlahSampah = Random.Range(rangeJumlahSampah[0], rangeJumlahSampah[1]);
        
        for(int i = 0; i < jumlahSampah; i++)
        {
            num = Random.Range(0, objekSampah.Length);      // Random objek sampah

            Instantiate(objekSampah[num], new Vector3(Random.Range(-areaSampahX, areaSampahX), lokasiSampah, Random.Range(-areaSampahZ, areaSampahZ)), Quaternion.identity);
        }
        
        Debug.Log("x = " + Random.Range(4f, areaSampahX) + "/nz = " + Random.Range(4f, areaSampahZ));
    }
	
}
