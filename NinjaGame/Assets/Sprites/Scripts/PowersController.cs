using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersController : MonoBehaviour
{
    public Player player;
    bool autoPlay;
    bool noShuriken;

    public Text power1AmountText;
    public Text power2AmountText;
    public Text power3AmountText;
    public Button power1Button;
    public Button power2Button;
    public Button power3Button;
    int power1Amount, power2Amount, power3Amount;
    // Start is called before the first frame update
    void Start()
    {
        autoPlay = false;
        noShuriken = false;

        power1Amount = GameInfoController.GetPowerAmount(1);
        if(power1Amount == 0)
        {
            power1Button.interactable = false;
        }
        power2Amount = GameInfoController.GetPowerAmount(2);
        if (power2Amount == 0)
        {
            power2Button.interactable = false;
        }
        power3Amount = GameInfoController.GetPowerAmount(3);
        if (power3Amount == 0)
        {
            power3Button.interactable = false;
        }
        UpdatePowersAmount();
    }

    // Update is called once per frame
    void Update()
    {
        if (power1Amount <= 0)
        {
            power1Button.interactable = false;
        }
        if (power2Amount <= 0)
        {
            power2Button.interactable = false;
        }
        if (power3Amount <= 0)
        {
            power3Button.interactable = false;
        }
    }
    void UpdatePowersAmount()
    {
        power1AmountText.text = power1Amount.ToString();
        power2AmountText.text = power2Amount.ToString();
        power3AmountText.text = power3Amount.ToString();
    }

    public void Dash()
    {
        if (player.grounded)
        {
            
            player.myRigidbody2D.AddForce(Vector3.right * player.slideForce, ForceMode2D.Impulse);
            player.myAnimator.SetTrigger("Slide");
        }
        StartCoroutine("DashCorutine");
        power1Amount -= 1;
        UpdatePowersAmount();
    }
    IEnumerator DashCorutine()
    {
        power1Button.interactable = false;
        yield return new WaitForSeconds((float)0.3);
        power1Button.interactable = true;
    }
    public void AutoPlay()
    {
        StartCoroutine("AutoPlayCorutine");
        power3Amount -= 1;
        UpdatePowersAmount();
    }
    IEnumerator AutoPlayCorutine()
    {
        autoPlay = true;
        power3Button.interactable = false;
        yield return new WaitForSeconds(12.5f);
        autoPlay = false;
        power3Button.interactable = true;
    }
    public  bool GetAutoPlay()
    {
        return autoPlay;
    }

    public void NoShuriken()
    {
        StartCoroutine("NoShurikenCorutine");
        power2Amount -= 1;
        UpdatePowersAmount();
    }
    IEnumerator NoShurikenCorutine()
    {
        noShuriken = true;
        power2Button.interactable = false;
        yield return new WaitForSeconds(5);
        noShuriken = false;
        power2Button.interactable = true;
    }
    public bool GetNoShuriken()
    {
        return noShuriken;
    }
}
