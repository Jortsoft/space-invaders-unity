using TMPro;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int health = 20;
    [SerializeField] private TextMeshProUGUI counterText;

    private void Start()
    {
        counterText.text = health.ToString();
    }

    public void Demage()
    {
        health--;
        counterText.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
