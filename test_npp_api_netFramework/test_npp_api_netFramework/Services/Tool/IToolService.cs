using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using test_sql.EF_entities;

namespace test_sql.Services.Tool
{
    public interface IToolService :
        IDisposable,
        IToolServiceRepository
    {

    }

    public interface IToolServiceRepository
    {
        Task<IEnumerable<EF_entities.Tool>> GetAll_notEmptyAsync();
        Task LoadAsync(EF_entities.Tool tool);

        Task<EF_entities.Tool> GetByIdAsync(int id);

    }
}