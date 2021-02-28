using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI textScript = null;
    [SerializeField] GameObject dropTileInfo;

    // Update is called once per frame
    void Start() {
        GameManager.Instance.onMoving += UpdateScriptStory;
        UpdateScriptText("Welcome to this tutorial!");
    }

    private void UpdateScriptStory() {

        if (GameManager.Instance._currentTile.gameObject.GetComponent<RotationTile>() != null) {
            UpdateScriptText("This tile rotate the map and its abilities.");
            if (dropTileInfo) dropTileInfo.SetActive(false);
        } else if (GameManager.Instance._currentTile.gameObject.GetComponent<AddASlotTile>() != null) {
            UpdateScriptText("This one add an extra slot to your inventory!");
        }

        if (GameManager.Instance._currentTile.TileOwnAbility == null)
            return;

        else if (GameManager.Instance._currentTile.TileOwnAbility.AbilityIcon.name.Contains("left")) {
            UpdateScriptText("Drag and drop abilities in your inventory to add or swap one.");
        } else if (GameManager.Instance._currentTile.TileOwnAbility.AbilityIcon.name.Contains("swim")) {
            UpdateScriptText("Swim ability, so you don't drown into the water.");

        } else if (GameManager.Instance._currentTile.TileOwnAbility.AbilityIcon.name.Contains("shoes")) {
            UpdateScriptText("Special boots, so you can walk on the lava.");
        }
    }

    private void UpdateScriptText(string newScript) {
        textScript.text = newScript;
    }
}
