﻿// <copyright file="RandomRoomSpawnStep.cs" company="Audino">
// Copyright (c) Audino
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace RogueElements
{
    [Serializable]
    public class RandomRoomSpawnStep<T, E> : RoomSpawnStep<T, E>
        where T : class, IFloorPlanGenContext, IPlaceableGenContext<E>
        where E : ISpawnable
    {
        public bool IncludeHalls;
        public RandomRoomSpawnStep() { }
        public RandomRoomSpawnStep(IStepSpawner<T, E> spawn) : base(spawn) { }
        public RandomRoomSpawnStep(IStepSpawner<T, E> spawn, bool includeHalls) : base(spawn) { IncludeHalls = includeHalls; }

        public override void DistributeSpawns(T map, List<E> spawns)
        {
            //random per room, not per-tile

            var spawningRooms = new SpawnList<RoomHallIndex>();

            for (int ii = 0; ii < map.RoomPlan.RoomCount; ii++)
            {
                spawningRooms.Add(new RoomHallIndex(ii, false));
            }
            if (IncludeHalls)
            {
                for (int ii = 0; ii < map.RoomPlan.HallCount; ii++)
                {
                    spawningRooms.Add(new RoomHallIndex(ii, true));
                }
            }

            SpawnRandInCandRooms(map, spawningRooms, spawns, 100);
        }
    }
}
