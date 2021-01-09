namespace CensusAPI.Features
{
    using System.Collections.Generic;
    using VirtualBrightPlayz.SCP_ET.World;

    public class Scp914
    {
        private static SCP914 __instance;

        public static SCP914 Instance
        {
            get
            {
                if (__instance == null)
                {
                    __instance = UnityEngine.Object.FindObjectOfType<SCP914>();
                }
                return __instance;
            }
        }

        public static Scp914Setting Mode
        {
            get => Instance.NetworkcurMode;
            set
            {
                Instance.NetworkcurMode = value;
            }
        }

        public static bool IsRefining
        {
            get => Instance.NetworkisRefining;
            set
            {
                Instance.NetworkisRefining = value;
            }
        }

        public static double RefineTime
        {
            get => Instance.NetworkrefineTime;
            set
            {
                Instance.NetworkrefineTime = value;
            }
        }

        public static List<SCP914.SCP914Recipe> Recipes => Instance.RecipeTypes;

        public static void Activate()
        {
            Instance.Refine();
        }
    }
}