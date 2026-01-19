using UnityEngine;
using SRML;
using SRML.SR;
using SRML.Utils;

namespace FrozenFrontiers
{
    public class FrozenFrontiers : ModEntryPoint
    {
        public override void Load()
        {
            Debug.Log("[FrozenFrontiers] Loading mod...");
            Content.CreateAll();
            Debug.Log("[FrozenFrontiers] Content registered successfully!");
        }
    }

    public static class Content
    {
        public static Identifiable.Id SNOWFLAKE_SLIME;
        public static Identifiable.Id SNOW_CARROT;
        public static Identifiable.Id SNOWFLAKE_FOOD;
        public static Identifiable.Id SNOWFLAKE_PLORT;

        public static void CreateAll()
        {
            SNOW_CARROT = IdRegistry.CreateId("snow_carrot");
            SNOWFLAKE_FOOD = IdRegistry.CreateId("snowflake_food");
            SNOWFLAKE_PLORT = IdRegistry.CreateId("snowflake_plort");
            SNOWFLAKE_SLIME = IdRegistry.CreateId("snowflake_slime");

            CreateFoods();
            CreatePlort();
            CreateSlime();
        }

        private static void CreateFoods()
        {
            var carrot = SRObjects.CreateFood(
                Identifiable.Id.CARROT,
                "snow_carrot",
                "Snow Carrot",
                Color.white,
                "A carrot chilled to the core."
            );
            carrot.GetComponent<Identifiable>().id = SNOW_CARROT;

            var flake = SRObjects.CreateFood(
                Identifiable.Id.CARROT,
                "snowflake_food",
                "Snowflake",
                Color.cyan,
                "Cold enough to freeze your hands."
            );
            flake.GetComponent<Identifiable>().id = SNOWFLAKE_FOOD;

            var plantable = flake.GetComponent<GardenPlantable>();
            if (plantable != null)
                plantable.enabled = false;
        }

        private static void CreatePlort()
        {
            var plort = SRObjects.CreatePlort(
                Identifiable.Id.PINK_PLORT,
                "snowflake_plort",
                "Snowflake Plort",
                Color.cyan,
                90
            );
            plort.GetComponent<Identifiable>().id = SNOWFLAKE_PLORT;
        }

        private static void CreateSlime()
        {
            var slime = Slime.CreateSlime(
                Identifiable.Id.PINK_SLIME,
                "snowflake_slime",
                "Snowflake Slime",
                Color.white,
                Color.cyan,
                Color.blue,
                "A gentle, chilly slime that loves snow ——— and everything else."
            );

            slime.GetComponent<Identifiable>().id = SNOWFLAKE_SLIME;

            var def = slime.GetComponent<SlimeDefinition>();
            def.CanFloat = true;

            def.Diet.MajorFoodGroups = new[] { SlimeEat.FoodGroup.ALL };
            def.Diet.Favorites = new[] { SNOW_CARROT, Identifiable.Id.PINK_PLORT };
            def.Diet.Produces = new[] { SNOWFLAKE_PLORT };

            def.Diet.EatMap.Clear();
            def.Diet.EatMap.Add(SNOW_CARROT, new SlimeEat.EatMapEntry
            {
                producesId = SNOWFLAKE_PLORT,
                producesCount = 3
            });

            def.Diet.EatMap.Add(Identifiable.Id.PINK_PLORT, new SlimeEat.EatMapEntry
            {
                producesId = SNOWFLAKE_PLORT,
                producesCount = 5
            });
        }
    }
}
