using Dashboard.Common;
using Dashboard.DataDto.AccountFb;
using Dashboard.DataDto.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Service.Api.AccountFbs
{
    public class AccountFbsServices : ApiServiceBase, IAccountFbsServices
    {
        public ResponseBase<List<TestChartFbDto>> TestChart()
        {
            var response = Get<List<TestChartFbDto>>("AccountFb/test-chart");
            return response;
        }
    }
}
