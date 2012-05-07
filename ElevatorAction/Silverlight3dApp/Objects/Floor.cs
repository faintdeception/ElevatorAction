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

namespace Silverlight3dApp.Objects
{
    public class Floor : DependencyObject
    {

        #region Number (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(Floor),
              new PropertyMetadata(0));

        #endregion
        
    }
}
