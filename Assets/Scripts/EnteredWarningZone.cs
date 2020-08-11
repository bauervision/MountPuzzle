using UnityEngine;
using UnityEngine.UI;

public class EnteredWarningZone : MonoBehaviour
{




    private void Awake()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // trigger item warning
            //show the panel
            InteractionManager.TriggerWarning();


        }
    }
    private void OnTriggerExit(Collider other)
    {

        InteractionManager.HideWarning();
    }

    void FadeEffect()
    {
        //notifyPanel.GetComponent<Image>().color = OffColor;
        // if (notifyText != null)
        // {
        //     notifyText.color = Color.Lerp(endColor, startColor, timer);

        //     if (timer < 1)
        //         timer += Time.deltaTime / fadeDuration;

        //     if (notifyText.color.a >= 1)
        //     {
        //         fade = false;
        //         timer = 0f;
        //     }

        // }
    }
}
