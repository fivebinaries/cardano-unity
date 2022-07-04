using System.Collections;
using System.Runtime.InteropServices;

using UnityEngine;
using UnityEngine.UI;

using Blockfrost;
using CardanoBech32;

public class Demo : MonoBehaviour {

    [SerializeField]
    public Configuration myConfiguration;

    private API client;
    private Console console;
    private UI ui;

    [DllImport("__Internal")]
    private static extern void LoadBaseAddress();

    [DllImport("__Internal")]
    private static extern void ClearBaseAddress();

    [DllImport("__Internal")]
    private static extern string GetBaseAddress();

    public string Address { get; protected set; }
    public string defaultAddress;

    public PlayerController player;

    public float checkWalletDelay;
    private float lastCheck = 0.0f;

    readonly string TestCoin = "6b8d07d69639e9413dd637a1a815a7323c69c86abbafb66dbfdb1aa7";

    public Door door;

    // UI
    public Text debug;
    public Button connect;

    void Start() {
        console = GetComponent<Console>();
        ui = GetComponent<UI>();
        door = FindObjectOfType<Door>();

        client = new API(myConfiguration);

        connect.interactable = true;
    }

    public void Connect() {
#if UNITY_WEBGL
        StartCoroutine(WaitForAddress());
#else
        StartCoroutine(WaitForAddressMock());
#endif
    }

    IEnumerator WaitForAddressMock() {
        console.Log("Setting address", "...");
        Address = defaultAddress;
        StartGame();
        yield return null;
    }

    IEnumerator WaitForAddress() {
        connect.interactable = false;
        console.Log("Connecting to wallet", "...");
        LoadBaseAddress();
        Address = GetBaseAddress();
        for (int i = 0; i <= 10; i++) {
            Address = GetBaseAddress();
            if (Address.Length > 0) break;
            console.Log($"Retrying in 1s", "...");
            yield return new WaitForSeconds(1.0f);
        }

        if (Address.Length == 0) {
            console.Log($"Error:", "too many attempts");
            ui.Error("Could not connect to Nami wallet, check your settings and reload page to try again");
            yield break;
        }

        ClearBaseAddress();
        console.Log("Found base hex address", Address);
        var converter = new CardanoBech32Wrapper();
        Address = converter.ConvertToBech32AddressFromHex(Address, AddressType.addr_test);
        console.Log("Converted to bech32", Address);
        StartGame();
    }

    public void StartGame() {
        connect.interactable = true;
        ui.DisableIntro();
        player.enabled = true;
    }

    public async void UnlockDoor() {
        if (Time.time < lastCheck + checkWalletDelay) return;

        console.Log("Loading coins", Address);
        lastCheck = Time.time;
        var ac = await client.GetSpecificAddress(Address);
        console.Log("Loaded", $"{ac.amount.Length}");

        foreach (var amount in ac.amount) {
            if (amount.unit == TestCoin) {
                console.Log("Found Testcoin", $"({amount.quantity})");
                door.Open();
            }
        }
    }

}