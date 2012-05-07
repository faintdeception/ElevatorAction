using System.Windows.Controls;
using System.Windows.Graphics;
using System.Windows;
using Silverlight3dApp.Objects;

namespace Silverlight3dApp
{
    public partial class MainPage
    {
        Scene scene;

        App appReference;

        public MainPage()
        {
            InitializeComponent();
            appReference = (App)Application.Current;
            this.DataContext = appReference.MainViewModel;

            for(int i = 0; i < 5; i++)
                this.appReference.MainViewModel.Manager.Elevators.Add(new Elevator());
        }

        private void myDrawingSurface_Draw(object sender, DrawEventArgs e)
        {
            this.appReference.MainViewModel.Manager.Tick();

            // Render scene
            scene.Draw();

            // Let's go for another turn!
            e.InvalidateSurface();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if GPU is on
            if (GraphicsDeviceManager.Current.RenderMode != RenderMode.Hardware)
            {
                MessageBox.Show("Please activate enableGPUAcceleration=true on your Silverlight plugin page.", "Warning", MessageBoxButton.OK);
            }

            // Create the scene
            scene = new Scene(myDrawingSurface);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            int callingFloor = ((Floor)this.FloorsGrid.SelectedItem).Number;
            appReference.MainViewModel.Manager.CallElevator(callingFloor);
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            int callingFloor = ((Floor)this.FloorsGrid.SelectedItem).Number;
            appReference.MainViewModel.Manager.CallElevator(callingFloor);
        }
    }
}
