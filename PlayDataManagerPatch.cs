using HarmonyLib;

namespace TaikoInfiniteCoins
{
    [HarmonyPatch(typeof(PlayDataManager), nameof(PlayDataManager.GetDonCoin))]
    public static class PlayDataManagerPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result)
        {
            __result = DataConst.DonCoinMax;
            return false;
        }
    }
}