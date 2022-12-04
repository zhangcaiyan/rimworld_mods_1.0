using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RecipeIcons
{

    [HarmonyPatch(typeof(BillStack), "DoListing"), StaticConstructorOnStartup]
    class PatchBillStackDoListing
    {
        static bool Prefix(BillStack __instance, Rect rect, ref Func<List<FloatMenuOption>> recipeOptionsMaker, ref Vector2 scrollPosition, ref float viewHeight)
        {
            Func<List<FloatMenuOption>> func = recipeOptionsMaker;

            recipeOptionsMaker = delegate ()
            {
                List<FloatMenuOption> res = new List<FloatMenuOption>();

                foreach (var item in func())
                {
                    res.Add(new FloatMenuOptionLeft(item));
                }

                return res;
            };

            return true;
        }
    }
}
