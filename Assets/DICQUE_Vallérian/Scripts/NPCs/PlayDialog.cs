using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayDialog : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private GameObject dialogPanel;

    [Header("Dialog data")]
    public string npc_name;
    public string dialog = "Hello world!";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);

            nameText.text = npc_name;
            dialogText.text = dialog;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(false);
        }
    }
}
