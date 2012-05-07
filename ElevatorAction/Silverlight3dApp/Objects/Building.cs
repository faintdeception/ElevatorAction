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
    public class Building : DependencyObject
    {

        public Building(int numFloors)
        {
            for (int i = 0; i < numFloors; i++)
            {
                this.Floors.Add(new Floor() { Number = i + 1 });
            }
        }

        #region Floors (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public ObservableCollection<Floor> Floors
        {
            get { return (ObservableCollection<Floor>)GetValue(FloorsProperty); }
            set { SetValue(FloorsProperty, value); }
        }
        public static readonly DependencyProperty FloorsProperty =
            DependencyProperty.Register("Floors", typeof(ObservableCollection<Floor>), typeof(Building),
              new PropertyMetadata(new ObservableCollection<Floor>()));

        #endregion
        
    }
}
