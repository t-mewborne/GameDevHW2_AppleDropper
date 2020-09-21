using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameManager() { }
    private int score = 0;
    private int highscore;
    private int baskets = 3;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject basket;
    private float startX = -7f;
    private float startY = -3.3f;
    private float dy = 0.7f;
    [SerializeField] private List<GameObject> basketList;
    private bool end = false;

    void Awake() {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    void Start() {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = 0;
        baskets = 0;
        basketList = new List<GameObject>();
        AddBasket();
        AddBasket();
        AddBasket();
    }

    void Update()
    {
        if (baskets<=0) {
            GameOver();
        } else {
            scoreText.text = "Score: " + score;
        }
    }

    private void GameOver(){
        if (!end) {
            end = true;
            scoreText.text = "";
            if (score > highscore) PlayerPrefs.SetInt("highscore", score);
            SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }

    public void Restart() {
        SceneManager.UnloadSceneAsync("GameOver");
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = 0;
        end = false;
        AddBasket();
        AddBasket();
        AddBasket();
        Time.timeScale = 1;
    }

    public int GetScore() {
        return score;
    }

    public void AddPoint() {
        score++;
    }

    public void RemoveBasket(){
        if (baskets>0) {
            baskets--;
            Destroy(basketList[baskets]);
            basketList.RemoveAt(baskets);
        }
    }

    public bool GameEnd() {
        return end;
    }

    private void AddBasket(){
        basketList.Add(Instantiate(basket, new Vector3(startX,startY + dy*baskets,0), Quaternion.identity));
        baskets++;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //if ("OutOfBounds".Equals(collision.gameObject.tag))RemoveBasket();
        if ("Apple".Equals(collision.gameObject.tag)) RemoveBasket();
    }
}
