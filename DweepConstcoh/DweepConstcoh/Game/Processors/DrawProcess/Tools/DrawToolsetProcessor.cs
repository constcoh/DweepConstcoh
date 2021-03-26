﻿using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Processors.DrawProcess.Map;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Processors.DrawProcess.Tools
{
    public class DrawToolsetProcessor : IDrawToolsetProcessor
    {
        private readonly DrawMapProcessor _drawMapProcessor;

        private readonly IToolset _toolset;

        private readonly ToolsetMap _toolsetMap;

        public DrawToolsetProcessor(
            IDrawSettings drawSettings,
            IGameState gameState,
            IToolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();
            this._toolset = toolset;

            this._toolsetMap = new ToolsetMap(this._toolset);
            this._drawMapProcessor = new DrawMapProcessor(drawSettings, gameState, this._toolsetMap);
        }

        public void Draw(Graphics graphics)
        {
            this._toolsetMap.RefreshEntities();
            this._drawMapProcessor.Draw(graphics);
        }
    }
}
