﻿using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public interface ILevel
    {
        void FillMap(IMap map);
        void FillToolset(IToolset toolset);
    }
}