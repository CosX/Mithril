namespace Assets.Scripts.Inventory.ItemSpecific
{
    public class ArmorConstructed
    {
        public string ItemName;
        public int ItemId;
        public string ItemDesc;
        public int ItemValue;
        public Armor.ArmorTypeDefines ArmorType;
        public int ArmorProtection;
        public string ItemIcon;
        public string ArmorSprite;
    }

    public class WeaponConstructed
    {
        public string ItemName;
        public int ItemId;
        public string ItemDesc;
        public int ItemValue;
        public Weapon.WeaponTypeDefines WeaponType;
        public int WeaponStrength;
        public string ItemIcon;
        public string WeaponSprite;
        public int KnockbackX;
        public int KnockbackY;
        public string ProjectilePath;
    }

    public class ConsumableConstructed
    {
        public string ItemName;
        public int ItemId;
        public string ItemDesc;
        public int ItemValue;
        public Consumable.ConsumableTypeDefines ConsumableType;
        public int AppendValue;
        public string ItemIcon;
    }
}
