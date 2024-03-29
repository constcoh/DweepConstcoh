﻿using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.LazerEntities;

namespace DweepConstcoh.Game.Processors.DrawProcess
{
    public class PointDrawingHelper
    {
        private readonly IDrawSettings _drawSettings;
        
        private readonly int _x;

        private readonly int _y;

        public PointDrawingHelper(IDrawSettings drawSettings, int x, int y)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            this._drawSettings = drawSettings;
            this._x = x;
            this._y = y;
        }

        public Point GetCentrePoint()
        {
            return new Point(
                _drawSettings.PointSize * _x + _drawSettings.PointSize / 2,
                _drawSettings.PointSize * _y + _drawSettings.PointSize / 2);
        }

        public Point GetCornerPointLeftTop()
        {
            return new Point(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * _y + 1);
        }

        public Point GetCornerPointLeftDown()
        {
            return new Point(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * (_y + 1) - 2);
        }

        public Point GetCornerPointRightTop()
        {
            return new Point(
                _drawSettings.PointSize * (_x + 1) - 2,
                _drawSettings.PointSize * _y + 1);
        }

        public Point GetCornerPointRightDown()
        {
            return new Point(
                _drawSettings.PointSize * (_x + 1) - 2,
                _drawSettings.PointSize * (_y + 1) - 2);
        }


        public Point GetLazerDirectionPoint(
            LazerDirection direction)
        {
            switch (direction)
            {
                case LazerDirection.Down:
                    return this.GetMiddlePointDown();
                case LazerDirection.Left:
                    return this.GetMiddlePointLeft();
                case LazerDirection.Top:
                    return this.GetMiddlePointTop();
                case LazerDirection.Right:
                default:
                    return this.GetMiddlePointRight();
            }
        }

        public Point GetMiddlePointLeft()
        {
            return new Point(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * _y + _drawSettings.PointSize / 2);
        }

        public Point GetMiddlePointTop()
        {
            return new Point(
                _drawSettings.PointSize * _x + _drawSettings.PointSize / 2,
                _drawSettings.PointSize * _y + 1);
        }

        public Point GetMiddlePointRight()
        {
            return new Point(
                _drawSettings.PointSize * (_x + 1) - 2,
                _drawSettings.PointSize * _y + _drawSettings.PointSize / 2);
        }

        public Point GetMiddlePointDown()
        {
            return new Point(
                _drawSettings.PointSize * _x + _drawSettings.PointSize / 2,
                _drawSettings.PointSize * (_y + 1) - 2);
        }

        public Rectangle GetPointRectangle(int offsetFromSide = 0)
        {
            return new Rectangle(
                _drawSettings.PointSize * _x + 1 + offsetFromSide,
                _drawSettings.PointSize * _y + 1 + offsetFromSide,
                _drawSettings.PointSize - 2 - 2 * offsetFromSide,
                _drawSettings.PointSize - 2 - 2 * offsetFromSide);
        }

        public Rectangle GetPointRectangle(double radius)
        {
            Condition.Requires(radius, nameof(radius)).IsGreaterThan(0).IsLessOrEqual(0.5);

            var centreX = _drawSettings.PointSize * _x + _drawSettings.PointSize / 2;
            var centreY = _drawSettings.PointSize * _y + _drawSettings.PointSize / 2;

            return new Rectangle(
                centreX - (int)(radius * _drawSettings.PointSize),
                centreY - (int)(radius * _drawSettings.PointSize),
                (int)(2 * radius * _drawSettings.PointSize),
                (int)(2 * radius * _drawSettings.PointSize));
        }


        public Point GetPoint(double x, double y)
        {
            Condition.Requires(x, nameof(x)).IsGreaterOrEqual(0).IsLessOrEqual(1);
            Condition.Requires(y, nameof(y)).IsGreaterOrEqual(0).IsLessOrEqual(1);

            var centreX = _drawSettings.PointSize * _x + _drawSettings.PointSize / 2;
            var centreY = _drawSettings.PointSize * _y + _drawSettings.PointSize / 2;

            return new Point(
                _drawSettings.PointSize * _x + (int)(x * (_drawSettings.PointSize - 2)),
                _drawSettings.PointSize * _y + (int)(y * (_drawSettings.PointSize - 2)));        }
    }
}
