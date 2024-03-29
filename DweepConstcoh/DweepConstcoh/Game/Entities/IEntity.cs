﻿using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities
{
    public interface IEntity
    {
        EntityType Type { get; }

        MapLayer MapLayer { get; }
        
        int X { get; }

        int Y { get; }

        bool Has(EntityProperty property);

        bool ApplyTool(EntityType entityType);

        void Bomb();

        void Lazer();
    }
}
