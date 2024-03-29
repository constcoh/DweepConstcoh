﻿using System.Drawing;
using DweepConstcoh.Game.Controllers;
using DweepConstcoh.Game.Levels;

namespace DweepConstcoh.Game
{
    public interface IGame
    {
        IMouseController MapLeftButtonMouseController { get; }
        IMouseController MapRightButtonMouseController { get; }
        IMouseController ToolsLeftButtonMouseController { get; }

        void ProcessGame(int passedIntervalInMilliseconds);
        void Redraw(Graphics graphics);
        void RedrawToolset(Graphics graphics);

        void StartLevel(LevelNumber level);
    }
}