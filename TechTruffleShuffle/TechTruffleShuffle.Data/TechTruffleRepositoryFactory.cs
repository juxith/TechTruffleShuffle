using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTruffleShuffle.Data
{
    public class TechTruffleRepositoryFactory
    {
        public static ITruffleShuffleRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new TruffleShuffleRepositoryMock();
                //case "EntityFramework":
                //    return new TruffleShuffleRepositoryEF();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
