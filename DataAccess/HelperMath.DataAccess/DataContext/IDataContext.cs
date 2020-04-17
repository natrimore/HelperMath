using Microsoft.EntityFrameworkCore;

namespace HelperMath.DataAccess.DataContext
{
    public interface IDataContext
    {
        DbContext DataContext { get;}
    }
}
