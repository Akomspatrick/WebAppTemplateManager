﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplateManager.DomainBase.Interfaces
{
    //https://mysqlconnector.net/troubleshooting/datetime-storage/
    public interface IAuditableEntity
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public string CreatedBy { get; init; }
        public string UpdatedBy { get; init; }



    }
}
