// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting.Azure;

/// <summary>
/// Represents an Azure Redis resource.
/// </summary>
/// <param name="innerResource">The inner resource.</param>
public class AzureRedisResource(RedisResource innerResource) :
    AzureBicepResource(innerResource.Name, templateResourceName: "Aspire.Hosting.Azure.Bicep.redis.bicep"),
    IResourceWithConnectionString
{
    /// <summary>
    /// Gets the "connectionString" output reference from the bicep template for the Azure Redis resource.
    /// </summary>
    public BicepSecretOutputReference ConnectionString => new("connectionString", this);

    /// <summary>
    /// Gets the connection string template for the manifest for the Azure Redis resource.
    /// </summary>
    public string ConnectionStringExpression => ConnectionString.ValueExpression;

    /// <summary>
    /// Gets the connection string for the Azure Redis resource.
    /// </summary>
    /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The connection string for the Azure Redis resource.</returns>
    public ValueTask<string?> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        return ConnectionString.GetValueAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public override string Name => innerResource.Name;

    /// <inheritdoc />
    public override ResourceAnnotationCollection Annotations => innerResource.Annotations;
}

/// <summary>
/// Represents an Azure Redis resource.
/// </summary>
/// <param name="innerResource">The inner resource.</param>
/// <param name="configureConstruct"></param>
public class AzureRedisConstructResource(RedisResource innerResource, Action<ResourceModuleConstruct> configureConstruct) :
    AzureConstructResource(innerResource.Name, configureConstruct),
    IResourceWithConnectionString
{
    /// <summary>
    /// Gets the "connectionString" output reference from the bicep template for the Azure Redis resource.
    /// </summary>
    public BicepSecretOutputReference ConnectionString => new("connectionString", this);

    /// <summary>
    /// Gets the connection string template for the manifest for the Azure Redis resource.
    /// </summary>
    public string ConnectionStringExpression => ConnectionString.ValueExpression;

    /// <summary>
    /// Gets the connection string for the Azure Redis resource.
    /// </summary>
    /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The connection string for the Azure Redis resource.</returns>
    public ValueTask<string?> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        return ConnectionString.GetValueAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public override string Name => innerResource.Name;

    /// <inheritdoc />
    public override ResourceAnnotationCollection Annotations => innerResource.Annotations;
}
