using CensusAPI.Enums;


namespace CensusAPI.Extensions
{
    public static class Item
    {
        /// <summary>
        /// Check if an <see cref="ItemType">item</see> is a keycard.
        /// </summary>
        /// <param name="type">The item to be checked.</param>
        /// <returns>Returns whether the <see cref="ItemType"/> is a keycard or not.</returns>
        public static bool IsKeycard(this ItemType type) =>
            type == ItemType.KeycardLvl1 || type == ItemType.KeycardLvl2 || type == ItemType.KeycardLvl3 || type == ItemType.KeycardLvl4 || type == ItemType.KeycardLvl5 || type == ItemType.KeycardLvl5_2;


        /// <summary>
        /// Check if an <see cref="ItemType">item</see> is a MedKit.
        /// </summary>
        /// <param name="type">The item to be checked.</param>
        /// <returns>Returns whether the <see cref="ItemType"/> is a MedKit or not.</returns>
        public static bool IsMedKit(this ItemType type) =>
            type == ItemType.Medkit || type == ItemType.MedkitSmall;

        /// <summary>
        /// Check if an <see cref="ItemType">item</see> is a gas mask.
        /// </summary>
        /// <param name="type">The item to be checked.</param>
        /// <returns>Returns whether the <see cref="ItemType"/> is a gas mask or not.</returns>
        public static bool IsGasMask(this ItemType type) =>
            type == ItemType.Gasmask || type == ItemType.AnomGasmask;

        /// <summary>
        /// Check if an <see cref="ItemType">item</see> is googles.
        /// </summary>
        /// <param name="type">The item to be checked.</param>
        /// <returns>Returns whether the <see cref="ItemType"/> is googles or not.</returns>
        public static bool IsGoogles(this ItemType type) =>
            type == ItemType.BlueVisionGoogles || type == ItemType.NVGoogles || type == ItemType.InfraredGoogles;
    }
}
