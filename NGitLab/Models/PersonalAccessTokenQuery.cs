using System;

namespace NGitLab.Models;

public class PersonalAccessTokenQuery
{
    public DateTime? CreatedAfter { get; set; }

    public DateTime? CreatedBefore { get; set; }

    public DateTime? ExpiresAfter { get; set; }

    public DateTime? ExpiresBefore { get; set; }

    public DateTime? LastUsedAfter { get; set; }

    public DateTime? LastUsedBefore { get; set; }

    public bool? Revoked { get; set; }

    public string Search { get; set; }

    public string Sort { get; set; }

    public PersonalAccessTokenState? State { get; set; }

    public string UserId { get; set; }
}
