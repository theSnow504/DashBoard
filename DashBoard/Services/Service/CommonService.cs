using DataAccess.Context;

namespace DashBoard.Services.Service
{
    public class CommonService
    {
        internal readonly MyDbContext _context;
        public CommonService(MyDbContext context)
        {
            _context = context;
        }
    }
}

