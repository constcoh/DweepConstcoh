﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Autofac;
using DweepConstcoh.Game;
using DweepConstcoh.Game.Levels;

namespace DweepConstcoh
{
    public partial class frmMain : Form
    {
        private IContainer _container;

        private IGame _game;

        private ILifetimeScope _lifetimeScope;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._container = ContainerConfig.Configure(new Level1());
            this._lifetimeScope = _container.BeginLifetimeScope();
            this._game = this._lifetimeScope.Resolve<IGame>();
        }

        private void tmrGameProcesses_Tick(object sender, EventArgs e)
        {
            _game.ProcessGame(this.tmrGameProcesses.Interval);

            using (var graphics = this.pnlGameSpace.CreateGraphics())
            {
                this._game.Redraw(graphics);
            }

            using (var graphics = this.pnlToolset.CreateGraphics())
            {
                this._game.RedrawToolset(graphics);
            }
        }

        private void pnlToolset_MouseDown(object sender, MouseEventArgs e)
        {
            this._game.ToolsLeftButtonMouseController.Click(e.X, e.Y);
        }

        private void pnlGameSpace_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    this._game.MapLeftButtonMouseController.Click(e.X, e.Y);
                    return;
                case MouseButtons.Right:
                    this._game.MapRightButtonMouseController.Click(e.X, e.Y);
                    return;
            }
        }
    }
}
