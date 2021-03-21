﻿using System;
using System.Collections.Generic;
using DweepConstcoh.Game.Entities.ToolsetEntities;

namespace DweepConstcoh.Game.Entities
{
    public class EntityFactory
    {
        private readonly IDictionary<EntityType, Type> _types;

        public EntityFactory()
        {
            this._types = new Dictionary<EntityType, Type>
            {
                { EntityType.Finish, typeof(GroundEntities.FinishEntity) },
                { EntityType.Ground, typeof(GroundEntities.GroundEntity) },
                { EntityType.Wall, typeof(GroundEntities.WallEntity) },

                { EntityType.Player, typeof(PlayerEntity) },

                { EntityType.PlayerMover, typeof(PlayerMoverEntity) },
                { EntityType.ToolsetSelector, typeof(ToolsetSelectorEntity) }
            };
        }

        public IEntity Create(EntityType type, int x, int y)
        {
            if (this._types.ContainsKey(type) == false)
            {
                throw new Exception("unknown entity type " + type);
            }

            var typeClass = this._types[type];

            return (IEntity)Activator.CreateInstance(typeClass, x, y);
        }
    }
}