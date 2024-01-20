using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditApplication.DTOs.StatusService;
using AuditApplication.DTOs.ViolationDTO;

namespace AuditApplication.DTOs.DTOService
{
    public class ViolationStatusManager : StatusManagerBase<ViolationDTOGet>
    {
        protected override bool AreAllDiscrepanciesResolved(ViolationDTOGet item)
        {
            return item.Prescriptions.Any() && 
                   item.Prescriptions.All(d => d.Status.Name == StatusName.Closed.ToString());
        }

        protected override void SetStatus(ViolationDTOGet item, string statusName)
        {
            item.StatusName = statusName;
        }
    }
}
