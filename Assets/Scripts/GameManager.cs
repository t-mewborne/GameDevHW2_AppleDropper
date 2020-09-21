using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameManager() { }

    private int score = 0;
    private int baskets = 3;
    public TMPro.TextMeshProUGUI scoreText;

    public GameObject basket;
    private float startX = -7f;
    private float startY = -3.3f;
    private float dy = 0.7f;
    private float minX = -7f;
    private float maxX = 7f;
    [SerializeField] private List<GameObject> basketList;

    void Awake() {
        if (instance) Destroy(gameObject);
        else instance = this;
    }
    
    void Start()
    {
        score = 0;
        baskets = 0;
        basketList = new List<GameObject>();
        AddBasket();
        AddBasket();
        AddBasket();
    }

    void Update()
    {
        if (baskets==0) {
            GameOver();
        } else {
            scoreText.text = "Score: " + score;
        }
    }

    private void GameOver(){
        scoreText.text = "";
        SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
    }

    public void Restart() {
        SceneManager.UnloadSceneAsync("GameOver");
        score = 0;
        AddBasket();
        AddBasket();
        AddBasket();
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
