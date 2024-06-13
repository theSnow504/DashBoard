using Dashboard.Common;
using Dashboard.DataDto.Action;

namespace Dashboard.Service.Api.Actions
{
    public interface IActionServices
    {
        public ResponseBase<List<ActionDto>> GetActionHistory(int idUser);
    }
}