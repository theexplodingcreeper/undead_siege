using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UndeadSelector : MonoBehaviour
{
    [SerializeField] private Slider undeadSlider;
    [SerializeField] private TMP_Text chosenUndeadText;
    [SerializeField] private TMP_Text maxUndeadText;
    [SerializeField] private Button startSiegeButton;
    [SerializeField] private armyDesignation undeadArmy;
    [SerializeField] private GameObject preSiegePanel; // Reference to the UI overlay panel

    private int maxUndead;
    private int available_troops;

    private SiegeControler siegeController;

    void Start()
    {
        available_troops = gamescript.available_undead - gamescript.reseachers - gamescript.forge - gamescript.gatheres;
        maxUndead = available_troops;


        // Set slider limits
        undeadSlider.minValue = 0;
        undeadSlider.maxValue = maxUndead;
        undeadSlider.value = 0; 

        UpdateUI();

        // Find the SiegeController in the scene
        siegeController = FindObjectOfType<SiegeControler>();

        // Add listeners
        undeadSlider.onValueChanged.AddListener(delegate { UpdateUI(); });
        startSiegeButton.onClick.AddListener(StartSiege);
    }

    void UpdateUI()
    {
        int chosenUndead = Mathf.RoundToInt(undeadSlider.value);
        chosenUndeadText.text = $"Undead to Send: {chosenUndead}";
        maxUndeadText.text = $"Max Available: {maxUndead}";

        if (undeadArmy.units.Count > 0)
        {
            undeadArmy.units[0] = new armyDesignation.unit { amount = chosenUndead, type = undeadArmy.units[0].type };
        }
    }

    void StartSiege()
    {
        gamescript.undeadToSend = Mathf.RoundToInt(undeadSlider.value); 

        if (siegeController != null)
        {
            Debug.Log($"Siege Started! Sending {gamescript.undeadToSend} undead.");
            siegeController.undeadArmy = undeadArmy;
            siegeController.BeguinSiege();
        }
        else
        {
            Debug.LogError("SiegeControler not found in the scene!");
        }

        // Hide the Pre-Siege UI
        if (preSiegePanel != null)
        {
            preSiegePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("PreSiegePanel not assigned!");
        }
    }
}
