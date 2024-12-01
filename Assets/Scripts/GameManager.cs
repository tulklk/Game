using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float thoiGianChoPhepVeDich = 40f; 
    public bool ketThucGame = false;         
    public bool winGame = false;             
    private static GameManager instance;      

    public GameObject gameOverObject;         
    public GameObject timeGameObject;         
    public GameObject winGameObject;   
    public GameObject textToRaceTextObject;       
    public GameObject countdownTextObject;    
    [SerializeField]
    private float thoiGianHoiKhiQuaCheckPoint = 41f; 
    [SerializeField]
    public float countdownTime = 3f;         
    

    public AudioClip winSound;                       
    private AudioSource audioSource;          

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject gameManagerGameObject = new GameObject("GameManager");
                    instance = gameManagerGameObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (!ketThucGame && !winGame)
        {
            thoiGianChoPhepVeDich -= Time.deltaTime;
            Debug.Log(thoiGianChoPhepVeDich);

            if (thoiGianChoPhepVeDich <= 0)
            {
                timeGameObject.SetActive(false);
                gameOverObject.SetActive(true);
                KetThucGame();
                textToRaceTextObject.SetActive(false);
            }
        }

        if (winGame)
        {
            timeGameObject.SetActive(false);
            winGameObject.SetActive(true);
        }
    }

    public void KetThucGame()
    {
        ketThucGame = true;
        textToRaceTextObject.SetActive(false);
        // if (gameOverSound != null)
        // {
        //     audioSource.PlayOneShot(gameOverSound);
        // }
    }

    public void QuaCheckPoint()
    {
        if (!ketThucGame)
        {
            thoiGianChoPhepVeDich = thoiGianHoiKhiQuaCheckPoint;
        }
    }

    public void QuaWinPoint()
    {
        if (!ketThucGame)
        {
            winGame = true;
            if (winSound != null)
            {
                audioSource.PlayOneShot(winSound);
            }
        }
    }

    IEnumerator StartCountdown()
    {
        TextMesh countdownText = countdownTextObject.GetComponent<TextMesh>();
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString("0");
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownText.text = "Xuất Phát ! ";
        yield return new WaitForSeconds(1f);
        countdownTextObject.SetActive(false); // Ẩn UI đếm ngược
    }
}
