using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab;

public interface IPersonalAccessTokensClient
{
    IEnumerable<PersonalAccessToken> Get();

    GitLabCollectionResponse<PersonalAccessToken> GetAsync();

    PersonalAccessToken Get(long id);

    Task<PersonalAccessToken> GetAsync(long id, CancellationToken cancellationToken = default);

    IEnumerable<PersonalAccessToken> Get(PersonalAccessTokenQuery query);

    GitLabCollectionResponse<PersonalAccessToken> GetAsync(PersonalAccessTokenQuery query);

    PersonalAccessToken GetSelf();

    Task<PersonalAccessToken> GetSelfAsync(CancellationToken cancellationToken = default);

    PersonalAccessToken Rotate(long id, DateTime? expiresAt = null);

    Task<PersonalAccessToken> RotateAsync(long id, DateTime? expiresAt = null, CancellationToken cancellationToken = default);

    PersonalAccessToken RotateSelf(DateTime? expiresAt = null);

    Task<PersonalAccessToken> RotateSelfAsync(DateTime? expiresAt = null, CancellationToken cancellationToken = default);
}
