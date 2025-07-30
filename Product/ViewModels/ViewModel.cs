using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.ViewModels
{

    public class ViewModel
    {
        public Model Model { get; set; }
        public ViewModel()
        {
            this.Model = new Model();
        }
    }
}
