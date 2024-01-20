using AuditApplication.DTOs.DTOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.StatusService
{
    enum StatusName
    {
        Closed, 
        Open
    }
    // Used patern Template method
    public abstract class StatusManagerBase<T>
    {
        public bool CheckStatus { get; set; }
        protected abstract bool AreAllDiscrepanciesResolved(T item);

        public IEnumerable<T> UpdateStatus(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                UpdateStatusForSingleItem(item);
            }
            return items;
        }
        public virtual T UpdateStatusForSingleItem(T item)
        {
            if (AreAllDiscrepanciesResolved(item))
            {
                SetStatus(item, StatusName.Closed.ToString());
                CheckStatus = true;
            }
            else
            {
                SetStatus(item, StatusName.Open.ToString());
                CheckStatus = false;
            }
            return item;
        }


        protected abstract void SetStatus(T item, string statusName);
    }
}
