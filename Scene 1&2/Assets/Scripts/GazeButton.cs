using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GazeButton : MonoBehaviour {

    public UnityEvent OnGazeClick;
    public Image ButtonImage;
    public Text text;
    //public Button button;
    public float GazeTriggerTime = 3f;
    private bool isLoading = false;
    private float counter;


    // Update is called once per frame
    void Update () {
		if(isLoading)
        {
            counter += Time.deltaTime;
            ButtonImage.fillAmount = counter / GazeTriggerTime;
            if(counter > GazeTriggerTime)
            {
                OnGazeClick.Invoke();
                isLoading = false;
            }
        }
        if(ButtonImage.fillAmount >= 1)
        {
            ButtonImage.gameObject.SetActive(false);
            SceneManager.LoadScene("PwCFuture");
        }
	}

    public void OnGazeEnter()
    {
        isLoading = true;
        text.text = "Loading";
        //button.gameObject.SetActive(false);
    }

    public void OnGazeExit()
    {
        isLoading = false;
        ButtonImage.fillAmount = 0;
        counter = 0;
        text.text = "Start";
        //button.gameObject.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("PwC Future");
    }

}
