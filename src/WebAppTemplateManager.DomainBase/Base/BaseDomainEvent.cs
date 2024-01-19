﻿using MediatR;
using System;


namespace WebAppTemplateManager.DomainBase
{
    public class BaseDomainEvent : INotification
    {
        public virtual Guid EventId { get; init; }
        public virtual DateTime CreatedOn { get; init; }
        public virtual DateTime CreatedOnUtc { get; init; }

        public BaseDomainEvent()
        {
            CreatedOn = DateTime.UtcNow;
            CreatedOnUtc = DateTime.UtcNow;
            EventId = Guid.NewGuid();
        }


        //public DateTimeOffset? CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public DateTimeOffset? UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string CreatedBy { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        //public string UpdatedBy { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    }
}
