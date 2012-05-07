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
using System.Collections.ObjectModel;

namespace Silverlight3dApp.Objects
{
    public class ElevatorManager : DependencyObject
    {
        public ElevatorManager()
        {
            NumberOfFloors = 2;
        }

        /// <summary>
        /// Gives the elevator manager a chance to update itself.
        /// </summary>
        public void Tick()
        {
            //Update all of my elevators.
            Dispatcher.BeginInvoke(() =>
            {
                foreach (Elevator e in this.Elevators)
                {
                    e.Tick();
                }
            });
        }

        public ElevatorManager(int numFloors)
        {
            NumberOfFloors = numFloors;
        }
        public int NumberOfFloors { get; private set; }

        /// <summary>
        /// Calls the nearest elevator to the specified floor.
        /// </summary>
        /// <param name="floorNumber"></param>
        public void CallElevator(int floorNumber)
        {
            double smallestElevatorFloorDelta = double.MaxValue;
            Elevator closestElevator = null;
            //Figure out which elevator is closest (and eventually fastest), and then summon it to the requested floor.
            foreach (Elevator e in this.Elevators)
            {
                double currentElevatorsFloorDelta;
                if(!e.Moving)
                {
                    currentElevatorsFloorDelta = Math.Abs(e.CurrentFloor - floorNumber);

                    if (currentElevatorsFloorDelta < smallestElevatorFloorDelta)
                    {
                        closestElevator = e;
                        smallestElevatorFloorDelta = currentElevatorsFloorDelta;
                    }
                    
                }
            }
            closestElevator.MoveToFloor(floorNumber);
        }


        #region Elevators (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public ObservableCollection<Elevator> Elevators
        {
            get { return (ObservableCollection<Elevator>)GetValue(ElevatorsProperty); }
            set { SetValue(ElevatorsProperty, value); }
        }
        public static readonly DependencyProperty ElevatorsProperty =
            DependencyProperty.Register("Elevators", typeof(ObservableCollection<Elevator>), typeof(ElevatorManager),
              new PropertyMetadata(new ObservableCollection<Elevator>()));

        #endregion
        
    }
}
