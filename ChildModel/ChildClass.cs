using ParentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChildModel
{
    [Table(nameof(ChildClass))]
    public class ChildClass : ParentClass
    {

    }
}
