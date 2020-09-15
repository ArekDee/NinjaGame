using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    PowersController powersController;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        powersController = FindObjectOfType<PowersController>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody" && powersController.GetAutoPlay())
        {
            Debug.Log("działa");
            gameController.JumpOnClick();
        }
    }
}
