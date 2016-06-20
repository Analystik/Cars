using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class VModel: Notificationbase
    {
        private Model _Model = new Model();



        private ObservableCollection<Models.Make> _Makes;
        public ObservableCollection<Models.Make> Makes
        {
            get { return this._Makes; }
            set { this._Makes = value; this.RaiseNotification(nameof(Makes)); }
        }


        public async void GetMakes()
        {
            var data = await this._Model.GetMakes();
            this.Makes = new ObservableCollection<Models.Make>(data);
        }



    }
}
