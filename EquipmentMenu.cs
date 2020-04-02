using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenu : MonoBehaviour
{
    void OnEnable()
    {
        ListAll();
    }

    void ListAll()
    {
        Equipment[] equipment = EquipmentManager.instance.currentEquipment;

        for (int i=0; i < equipment.Length; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            Text textObj = child.transform.GetComponentInChildren<Text>();

            textObj.text = "";

            if (equipment[i] != null)
            {
                if (i == 0 || i == equipment.Length - 1)
                {
                    textObj.text = $"{equipment[i].name}\nAttack: {equipment[i].damageModifier}";
                }
                else
                {
                    textObj.text = $"{equipment[i].name}\nDefense: {equipment[i].armorModifier}";
                }
            }
        }
    }
}
