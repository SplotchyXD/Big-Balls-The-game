using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Transform inventoryContentPanel; // referenssi inventory content osioon, johon itemUI prefab spawnataan
    public GameObject itemUIPrefab; // referenssi itemUI objektiin joka on tallennettu prefabiksi

    public GameObject OnDeathUIPanel;

    // Kun pelaajan inventoryyn lis‰t‰‰n itemi, lis‰t‰‰n se myˆs t‰t‰ kautta inventory ui listalle. T‰t‰ kutsutaan PlayerControllerista
    public void AddInventoryItem(Pickupable item)
    {
        // synnytet‰‰n uusi UI objekti "inventoryContent" objektin lapseksi
        GameObject newItemUI = Instantiate(itemUIPrefab, inventoryContentPanel);
        // Haetaan synnytetyst‰ itemUI objektista TextMeshPro komponentti ja muokataan sen teksti‰ annetun pickupable itemin nimell‰ ja valuella
        newItemUI.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName + " (" + item.value + ")";
    }

    public void ToggleOnDeathPanel(bool t)
    {
        OnDeathUIPanel.SetActive(t);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
