// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Damage_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Damage_Control_CS : MonoBehaviour
  {
    [Header("Damage settings")]
    [Tooltip("Durability of this tank.")]
    public float durability = 300f;
    [Tooltip("Prefab used for destroyed effects.")]
    public GameObject destroyedPrefab;
    [Tooltip("Prefab of Damage Text.")]
    public GameObject textPrefab;
    [Tooltip("Name of the Canvas used for Damage Text.")]
    public string canvasName = "Canvas_Texts";
    private Transform bodyTransform;
    private Damage_Display_CS displayScript;
    private float initialDurability;
    private ID_Control_CS idScript;

    private void Start() => this.initialDurability = this.durability;

    private void Set_DamageText()
    {
      if ((Object) this.textPrefab == (Object) null || string.IsNullOrEmpty(this.canvasName) || (double) this.durability == double.PositiveInfinity)
        return;
      this.displayScript = Object.Instantiate<GameObject>(this.textPrefab, Vector3.zero, Quaternion.identity).GetComponent<Damage_Display_CS>();
      this.displayScript.targetTransform = this.bodyTransform;
      GameObject gameObject = GameObject.Find(this.canvasName);
      if ((bool) (Object) gameObject)
      {
        this.displayScript.transform.SetParent(gameObject.transform);
        this.displayScript.transform.localScale = Vector3.one;
      }
      else
        Debug.LogWarning((object) "Canvas for Damage Text cannot be found.");
    }

    private void Update()
    {
      if (!this.idScript.isPlayer || !Input.GetKeyDown(KeyCode.Return))
        return;
      this.Start_Destroying();
    }

    public void Get_Damage(float damageValue)
    {
      this.durability -= damageValue;
      if ((double) this.durability > 0.0)
      {
        if (!(bool) (Object) this.displayScript)
          return;
        this.displayScript.Get_Damage(this.durability, this.initialDurability);
      }
      else
        this.Start_Destroying();
    }

    private void Start_Destroying()
    {
      this.BroadcastMessage("Destroy", SendMessageOptions.DontRequireReceiver);
      if ((bool) (Object) this.destroyedPrefab)
        Object.Instantiate<GameObject>(this.destroyedPrefab, this.bodyTransform.position, Quaternion.identity).transform.parent = this.bodyTransform;
      if ((bool) (Object) this.displayScript)
        Object.Destroy((Object) this.displayScript.gameObject);
      Object.Destroy((Object) this);
    }

    private void Get_ID_Script(ID_Control_CS tempScript)
    {
      this.idScript = tempScript;
      this.bodyTransform = this.idScript.storedTankProp.bodyTransform;
      this.Set_DamageText();
    }

    private void Pause(bool isPaused) => this.enabled = !isPaused;
  }
}
