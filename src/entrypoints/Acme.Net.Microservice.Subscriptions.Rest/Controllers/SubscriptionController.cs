using Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.CancelSubscription;

namespace Acme.Net.Microservice.Subscriptions.Rest.Controllers;

/// <summary>
/// Controller class responsible for handling HTTP requests related to Subscriptions.
/// </summary>
/// <param name="mediator">Mediator instance for sending commands and queries.</param>
/// <param name="mapper">Mapper instance for mapping between DTOs and commands/queries.</param>
[Route("api/[controller]")]
[ApiController]
public class SubscriptionController(IMediator mediator, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all Subscriptions.
    /// </summary>
    /// <param name="criteria">Criteria for filtering and sorting the Subscriptions.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of Subscriptions.</returns>
    [HttpGet]
    public async Task<IActionResult> GetSubscriptions([FromQuery] C.Criteria criteria, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllSubscriptionQuery(criteria), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get a Subscription by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Subscription.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Subscription.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriptionById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetSubscriptionByIdQuery(id), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Create a new Subscription.
    /// </summary>
    /// <param name="data">Data for creating the Subscription.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionDto data, CancellationToken cancellationToken)
    { 
        await mediator.Send(mapper.Map<CreateSubscriptionCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Update an existing Subscription.
    /// </summary>
    /// <param name="id">The unique identifier of the Subscription.</param>
    /// <param name="data">Data for updating the Subscription.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubscription(Guid id, [FromBody] UpdateSubscriptionDto data, CancellationToken cancellationToken)
    {
        data.Id = id;

        await mediator.Send(mapper.Map<UpdateSubscriptionCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Cancel an existing Subscription.
    /// </summary>
    /// <param name="id">The unique identifier of the Subscription.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelSubscription(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new CancelSubscriptionCommand(id), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Inactivate an existing Subscription.
    /// </summary>
    /// <param name="id">The unique identifier of the Subscription.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPatch("{id}/inactivate")]
    public async Task<IActionResult> InactivateSubscription(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new InactivateSubscriptionCommand(id), cancellationToken);

        return NoContent();
    }
}
