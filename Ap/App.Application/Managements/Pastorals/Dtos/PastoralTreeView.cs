using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Managements.Pastorals.Dtos
{
    /// <summary>
    /// Pastoral Tree View
    /// </summary>
    public class PastoralTreeView : PastoralBase
    {
        public int SubCounter { get; set; }
        public PastoralTreeView Parent { get; set; }
        public List<PastoralTreeView> Nodes { get; set; } = new();
    }
}
