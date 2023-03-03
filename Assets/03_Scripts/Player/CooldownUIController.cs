using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CooldownUIController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Image cooldownImage;

    private void Update()
    {
        UpdateCooldowns();
    }

    public void UpdateCooldowns()
    {
        List<Cooldown> cooldowns = player.Cooldowns.FindAll(x => x.name == player.CurrentForm.ChargeCooldownName);

        if (cooldowns.Count > 0)
            cooldownImage.fillAmount = cooldowns[0].duration / player.CurrentForm.ChargeCooldownDuration;
        else
            cooldownImage.fillAmount = 0;

        // fireImage.fillAmount = player.Cooldowns.FindAll(x => x.name == player.CurrentForm.ChargeCooldownName).duration;
        // foreach (Cooldown cooldown in player.Cooldowns)
        // {
        //     switch (cooldown.name)
        //     {
        //         case "Fire":
        //             fireImage.fillAmount = cooldown.duration / player.FireForm.Stats.chargeCooldownDuration;
        //             break;
        //         case "Air":
        //             airImage.fillAmount = cooldown.duration / player.AirForm.Stats.chargeCooldownDuration;
        //             break;
        //         case "Nature":
        //             natureImage.fillAmount = cooldown.duration / player.NatureForm.Stats.chargeCooldownDuration;
        //             break;
        //         case "Ice":
        //             iceImage.fillAmount = cooldown.duration / player.IceForm.Stats.chargeCooldownDuration;
        //             break;
        //     }
        // }
    }
}
