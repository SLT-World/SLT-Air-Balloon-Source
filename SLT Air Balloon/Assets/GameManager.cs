using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Obstacles;

    [SerializeField] float InstantiationRate = 0.5f;
    [SerializeField] float Padding = 10;

    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject LoseScreen;

    float InstantiationTime;

    public bool Started;

    public Transform Player;

    private void Start()
    {
        Player = FindObjectOfType<Player>().transform;
        Player.GetComponent<Player>().Speed = 0;
    }

    private void Update()
    {
        if (Started)
        {
            if (!Player)
            {
                LoseScreen.SetActive(true);
                return;
            }

            Player.GetComponent<Player>().Speed = 5;
            if (Time.time >= InstantiationTime)
            {
                Vector2 Position = new Vector2(Random.Range(-12.5f, 12.5f), Player.position.y + Padding);
                Instantiate(Obstacles[Random.Range(0, Obstacles.Count)], Position, Quaternion.identity);
                InstantiationTime = Time.time + InstantiationRate;
            }

            Vector3 OriginOffset = Player.position;
            OriginOffset.x = 0;
            float Distance = OriginOffset.magnitude;
            if (Distance > 5)
            {
                var _Transforms = FindObjectsOfType<Collider>().Select(item => item.transform).ToArray();
                for (int i = 0; i < _Transforms.Length; i++)
                {
                    _Transforms[i].position -= OriginOffset;
                }
            }
        }
    }

    public void StartGame()
    {
        StartScreen.SetActive(false);
        Started = transform;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
