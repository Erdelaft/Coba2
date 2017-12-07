using UnityEngine;
using UnityEngine.UI;

public class AmbilSampah : MonoBehaviour
{
    public RectTransform objekRange;
    public Image areaImage;
    public GameObject[] objekSampah;
    public Text jumlahSampahDiAmbil;
    public float delayMuncul = 12f, lokasiSampah = 1.5f;
    public int[] rangeJumlahSampah;
    public string[] tempSkor;
    public string teksSkor;

    GameObject kumpulanSampah;
    float areaSampahX, areaSampahZ;
    int jumlahSampah, skorSampahDiAmbil;
    int n;

    // Use this for initialization
    void Start ()
    {
        //jumlahSampahDiAmbil = GetComponent<Text>();

        int num;
        areaSampahX = objekRange.rect.max.x;
        areaSampahZ = objekRange.rect.max.y;

        jumlahSampah = Random.Range(rangeJumlahSampah[0], rangeJumlahSampah[1]);
        
        for(int i = 0; i < jumlahSampah; i++)
        {
            num = Random.Range(0, objekSampah.Length);      // Random objek sampah

            kumpulanSampah = Instantiate(objekSampah[num], new Vector3(Random.Range(-areaSampahX, areaSampahX), lokasiSampah, Random.Range(-areaSampahZ, areaSampahZ)), Quaternion.identity) as GameObject;
            kumpulanSampah.tag = "Sampah";
            kumpulanSampah.AddComponent<Rigidbody>();
            kumpulanSampah.AddComponent<Collider>();
        }
        /*
        teksSkor = jumlahSampahDiAmbil.text;
        //Debug.Log( "Teks Skor : " + teksSkor );

        tempSkor = teksSkor.Split("/"[0]);
        tempSkor[0] = skorSampahDiAmbil.ToString();
        tempSkor[1] = jumlahSampah.ToString();

        jumlahSampahDiAmbil.text = tempSkor[0] + " / " + tempSkor[1];
        */
        Debug.Log("x = " + Random.Range(4f, areaSampahX) + "/nz = " + Random.Range(4f, areaSampahZ));
    }

    void Update()
    {
        teksSkor = jumlahSampahDiAmbil.text;
        //Debug.Log( "Teks Skor : " + teksSkor );

        tempSkor = teksSkor.Split("/"[0]);
        tempSkor[0] = skorSampahDiAmbil.ToString();
        tempSkor[1] = jumlahSampah.ToString();

        jumlahSampahDiAmbil.text = tempSkor[0] + " / " + tempSkor[1];

    }
    
}
