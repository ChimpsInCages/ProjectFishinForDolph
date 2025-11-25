using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDialogueTextBoxController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_SpeakerText;
    [SerializeField]
    private TextMeshProUGUI m_DialogueText;

    [SerializeField]
    private RectTransform m_ChoicesBoxTransform;
    [SerializeField]
    private UIDialogueChoiceController m_ChoiceControllePrefab;

    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private bool m_ListenToInput;
    private DialogueNode m_NextNode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;

        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ListenToInput && Input.GetButtonDown("Submit"))
        {
            m_DialogueChannel.RaiseRequestedDialogueNode(m_NextNode);
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        m_DialogueText.text = node.DialogueLine.Text;
        m_SpeakerText.text = node.DialogueLine.Speaker.CharacterName;

        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        m_NextNode = null;
        m_ListenToInput = false;
        m_DialogueText.text = "";
        m_SpeakerText.text = "";

        foreach (Transform child in m_ChoicesBoxTransform)
        {
            Destroy(child.gameObject);
        }

        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    public void Visit(BasicDialogueNode node)
    {
        m_ListenToInput = true;
        m_NextNode = node.NextNode;
    }
    public void Visit(ChoiceDialogueNode node)
    {
        m_ChoicesBoxTransform.gameObject.SetActive(true) ;

        foreach (DialogueChoice choice in node.Choices)
        {
            UIDialogueTextBoxController newChoice = Instantiate(m_ChoiceControllePrefab, m_ChoicesBoxTransform);
            newChoice.Choice = choice;
        }
    }
}
