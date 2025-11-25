using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDialogueChoiceController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Choice;
    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private DialogueNode m_ChoiceNextNode;

    public DialogueChoice choice
    {
        set
        {
            m_Choice.text = value.ChoicePreview;
            m_ChoiceNextNode = value.ChoiceNode;
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }


    private void OnClick() 
    {
        m_DialogueChannel.RaiseRequestDialogueNode(m_ChoiceNextNode);
    }

}
