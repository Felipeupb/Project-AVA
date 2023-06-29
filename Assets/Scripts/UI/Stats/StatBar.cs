using UnityEngine;
using UnityEngine.UI;
using AVA.Stats;
using System.Collections.Generic;
using TMPro;

namespace AVA.UI.Stats {

    [RequireComponent(typeof(Image))]
    public class StatBar : MonoBehaviour
    {
        // This is temporary
        private Image bar;

        private StatType _type;

        [SerializeField]
        private TMP_Text statValue;

        [SerializeField]
        private Image maxBar;

        private void Awake() {
            bar = GetComponent<Image>();
        }

        public void SetType(StatType type) {
            _type = type;
            bar.color = colors[type];
            maxBar.color = Color.cyan;
        }

        public StatType GetStatType() {
            return _type;
        }

        // Dictionary initialized for the color of each stat
        private Dictionary<StatType, Color> colors = new Dictionary<StatType, Color> {
            {StatType.MaxHealth, Color.green},
            {StatType.Attack, Color.red},
            {StatType.Defense, Color.blue},
            {StatType.Speed, Color.gray},
            {StatType.AttackSpeed, Color.yellow},
            {StatType.CritChance, Color.magenta},
            {StatType.CritDamage, Color.cyan}
        };

        
        public void SetFillAmount(float currentValue, float maxValue) {
            bar.fillAmount = currentValue / maxValue;   
            statValue.text = currentValue.ToString() + " / " + maxValue.ToString();

            maxBar.fillAmount = maxValue / _type.maxValue;
        }
    }
}