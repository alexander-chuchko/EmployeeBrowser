
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BSATask.DAL
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}
