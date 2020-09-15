using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    CircleCollider2D myCircleCollider2D;
    public AudioClip pickCoin;
    // Start is called before the first frame update
    void Start()
    {
        myCircleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            FindObjectOfType<GameController>().AddCoin(1);
            AudioSource.PlayClipAtPoint(pickCoin, Camera.main.transform.position, MusicController.GetMusicVolume());
            Destroy(this.gameObject);
        }
    }
}
