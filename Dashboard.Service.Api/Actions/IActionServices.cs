using Dashboard.Common;
using Dashboard.DataDto.Action;
using Dashboard.DataDto.User;
using Dashboard.DataDto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Service.Api.Actions
{
    public interface IActionServices
    {
        public ResponseBase<List<ActionDto>> GetActionHistory(int idUser);
    }
}
