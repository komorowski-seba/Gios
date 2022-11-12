﻿using Application.Interfaces;
using DomainQl.Common.Interfaces;
using Marten;
using MediatR;

namespace Infrastructure.Marten.Services;

public sealed class MartensEventsStoreDb : IEventsStoreDb
{
    private readonly IDocumentSession _documentSession;

    public MartensEventsStoreDb(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task AppendEventAsync(IEvent evt, CancellationToken cancellationToken)
    {
        _documentSession.Events.Append(evt.CommuneId, evt);
        await _documentSession.SaveChangesAsync(cancellationToken);
    }
}