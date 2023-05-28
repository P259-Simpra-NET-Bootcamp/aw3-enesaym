using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Base.Model;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }=DateTime.UtcNow;
    public string CreatedBy { get; set; }=Environment.MachineName;
    
}
