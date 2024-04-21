using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Base Variables")]
    public float speed = 10;  // Pelaajan nopeus
    public float jumpForce = 100;  // Pelaajan hypyn voimakkuus
    public float jumpCD = 1; // pelaajan hypyn cooldown

    [Header("UI References")]
    public VariableJoystick joystick; // referenssi joystick objektiin liikkumista varten
    public Button jumpBtn; // referenssi hyppy nappiin

    [Header("Respawn")]
    public Transform respawnPoint;

    private List<Pickupable> inventory = new List<Pickupable>(); // pelaajan inventory lista 
    UIManager uiManager;  // referenssi UI manageriin
    Rigidbody2D rb; // referenssi rigidbody komponenttiin
    Vector2 playerInput; // pelaajan liikkumisen input
    bool canJump = true; // tarkistus voidaanko hyp‰t‰ vai ei

    bool canMove = true; // Voidaanko liikuttaa pelaajaa

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>(); // Etsit‰‰n Scenest‰ UIManager (jos ei lˆydy tulee error)
        rb = GetComponent<Rigidbody2D>(); // Otetaan TƒSTƒ objektista Rigidbody2D komponentti talteen
        jumpBtn.onClick.AddListener(Jump); // Lis‰t‰‰n jump nappiin uusi "OnClick" eventti, joka kutsuu pelaajan "Jump" metodia
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            playerInput.x = joystick.Horizontal * speed; // Annetaan playerInput.x arvoksi joystickin antama Horizontal arvo * nopeudella
        }

        playerInput.y = rb.velocity.y; // varmistetaan, ett‰ pelaajan painovoima pysyy aina loogisena
    }

    private void FixedUpdate()
    {
        rb.velocity = playerInput; // liikutetaan pelaajaa playerInput muuttujan avulla
    }

    public void Jump()
    {
        if (canJump && canMove) // Voidaanko hyp‰t‰?
        {
            rb.AddForce(Vector2.up * jumpForce); // jos voidaan, annetaan rigidbodylle voimaa ylˆsp‰in * hypyn voimalla
            canJump = false; // aloitetaan hypyn cooldown
            Invoke("ResetJump", jumpCD); // Metodi ResetJump kutsutaan jumpCD m‰‰ritt‰m‰ll‰ ajan j‰lkeen
        }
    }

    void ResetJump()
    {
        // resetoidaan hypyn cooldown -> pelaaja voi j‰lleen hyp‰t‰
        canJump = true;
    }

    /// <summary>
    /// Kun pelaaja osuu "IsTrigger" collidereihin, t‰m‰ metodi k‰yd‰‰n automaattisesti l‰pi
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jos trigger, johon osuttiin, sis‰lt‰‰ "Pickupable" skriptin
        if (collision.GetComponent<Pickupable>())
        {
            // Lis‰t‰‰n itemi meid‰n inventoryyn
            AddItemToInventory(collision.GetComponent<Pickupable>());
            // Laitetaan fyysinen objekti kent‰ll‰ "Pois p‰‰lt‰" kun ollaan lis‰tty inventoryyn
            collision.gameObject.SetActive(false);
        }
        else if (collision.GetComponent<InterstitialAdExample>()) // Kun pelaaja osuu V‰limainos objektiin -> K‰ynnistet‰‰n v‰limainos
        {
            collision.GetComponent<InterstitialAdExample>().InitializeAdLoad();
        }
        else if (collision.CompareTag("Deathzone")) // Kun pelaaja osuu objektiin jonka Tag on "Deathzone" -> tapetaan pelaaja
        {
            OnDeath();
        }
    }

    // Kun pelaaja kuolee, avataan Death UI Panel ja pistet‰‰n liikkuminen pois p‰‰lt‰
    void OnDeath()
    {
        rb.freezeRotation = false;
        canMove = false;
        uiManager.ToggleOnDeathPanel(true);
    }

    /// <summary>
    /// Kun pelaaja k‰ytt‰‰ "Reward Ad" toimintoa, siirret‰‰n pelaaja "respawn" pisteeseen.
    /// </summary>
    public void RespawnAtPosition()
    {
        uiManager.ToggleOnDeathPanel(false);
        rb.freezeRotation = true;
        canMove = true;
        this.transform.position = respawnPoint.position;
        this.transform.rotation = Quaternion.identity;
    }

    public void AddItemToInventory(Pickupable item)
    {
        // Lis‰t‰‰n itemi inventoryyn
        inventory.Add(item);
        // kutsutaan UIManagerin toimintoa joka lis‰‰ itemin tiedot UI paneeliin n‰kyville
        uiManager.AddInventoryItem(item);
    }
}
