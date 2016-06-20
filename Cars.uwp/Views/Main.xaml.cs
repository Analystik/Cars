using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cars.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
        private Models.Make SelectedMake;
        private Models.Model SelectedModel;

        public Main()
        {
            this.InitializeComponent();

            var vm = this.DataContext as VModel;
            vm.GetMakes();
            vm.GetProvinces();

        }

        private void cboMakes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            this.SelectedMake = this.cboMakes.SelectedItem as Models.Make;

            var vm = this.DataContext as VModel;
            vm.GetModels(this.SelectedMake?.Id ?? 0);

        }

        private void cboModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            this.SelectedModel = this.cboModels.SelectedItem as Models.Model;

            var vm = this.DataContext as VModel;
            vm.GetCars(this.SelectedMake?.Id ?? 0, this.SelectedModel?.Id ?? 0);

        }

        private void btnEvaluate_Click(object sender, RoutedEventArgs e)
        {

            var car = this.cboCars.SelectedItem as Models.Car;
            var province = this.cboProvince.SelectedItem as Models.Province;

            var profile = new Models.Profile();
            profile.CarId = car?.Id ?? 0;
            profile.KMPerYear = Convert.ToInt32(this.sldKilometer.Value);
            profile.ProvinceId = province?.Id ?? 0;

            this.Frame.Navigate(typeof(Views.Result), profile);

        }
    }
}
