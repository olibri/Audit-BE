using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.StatusService;
using AuditDomain.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.DTOService
{
    public class AuditStatusManager : StatusManagerBase<AuditDTOGet>
    {
        protected override bool AreAllDiscrepanciesResolved(AuditDTOGet item)
        {
            return item.Discrepancies.Any() &&
                   item.Discrepancies.All(d => d.Status.Name == StatusName.Closed.ToString());
        }

        protected override void SetStatus(AuditDTOGet item, string statusName)
        {
            item.StatusName = statusName;

        }
    }
}
