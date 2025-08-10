using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Impl;

public class PersonalAccessTokensClient : IPersonalAccessTokensClient
{
    private const string PatUrl = "/personal_access_tokens";
    private const string PatIdUrl = "/personal_access_tokens/{0}";
    private const string PatRotateUrl = "/personal_access_tokens/{0}/rotate";

    private readonly API _api;

    public PersonalAccessTokensClient(API api)
    {
        _api = api;
    }

    public IEnumerable<PersonalAccessToken> Get()
    {
        return _api.Get().GetAll<PersonalAccessToken>(PatUrl);
    }

    public GitLabCollectionResponse<PersonalAccessToken> GetAsync()
    {
        return _api.Get().GetAllAsync<PersonalAccessToken>(PatUrl);
    }

    public PersonalAccessToken Get(long id)
    {
        return _api.Get().To<PersonalAccessToken>(string.Format(PatIdUrl, id));
    }

    public Task<PersonalAccessToken> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        return _api.Get().ToAsync<PersonalAccessToken>(string.Format(PatIdUrl, id), cancellationToken);
    }

    public IEnumerable<PersonalAccessToken> Get(PersonalAccessTokenQuery query)
    {
        string url = AddQueryParameters(PatUrl, query);
        return _api.Get().GetAll<PersonalAccessToken>(url);
    }

    public GitLabCollectionResponse<PersonalAccessToken> GetAsync(PersonalAccessTokenQuery query)
    {
        string url = AddQueryParameters(PatUrl, query);
        return _api.Get().GetAllAsync<PersonalAccessToken>(url);
    }

    public PersonalAccessToken GetSelf()
    {
        return _api.Get().To<PersonalAccessToken>(string.Format(PatIdUrl, "self"));
    }

    public Task<PersonalAccessToken> GetSelfAsync(CancellationToken cancellationToken = default)
    {
        return _api.Get().ToAsync<PersonalAccessToken>(string.Format(PatIdUrl, "self"), cancellationToken);
    }

    public PersonalAccessToken Rotate(long id, DateTime? expiresAt = null)
    {
        string url = string.Format(PatRotateUrl, id);
        if (expiresAt != null)
        {
            url = Utils.AddParameter(url, "expires_at", expiresAt);
        }

        return _api.Post().To<PersonalAccessToken>(url);
    }

    public Task<PersonalAccessToken> RotateAsync(long id, DateTime? expiresAt = null, CancellationToken cancellationToken = default)
    {
        string url = string.Format(PatRotateUrl, id);
        if (expiresAt != null)
        {
            url = Utils.AddParameter(url, "expires_at", expiresAt);
        }

        return _api.Post().ToAsync<PersonalAccessToken>(url, cancellationToken);
    }

    public PersonalAccessToken RotateSelf(DateTime? expiresAt = null)
    {
        string url = string.Format(PatRotateUrl, "self");
        if (expiresAt != null)
        {
            url = Utils.AddParameter(url, "expires_at", expiresAt);
        }

        return _api.Post().To<PersonalAccessToken>(url);
    }

    public Task<PersonalAccessToken> RotateSelfAsync(DateTime? expiresAt = null, CancellationToken cancellationToken = default)
    {
        string url = string.Format(PatRotateUrl, "id)self";
        if (expiresAt != null)
        {
            url = Utils.AddParameter(url, "expires_at", expiresAt);
        }

        return _api.Post().ToAsync<PersonalAccessToken>(url, cancellationToken);
    }

    private static string AddQueryParameters(string url, PersonalAccessTokenQuery query)
    {
        url = Utils.AddParameter(url, "created_after", query.CreatedAfter);
        url = Utils.AddParameter(url, "created_before", query.CreatedBefore);
        url = Utils.AddParameter(url, "expires_after", query.ExpiresAfter);
        url = Utils.AddParameter(url, "expires_before", query.ExpiresBefore);
        url = Utils.AddParameter(url, "last_used_after", query.LastUsedAfter);
        url = Utils.AddParameter(url, "last_used_before", query.LastUsedBefore);
        url = Utils.AddParameter(url, "revoked", query.Revoked);
        url = Utils.AddParameter(url, "search", query.Search);
        url = Utils.AddParameter(url, "sort", query.Sort);
        url = Utils.AddParameter(url, "state", query.State);
        url = Utils.AddParameter(url, "user_id", query.UserId);
        return url;
    }
}
