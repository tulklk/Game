using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI timeText;        // Hiển thị thời gian còn lại
    public TextMeshProUGUI countdownText;  // Text hiển thị đếm ngược
    public TextMeshProUGUI  textToRaceText;
    public float countdownTime = 3f;       // Thời gian đếm ngược (3 giây)
    private bool gameStarted = false;      // Kiểm tra trạng thái trò chơi
    public AudioClip redLightSound;
public AudioClip yellowLightSound;
public AudioClip greenLightSound;
private AudioSource audioSource;

    // Thêm các biến ánh sáng
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Tắt tất cả đèn khi bắt đầu
        TurnOffAllLights();
        // Bắt đầu đếm ngược khi vào game
        StartCoroutine(CountdownBeforeStart());
        
    }

    void Update()
    {
        if (gameStarted)
        {
            HienThiThoiGianGame();
        }
    }

    IEnumerator CountdownBeforeStart()
    {
        audioSource.PlayOneShot(redLightSound);
        redLight.SetActive(true);
        
       

        // Đếm ngược từ 3
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;

            // Đổi ánh sáng theo thời gian
            if (countdownTime == 2)
            {
                Debug.Log("Yellow light sound is playing");
                audioSource.PlayOneShot(yellowLightSound);
                redLight.SetActive(false);
                yellowLight.SetActive(true); // Hiển thị đèn vàng
                
                Debug.Log("Yellow light is ON");
            }
            else if (countdownTime == 1)
            {
                audioSource.PlayOneShot(greenLightSound);
                yellowLight.SetActive(false);
                greenLight.SetActive(true); // Hiển thị đèn xanh
                
                Debug.Log("Green light is ON");
            }
        }

        // Hiển thị chữ "Xuất Phát!" với hiệu ứng
        countdownText.SetText("Xuất Phát!");
        countdownText.fontSize = 80; // Tăng kích thước font
        countdownText.color = Color.red;
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false); // Ẩn text
        gameStarted = true;
    }

    public void HienThiThoiGianGame()
    {
        // Cập nhật thời gian cho phép về đích từ GameManager
        textToRaceText.SetText("Thời gian còn lại ");
        timeText.SetText(Mathf.FloorToInt(GameManager.Instance.thoiGianChoPhepVeDich).ToString());
        
    }

    public void ChoiLai()
    {
        SceneManager.LoadScene("Game");
    }

    public void VeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void TurnOffAllLights()
    {
        // Tắt tất cả ánh sáng đèn giao thông
        redLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);
    }
}
