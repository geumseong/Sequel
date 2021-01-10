using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public bool lsj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !lsj)
        {
            UIManager.Instance.DisplayInteractable();
            CarController.Instance.SetOnTrigger(true, GetComponent<MiniGame>());
        }
        else
        {
            UIManager.Instance.DisplayNonInteractable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !lsj)
        {
            UIManager.Instance.HideInteractable();
            CarController.Instance.SetOnTrigger(false, null);
        }
        else
        {
            UIManager.Instance.HideNonInteractable();
        }
    }
}
