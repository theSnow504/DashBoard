using Dashboard.Common;
using Dashboard.DataDto.Action;

namespace Dashboard.Service.Api.Actions
{
    public class ActionServices : ApiServiceBase, IActionServices
    {
        public ResponseBase<List<ActionDto>> GetActionHistory(int idUser, DateTime? start, DateTime? end)
        {
            var response = Get<List<ActionDto>>("action/history"
                , new KeyValuePair<string, object>("idUser", idUser));
            if (start.HasValue && end.HasValue) 
            {
                response = Get<List<ActionDto>>("action/history"
                    , new KeyValuePair<string, object>("idUser", idUser), new KeyValuePair<string, object>("start", start),
                    new KeyValuePair<string, object>("end", end));
            }
            return response;
        }
    }
}