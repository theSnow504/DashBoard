using Dashboard.Common;
using Dashboard.DataDto.Action;

namespace Dashboard.Service.Api.Actions
{
    public class ActionServices : ApiServiceBase, IActionServices
    {
        public ResponseBase<List<ActionDto>> GetActionHistory(int idUser)
        {
            var response = Get<List<ActionDto>>("action/history"
                , new KeyValuePair<string, object>("idUser", idUser));
            return response;
        }
    }
}