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
using System.ComponentModel;
using System.Collections.Generic;

namespace Silverlight3dApp.Objects
{
    public class Elevator : DependencyObject
    {
        private int _nextFloor;
        private Stack<Floor> summonedFloors; 
        

        #region CurrentFloor (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public double CurrentFloor
        {
            get { return (double)GetValue(CurrentFloorProperty); }
            set { SetValue(CurrentFloorProperty, value); }
        }
        public static readonly DependencyProperty CurrentFloorProperty =
            DependencyProperty.Register("CurrentFloor", typeof(double), typeof(Elevator),
              new PropertyMetadata(1.0));

        #endregion

        #region CurrentDirection (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public Direction CurrentDirection
        {
            get { return (Direction)GetValue(CurrentDirectionProperty); }
            set { SetValue(CurrentDirectionProperty, value); }
        }
        public static readonly DependencyProperty CurrentDirectionProperty =
            DependencyProperty.Register("CurrentDirection", typeof(Direction), typeof(Elevator),
              new PropertyMetadata(Direction.Up));

        #endregion

        #region Moving (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public bool Moving
        {
            get { return (bool)GetValue(MovingProperty); }
            set { SetValue(MovingProperty, value); }
        }
        public static readonly DependencyProperty MovingProperty =
            DependencyProperty.Register("Moving", typeof(bool), typeof(Elevator),
              new PropertyMetadata(false));

        #endregion

        #region Speed (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public double Speed
        {
            get { return (double)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }
        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(double), typeof(Elevator),
              new PropertyMetadata(0.01));

        #endregion

        public void MoveToFloor(int floor)
        {
            if (floor != summonedFloors.Peek().Number)
            {
                _nextFloor = floor;
                Moving = true;
                if (floor < CurrentFloor)
                    CurrentDirection = Direction.Down;
                else
                    CurrentDirection = Direction.Up;
            }
        }
        /// <summary>
        /// Give the elevator a chance to update itself.
        /// </summary>
        public void Tick()
        {
            if (CurrentFloor != _nextFloor)
            {
                if (Moving)
                {
                    switch (CurrentDirection)
                    {
                        case Direction.Up:
                            CurrentFloor = CurrentFloor + Speed;
                            break;
                        case Direction.Down:
                            CurrentFloor = CurrentFloor - Speed;
                            break;
                        default:
                            break;
                    }

                    if (Math.Floor(CurrentFloor) == _nextFloor)
                    {
                        CurrentFloor = _nextFloor;
                        Moving = false;
                    }
                }
            }
        }
    }

}
