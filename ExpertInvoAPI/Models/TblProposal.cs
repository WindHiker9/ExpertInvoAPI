using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblProposal
    {
        public int ProposId { get; set; }
        public string CompanyName { get; set; }
        public string EngineerName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ProposalPurpose { get; set; }
        public string MajorComponents { get; set; }
        public string HourlyRate { get; set; }
        public string EstimatedTotalPrice { get; set; }
        public string ProposalData { get; set; }
        public string ProposalService { get; set; }
        public string ProposedUi { get; set; }
    }
}
