using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interop;

namespace CredNet.Interface
{
    public interface IReportResult
    {
        void ReportResult(int status, int subStatus, ref string statusText, ref StatusIcon icon);
    }
}
