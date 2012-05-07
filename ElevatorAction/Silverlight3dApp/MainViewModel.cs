using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Silverlight3dApp.Objects;

namespace Silverlight3dApp
{
    public class MainViewModel
    {
        private ElevatorManager _manager;
        private Building _pennyworthTowers;
        public ElevatorManager Manager
        {
            get
            {
                if (_manager == null)
                    _manager = new ElevatorManager(10);
                return _manager;
            }
        }

        public Building PennyworthTowers
        {
            get
            {
                if (_pennyworthTowers == null)
                    _pennyworthTowers = new Building(10);
                return _pennyworthTowers;
            }
        }
    }
}
