using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docrafERP.Views
{
    public class SingletoneHomeView
    {
        private static SingletoneHomeView instance = null;

        public HomeView homeView { get; set; }

        private SingletoneHomeView()
        {

        }

        public static SingletoneHomeView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletoneHomeView();
                }
                return instance;
            }
        }

    }
}
